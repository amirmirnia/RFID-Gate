using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salmanzadehcart
{
    public partial class insert : MetroFramework.Forms.MetroForm
    {
        DatasalmanzadehlinqDataContext db = new DatasalmanzadehlinqDataContext();
        Tableinsert cm = new Tableinsert();

        public insert()
        {
            InitializeComponent();
        }

        private void insert_Load(object sender, EventArgs e)
        {
            change.Hide();

            data.Text = DateTime.Now.ToPeString("dddd, dd MMMM,yyyy");


        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void imge_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imge.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

            }
        }
        private void insertbotom_Click(object sender, EventArgs e)
        {
            var r = db.Tableinserts.FirstOrDefault(x => x.Records == Records.Text);
            if (r == null)
            {
                if (codeid.Text == "" || firstname.Text == "" || fame.Text == "" || Nickname.Text == "" || typeclass.Text == "" || post.Text == "" || Training.Text == "" || timeclass.Text == "" || job.Text == "" || Weight.Text == "" || hight.Text == "" || Facilities.Text == "" || Eye.Text == "" || note.Text == "" || Records.Text == "" || data.Text == "")

                {
                    MetroFramework.MetroMessageBox.Show(this, "تمام اطلاعات را کامل کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    cm.active = 0;
                    cm.id = int.Parse(codeid.Text);
                    cm.firstname = firstname.Text;
                    cm.lastname = lastname.Text;
                    cm.fame = fame.Text;
                    cm.Nickname = Nickname.Text;
                    cm.typeclass = typeclass.Text;
                    cm.post = post.Text;
                    cm.Training = Training.Text;
                    cm.timeclass = timeclass.Text;
                    cm.job = job.Text;
                    cm.Weight = int.Parse(Weight.Text);
                    cm.hight = int.Parse(hight.Text);
                    cm.Facilities = Facilities.Text;
                    cm.Degree = Degree.Text;
                    cm.Blood = Blood.Text;
                    cm.Eye = Eye.Text;
                    cm.note = note.Text;
                    cm.Records = Records.Text;
                    cm.card = 0;
                    cm.num = 0;
                    cm.mony = "No";
                    cm.datalogin = data.Text;
                    if (imge.Text != "عکس پروفایل")
                    {
                        //string ma = Environment.MachineName;
                        //System.IO.Directory.CreateDirectory(@"C:\Users\" + ma + @"\Pictures\salmanzadehfightclub");
                        pictureBox1.Image.Save(imge.Text);
                        cm.imge = imge.Text;
                    }
                    
                    db.Tableinserts.InsertOnSubmit(cm);
                    db.SubmitChanges();
                    MetroFramework.MetroMessageBox.Show(this, "ثبت شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    codeid.Text = "";
                    firstname.Text = "";
                    lastname.Text = "";
                    fame.Text = "";
                    Nickname.Text = "";
                    typeclass.Text = "";
                    post.Text = "";
                    Training.Text = "";
                    timeclass.Text = "";
                    job.Text = "";
                    Weight.Text = "";
                    hight.Text = "";
                    Facilities.Text = "";
                    Degree.Text = "";
                    Blood.Text = "";
                    Eye.Text = "";
                    note.Text = "";
                    Records.Text = "";
                    data.Text = "";
                    pictureBox1.ImageLocation = null;
                    imge.Text = "عکس پروفایل";

                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "چنین شماره پرونده وجود دارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void firstname_Enter(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo fr = new System.Globalization.CultureInfo("fa-IR");
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(fr);
        }

        private void firstname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void dataplace_Click(object sender, EventArgs e)
        {

        }

        private void codeid_Leave(object sender, EventArgs e)
        {

        }

        private void change_Click(object sender, EventArgs e)
        {
            try
            {
                var cm = db.Tableinserts.FirstOrDefault(x => x.id == int.Parse(codeid.Text));
                if (codeid.Text == "" || firstname.Text == "" || fame.Text == "" || Nickname.Text == "" || typeclass.Text == "" || post.Text == "" || Training.Text == "" || timeclass.Text == "" || job.Text == "" || Weight.Text == "" || hight.Text == "" || Facilities.Text == "" || Eye.Text == "" || note.Text == "" || Records.Text == "" || data.Text == "")
                {
                    MetroFramework.MetroMessageBox.Show(this, "تمام اطلاعات را کامل کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    cm.id = int.Parse(codeid.Text);
                    cm.firstname = firstname.Text;
                    cm.lastname = lastname.Text;
                    cm.fame = fame.Text;
                    cm.Nickname = Nickname.Text;
                    cm.typeclass = typeclass.Text;
                    cm.post = post.Text;
                    cm.Training = Training.Text;
                    cm.timeclass = timeclass.Text;
                    cm.job = job.Text;
                    cm.Weight = int.Parse(Weight.Text);
                    cm.hight = int.Parse(hight.Text);
                    cm.Facilities = Facilities.Text;
                    cm.Degree = Degree.Text;
                    cm.Blood = Blood.Text;
                    cm.Eye = Eye.Text;
                    cm.note = note.Text;
                    cm.Records = Records.Text;
                    cm.datalogin = data.Text;
                    if (imge.Text != "عکس پروفایل")
                    {
                        //string ma = Environment.MachineName;
                        pictureBox1.Image.Save(imge.Text);
                        cm.imge = imge.Text;
                    }

                    db.SubmitChanges();
                    MetroFramework.MetroMessageBox.Show(this, "تغیرات انجام شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox1.Checked = false;
                    codeid.Text = "";
                    firstname.Text = "";
                    lastname.Text = "";
                    fame.Text = "";
                    Nickname.Text = "";
                    typeclass.Text = "";
                    post.Text = "";
                    Training.Text = "";
                    timeclass.Text = "";
                    job.Text = "";
                    Weight.Text = "";
                    hight.Text = "";
                    Facilities.Text = "";
                    Degree.Text = "";
                    Blood.Text = "";
                    Eye.Text = "";
                    note.Text = "";
                    Records.Text = "";
                    data.Text = "";
                    pictureBox1.ImageLocation = null;
                    imge.Text = "عکس پروفایل";
                }




            }
            catch
            {

                MetroFramework.MetroMessageBox.Show(this, "کد ملی تغییر نباید بکند", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Records_Leave(object sender, EventArgs e)
        {
            double num;
            if (double.TryParse(codeid.Text, out num))
            {
                var fm = db.Tableinserts.FirstOrDefault(x => x.id == int.Parse(codeid.Text));
                if (fm != null)
                {
                    insertbotom.Hide();
                    change.Show();



                    codeid.Text = (fm.id).ToString();
                    firstname.Text = fm.firstname;
                    lastname.Text = fm.lastname;
                    fame.Text = fm.fame;
                    Nickname.Text = fm.Nickname;
                    typeclass.Text = fm.typeclass;
                    post.Text = fm.post;
                    Training.Text = fm.Training;
                    timeclass.Text = fm.timeclass;
                    job.Text = fm.job;
                    Weight.Text = (fm.Weight).ToString();
                    hight.Text = (fm.hight).ToString();
                    Facilities.Text = fm.Facilities;
                    Degree.Text = fm.Degree;
                    Blood.Text = fm.Blood;
                    Eye.Text = fm.Eye;
                    note.Text = fm.note;
                    Records.Text = fm.Records;
                    data.Text = fm.datalogin;

                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "شماره پرونده را درست وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {

            codeid.Text = "";
            firstname.Text = "";
            lastname.Text = "";
            fame.Text = "";
            checkBox1.Checked = false;
            Nickname.Text = "";
            typeclass.Text = "";
            post.Text = "";
            Training.Text = "";
            timeclass.Text = "";
            job.Text = "";
            Weight.Text = "";
            hight.Text = "";
            Facilities.Text = "";
            Degree.Text = "";
            Blood.Text = "";
            Eye.Text = "";
            note.Text = "";
            Records.Text = "";
            data.Text = "";
            pictureBox1.ImageLocation = null;
            imge.Text = "عکس پروفایل";
            insertbotom.Show();
            change.Hide();
            data.Text = DateTime.Now.ToPeString("dddd, dd MMMM,yyyy");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double num;
                if (double.TryParse(codeid.Text, out num))
                {
                    var fm = db.Tableinserts.FirstOrDefault(x => x.id == int.Parse(codeid.Text));
                    if (fm != null)
                    {
                        insertbotom.Hide();
                        change.Show();



                        codeid.Text = (fm.id).ToString();
                        firstname.Text = fm.firstname;
                        lastname.Text = fm.lastname;
                        fame.Text = fm.fame;
                        Nickname.Text = fm.Nickname;
                        typeclass.Text = fm.typeclass;
                        post.Text = fm.post;
                        Training.Text = fm.Training;
                        timeclass.Text = fm.timeclass;
                        job.Text = fm.job;
                        Weight.Text = (fm.Weight).ToString();
                        hight.Text = (fm.hight).ToString();
                        Facilities.Text = fm.Facilities;
                        Degree.Text = fm.Degree;
                        Blood.Text = fm.Blood;
                        Eye.Text = fm.Eye;
                        note.Text = fm.note;
                        Records.Text = fm.Records;
                        data.Text = fm.datalogin;
                        pictureBox1.ImageLocation = fm.imge;
                    }


                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "کدملی را درست وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBox1.Checked = false;
                }
            }
            catch
            {

                MetroFramework.MetroMessageBox.Show(this, "کدملی را درست وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox1.Checked = false;

            }
        }

        private void Records_Click(object sender, EventArgs e)
        {

        }
    }
}
