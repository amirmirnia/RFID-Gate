using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewPrinter;

namespace salmanzadehcart
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {

            DatasalmanzadehlinqDataContext db = new DatasalmanzadehlinqDataContext();
            listgrag.DataSource = db.Tableinserts.ToList();

        }

        private void inset_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DGVPrinter printer = new DGVPrinter();
                printer.CellAlignment = StringAlignment.Center;
                printer.CellFormatFlags = StringFormatFlags.DirectionRightToLeft;

                printer.PageNumbers = true;
                printer.PageNumberAlignment = StringAlignment.Center;

                printer.HeaderCellAlignment = StringAlignment.Center;
                printer.HeaderCellFormatFlags = StringFormatFlags.DirectionRightToLeft;

                printer.PorportionalColumns = true;

                printer.Title = "افراد عضو باشگاه";
                printer.TitleAlignment = StringAlignment.Center;
                printer.TitleColor = Color.Red;
                printer.TitleFont = new Font("B Zar", 24);
                printer.TitleFormatFlags = StringFormatFlags.DirectionRightToLeft;

                printer.PrintPreviewDataGridView(listgrag);
                this.Cursor = Cursors.Default;
            }
            catch
            {

                MetroFramework.MetroMessageBox.Show(this, "مشکل در اتصال پرینتر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
