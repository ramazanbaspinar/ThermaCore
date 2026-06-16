#pragma warning disable CS8618
using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace ThermaCore.Presentation.WinForms.UserControls
{
    [ToolboxItem(true)]
    public class MyDataLayoutControl : DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false;
            AllowCustomization = false;
        }
        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(this);
        }

        private class MyLayoutControlImplementor : LayoutControlImplementor
        {
            public MyLayoutControlImplementor(ILayoutControlOwner controlOwner) : base(controlOwner)
            {
            }

            public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
            {
                var item = base.CreateLayoutItem(parent);
                // item.AppearanceItemCaption.ForeColor = Color.Maroon;
                item.AppearanceItemCaption.Font = new Font("Segoe UI", 9f);
                return item;
            }
            public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
            {
                var grp = base.CreateLayoutGroup(parent);
                grp.LayoutMode = LayoutMode.Table;

                grp.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = SizeType.Absolute;
                grp.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;
                grp.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = SizeType.Percent;
                grp.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;
                grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition { SizeType = SizeType.Absolute, Width = 99 });

                grp.OptionsTableLayoutGroup.RowDefinitions.Clear();

                for (int i = 0; i < 9; i++)
                {
                    grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                    {
                        SizeType = SizeType.Absolute,
                        Height = 31,
                    });

                    if (i + 1 != 9) continue;
                    grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                    {
                        SizeType = SizeType.Percent,
                        Height = 100
                    });
                }

                return grp;
            }
        }
    }
}

