using WinBeyazEsya.Application.DTOs.Management;

namespace WinBeyazEsya.Application.Interfaces.Management
{
    public interface IUserFavoriteService
    {
        List<UserFavoriteDto> GetUserFavorites(long userId);
        bool IsFavorite(long userId, string formTypeFullName);
        void ToggleFavorite(long userId, string formCaption, string formTypeFullName);
    }
}
