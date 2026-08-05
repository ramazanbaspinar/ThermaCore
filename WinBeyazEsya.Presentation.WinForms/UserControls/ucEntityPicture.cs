using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Extensions.DependencyInjection;
using WinBeyazEsya.Application.DTOs.Common;
using WinBeyazEsya.Application.Interfaces.Common;
using WinBeyazEsya.Presentation.WinForms.Functions;

namespace WinBeyazEsya.Presentation.WinForms.UserControls
{
    public partial class ucEntityPicture : XtraUserControl
    {
        private AppDocumentDto _currentDocument;
        private bool _isDirty = false;
        private bool _isLoading = false;

        public event EventHandler OnDirtyChanged;
        public bool IsDirty() => _isDirty;

        public ucEntityPicture()
        {
            InitializeComponent();
        }

        public async Task LoadPictureAsync(string entityName, long entityId)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            var documentService = Program.ServiceProvider.GetService<IDocumentService>();
            if (documentService == null) return;

            var docs = await documentService.GetDocumentsByEntityAsync(entityName, entityId);
            _currentDocument = docs.FirstOrDefault();

            _isLoading = true;
            try
            {
                if (_currentDocument != null && _currentDocument.FileData != null)
                {
                    using (var ms = new MemoryStream(_currentDocument.FileData))
                    {
                        pictureEdit1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureEdit1.Image = null;
                }
            }
            finally
            {
                _isLoading = false;
            }
            
            _isDirty = false;
            pictureEdit1.IsModified = false;
        }

        public async Task SavePictureAsync(string entityName, long entityId)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (!_isDirty) return;

            var documentService = Program.ServiceProvider.GetService<IDocumentService>();
            if (documentService == null) return;

            // If image was cleared
            if (pictureEdit1.Image == null)
            {
                if (_currentDocument != null && _currentDocument.Id > 0)
                {
                    await documentService.DeleteDocumentAsync(_currentDocument.Id);
                    _currentDocument = null;
                }
            }
            else
            {
                // Upload new image
                using (var ms = new MemoryStream())
                {
                    var format = System.Drawing.Imaging.ImageFormat.Png;
                    if (pictureEdit1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    {
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }

                    pictureEdit1.Image.Save(ms, format);
                    var fileData = ms.ToArray();

                    var dto = new AppDocumentDto
                    {
                        EntityName = entityName,
                        EntityId = entityId,
                        FileName = $"{entityName}_{entityId}{(format == System.Drawing.Imaging.ImageFormat.Jpeg ? ".jpg" : ".png")}",
                        Extension = format == System.Drawing.Imaging.ImageFormat.Jpeg ? ".jpg" : ".png",
                        ContentType = format == System.Drawing.Imaging.ImageFormat.Jpeg ? "image/jpeg" : "image/png",
                        FileSize = fileData.Length,
                        FileData = fileData
                    };

                    if (_currentDocument != null && _currentDocument.Id > 0)
                    {
                        await documentService.DeleteDocumentAsync(_currentDocument.Id);
                    }

                    _currentDocument = await documentService.UploadDocumentAsync(dto);
                }
            }
            _isDirty = false;
        }

        public void ClearPicture()
        {
            if (pictureEdit1.Image != null)
            {
                pictureEdit1.Image = null;
                _isDirty = true;
            }
            _currentDocument = null;
        }

        public void LoadPicture(string entityName, long entityId)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            var documentService = Program.ServiceProvider.GetService<IDocumentService>();
            if (documentService == null) return;

            var docs = Task.Run(async () => await documentService.GetDocumentsByEntityAsync(entityName, entityId)).GetAwaiter().GetResult();
            _currentDocument = docs.FirstOrDefault();

            _isLoading = true;
            try
            {
                if (_currentDocument != null && _currentDocument.FileData != null)
                {
                    using (var ms = new MemoryStream(_currentDocument.FileData))
                    {
                        pictureEdit1.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureEdit1.Image = null;
                }
            }
            finally
            {
                _isLoading = false;
            }
            
            _isDirty = false;
            pictureEdit1.IsModified = false;
        }

        public void SavePicture(string entityName, long entityId)
        {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (!_isDirty) return;

            var documentService = Program.ServiceProvider.GetService<IDocumentService>();
            if (documentService == null) return;

            if (pictureEdit1.Image == null)
            {
                if (_currentDocument != null && _currentDocument.Id > 0)
                {
                    var docId = _currentDocument.Id;
                    Task.Run(async () => await documentService.DeleteDocumentAsync(docId)).GetAwaiter().GetResult();
                    _currentDocument = null;
                }
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    var format = System.Drawing.Imaging.ImageFormat.Png;
                    if (pictureEdit1.Image.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
                    {
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    }

                    pictureEdit1.Image.Save(ms, format);
                    var fileData = ms.ToArray();

                    var dto = new AppDocumentDto
                    {
                        EntityName = entityName,
                        EntityId = entityId,
                        FileName = $"{entityName}_{entityId}{(format == System.Drawing.Imaging.ImageFormat.Jpeg ? ".jpg" : ".png")}",
                        Extension = format == System.Drawing.Imaging.ImageFormat.Jpeg ? ".jpg" : ".png",
                        ContentType = format == System.Drawing.Imaging.ImageFormat.Jpeg ? "image/jpeg" : "image/png",
                        FileSize = fileData.Length,
                        FileData = fileData
                    };

                    var docIdToDelete = _currentDocument != null && _currentDocument.Id > 0 ? _currentDocument.Id : 0;

                    _currentDocument = Task.Run(async () =>
                    {
                        if (docIdToDelete > 0)
                        {
                            await documentService.DeleteDocumentAsync(docIdToDelete);
                        }
                        return await documentService.UploadDocumentAsync(dto);
                    }).GetAwaiter().GetResult();
                }
            }
            _isDirty = false;
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
            OnDirtyChanged?.Invoke(this, EventArgs.Empty);
            
            if (!_isLoading)
            {
                pictureEdit1.IsModified = true;
            }
        }

        private void tsmResimSec_Click(object sender, EventArgs e)
        {
            pictureEdit1.ResimSec();
        }

        private void tsmKameradanCek_Click(object sender, EventArgs e)
        {
            pictureEdit1.ShowTakePictureDialog();
        }

        private void tsmResmiBuyut_Click(object sender, EventArgs e)
        {
            pictureEdit1.ResimBuyut();
        }

        private void tsmResmiIndir_Click(object sender, EventArgs e)
        {
            pictureEdit1.ResimIndir();
        }

        private void tsmResmiSil_Click(object sender, EventArgs e)
        {
            pictureEdit1.ResimSil();
        }

        public void SetReadOnly(bool isReadOnly)
        {
            if (tsmResimSec != null) tsmResimSec.Enabled = !isReadOnly;
            if (tsmKameradanCek != null) tsmKameradanCek.Enabled = !isReadOnly;
            if (tsmResmiSil != null) tsmResmiSil.Enabled = !isReadOnly;
        }
    }
}

