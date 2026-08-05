using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;

namespace WinBeyazEsya.Presentation.WinForms.Forms.ParametrelerForms
{
    public partial class UserInterfaceTemplateListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.System.UserInterfaceTemplate> _templateRepository;
        private readonly WinBeyazEsya.Application.Interfaces.Repositories.IMasterUnitOfWork _uow;

        public UserInterfaceTemplateListForm(
            WinBeyazEsya.Application.Interfaces.Repositories.IMasterRepository<WinBeyazEsya.Domain.Entities.System.UserInterfaceTemplate> templateRepository,
            WinBeyazEsya.Application.Interfaces.Repositories.IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _templateRepository = templateRepository;
            _uow = uow;

            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.UserInterfaceTemplate;
            Tablo = myGridView1; 
            
            // Sadece Sil ve Yenile butonları aktif olacak
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnDuzelt };
        }

        protected override void Listele()
        {
            // TODO: İleride SessionManager.CurrentUser.Id kullanılacak. Şimdilik mock olarak 1.
            long currentUserId = 1; 
            var list = _templateRepository.Find(x => x.UserId == currentUserId).ToList();
            myGridControl1.DataSource = list; 
        }

        protected override void EntityDelete()
        {
            if (myGridView1.FocusedRowHandle >= 0)
            {
                var rowObj = myGridView1.GetRowCellValue(myGridView1.FocusedRowHandle, "Id");
                if (rowObj != null && long.TryParse(rowObj.ToString(), out long id))
                {
                    if (WinBeyazEsya.Presentation.WinForms.Helpers.Messages.SilMesaj("Şablon") == DialogResult.Yes)
                    {
                        try
                        {
                            var entity = _templateRepository.GetById(id);
                            if (entity != null)
                            {
                                _templateRepository.Remove(entity);
                                _uow.SaveChanges();
                                Listele();
                            }
                        }
                        catch (Exception ex)
                        {
                            WinBeyazEsya.Presentation.WinForms.Helpers.Messages.HataMesaji(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
