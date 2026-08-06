using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Application.Services.Management
{
    public class UserFavoriteManager : IUserFavoriteService
    {
        private readonly IMasterRepository<UserFavorite> _repository;
        private readonly IMasterUnitOfWork _uow;

        public UserFavoriteManager(IMasterRepository<UserFavorite> repository, IMasterUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public List<UserFavoriteDto> GetUserFavorites(long userId)
        {
            var favorites = _repository.Find(f => f.UserId == userId).ToList();
            return favorites.Select(f => new UserFavoriteDto
            {
                Id = f.Id,
                UserId = f.UserId,
                FormCaption = f.FormCaption,
                FormTypeFullName = f.FormTypeFullName
            }).ToList();
        }

        public bool IsFavorite(long userId, string formTypeFullName)
        {
            return _repository.Find(f => f.UserId == userId && f.FormTypeFullName == formTypeFullName).Any();
        }

        public void ToggleFavorite(long userId, string formCaption, string formTypeFullName)
        {
            var existing = _repository.Find(f => f.UserId == userId && f.FormTypeFullName == formTypeFullName).FirstOrDefault();

            if (existing != null)
            {
                _repository.Remove(existing);
            }
            else
            {
                _repository.Add(new UserFavorite
                {
                    Id = WinBeyazEsya.Domain.Helpers.IdGenerator.GenerateId(),
                    UserId = userId,
                    FormCaption = formCaption,
                    FormTypeFullName = formTypeFullName
                });
            }

            _uow.SaveChanges();
        }
    }
}
