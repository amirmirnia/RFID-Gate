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
    public partial class tableuser : MetroFramework.Forms.MetroForm
    {
        DatasalmanzadehlinqDataContext db = new DatasalmanzadehlinqDataContext();
        Tableinsert cm = new Tableinsert();

        public tableuser()
        {
           
            InitializeComponent();
        }

        private void tableuser_Load(object sender, EventArgs e)
        {


            metroGriduser.DataSource = db.Tableinserts.ToList();


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (lastname.Text!=null)
            {
                metroGriduser.DataSource = db.Tableinserts.Where(x => x.lastname == lastname.Text).ToList();

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "نام خانوادگی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lastname_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }

        private void boold_Click(object sender, EventArgs e)
        {
            if (time.Text != null)
            {
                metroGriduser.DataSource = db.Tableinserts.Where(x => x.timeclass == time.Text).ToList();

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "زمان را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (belt.Text != null)
            {
                metroGriduser.DataSource = db.Tableinserts.Where(x => x.Degree == belt.Text).ToList();

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "درجه کمربند را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text != null)
            {
                double num;
                if (double.TryParse(metroTextBox1.Text, out num))
                {
                    metroGriduser.DataSource = db.Tableinserts.Where(x => x.Records == metroTextBox1.Text).ToList();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "شماره پرونده را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "شماره پرونده را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void metroTextBox1_Leave(object sender, EventArgs e)
        {
          

            
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (metroTextBox2.Text != null)
            {
                double num;
                if (double.TryParse(metroTextBox2.Text, out num))
                {

                    var ch = db.Tableinserts.FirstOrDefault(x => x.id == int.Parse(metroTextBox2.Text));
                    if (ch!=null)
                    {
                        db.Tableinserts.DeleteOnSubmit(ch);
                        db.SubmitChanges();
                        MetroFramework.MetroMessageBox.Show(this, "کاربر مورد نظر حذف شد", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        metroGriduser.DataSource = db.Tableinserts.ToList();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "چنین کد ملی وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "کد ملی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "کدملی را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void print_Click(object sender, EventArgs e)
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

                printer.Title = "مشخصات افراد عضو باشگاه";
                printer.TitleAlignment = StringAlignment.Center;
                printer.TitleColor = Color.Red;
                printer.TitleFont = new Font("B Zar", 24);
                printer.TitleFormatFlags = StringFormatFlags.DirectionRightToLeft;

                printer.PrintPreviewDataGridView(metroGriduser);
                this.Cursor = Cursors.Default;
            }
            catch
            {

                MetroFramework.MetroMessageBox.Show(this, "مشکل در اتصال پرینتر", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroGriduser_DoubleClick(object sender, EventArgs e)
        {
            //if (metroGriduser.SelectedRows.Count != 1)
            //    return;
            //else
            //{



            long Id = Convert.ToInt64(metroGriduser.SelectedRows[0].Cells[0].Value);
            {
                var from = new seleckpage(Id);
                from.ShowDialog();

            }
            //}
        }

        private void metroGriduser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //long Id = long.Parse(metroGriduser[e.ColumnIndex, e.RowIndex].Value.ToString());
            //var from = new mony(Id);
            //from.ShowDialog();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroGriduser.DataSource = db.Tableinserts.Where(x => x.mony == "No").ToList();

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            metroGriduser.DataSource = db.Tableinserts.ToList();

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            foreach (var item in db.Tableinserts)
            {
                item.mony = "No";
                db.SubmitChanges();
            }
            metroGriduser.DataSource = db.Tableinserts.ToList();

        }
    }
}
