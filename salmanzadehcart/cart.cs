using CardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salmanzadehcart
{
    public partial class cart : MetroFramework.Forms.MetroForm
    {
        DatasalmanzadehlinqDataContext db = new DatasalmanzadehlinqDataContext();
        bool initOk = false;
        string devicePort = "";
        bool autoOK = false;
        CardReader.CardManagerLib crdmanager;
        public long ReadedNationalID = 0;
        public int ReadedCardSerial = 0;
        public long ReadedID = 0;

       
       


        public cart()
        {
           
            crdmanager = new CardReader.CardManagerLib();
            InitializeComponent();
        }
        string[] lines = System.IO.File.ReadAllLines("ifd.ini");

        bool getCardInfo()
        {

            using (var form = new load(lines[0]))
            {
                form.ID = 0;

                form.ShowDialog();
                MifareAPI.MF_ExitComm();
                if (form.DialogResult == DialogResult.Abort)
                {
                    MifareAPI.MF_InitComm(devicePort, 9600);
                    MifareAPI.beepForDeny();
                    MifareAPI.beepForDeny();
                    MifareAPI.MF_ExitComm();
                    
                    return GoForinvatation();
                }
                if (form.DialogResult == DialogResult.Cancel)
                {
                    ClearInfo();
                    return false;
                }


                if (!form.Error)
                {
                    ReadedID = form.ID;
                    var f = db.Tableinserts.FirstOrDefault(x => x.id == ReadedID);
                    try
                    {

                        if (f != null)
                        {
                            label1.Text = (f.id).ToString();
                            label2.Text = f.firstname;
                            label15.Text = f.lastname;
                            label3.Text = f.fame;
                            label4.Text = f.Nickname;
                            label5.Text = f.typeclass;
                            label6.Text = f.post;
                            label7.Text = f.timeclass;
                            label8.Text = f.Training;
                            label9.Text = f.job;
                            label10.Text = (f.hight).ToString();
                            label11.Text = (f.Weight).ToString();
                            label12.Text = f.Facilities;
                            label13.Text = f.Degree;
                            label14.Text = f.Blood;
                            label12.Text = f.Eye;
                            label13.Text = f.Records;
                            label14.Text = f.datalogin;
                            label32.Text = "";
                            int day = int.Parse(DateTime.Now.ToPeString("dd"));
                            if (f.mony=="No"&& day <= 25)
                            {
                                welcom.Text = "شما شهریه را پرداخت نکردید";
                                MifareAPI.beepForDenylong();
                                
                            }
                           
                            if (day>25 && day<31)
                            {
                                if (f.mony == "No")
                                {
                                    welcom.Text = " شما همچنان شهریه را پرداخت نکردید";
                                    MifareAPI.beepForDenylong();

                                }
                                else
                                {
                                    int r = 30 - day;
                                    label32.Text = r+"روز فرصت دارید تا به باشگاه تسویه حساب کنید";
                                    MifareAPI.beepForDeny();
                                }
                             
                            }
                           
                            if (f.active == 1)
                            {
                                f.active = 0;
                                welcom.Text = "خدا نگهدارتان";

                            }
                            else
                            {
                                if (f.mony == "yes")
                                {
                                    f.active = 1;
                                    welcom.Text = "به باشگاه هنر های رزمی استاد سید محمد سلمان زاده خوش امدید";
                                    if (f.num == null)
                                    {
                                        f.num = 1;
                                    }
                                    else
                                    {
                                        f.num = f.num + 1;
                                    }
                                }
                            }

                            db.SubmitChanges();
                            label31.Text = (f.num).ToString();
                            note.Text = f.note;
                            pictureBox1.ImageLocation = f.imge;
                            

                        }

                    }
                    catch
                    {

                        MetroFramework.MetroMessageBox.Show(this, "دوباره تلاش کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
             
                return getCardInfo();
            }
        }







        private void cart_Load(object sender, EventArgs e)
        {
        }

      
        bool GoForinvatation()
        {
            return  getCardInfo();

        }

        delegate void CloseMethod(Form form);
        static private void CloseForm(Form form)
        {
            if (!form.IsDisposed)
            {
                if (form.InvokeRequired)
                {
                    CloseMethod method = new CloseMethod(CloseForm);
                    form.Invoke(method, new object[] { form });
                }
                else
                {
                    form.Close();
                }
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        void ClearInfo()
        {

            label1.Text = "";
            label2.Text = "";
            label15.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label31.Text = "";
            note.Text = "";
            pictureBox1.ImageLocation = "";
        }

        private void پذیرشخودکارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoOK = true;

            if (toolStripButton2.Text == "شروع پذیرش")
            {
                toolStripButton2.Text = "پایان پذیرش";
            }
            GoForinvatation();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            string msg = "طراح و برنامه نویس:سید امیر حسین میرنیا\r\n";
            msg += "استاد راهنما:مهندس میرزاییان\r\n ";
            msg += "تلفن:09114596785";
            MetroFramework.MetroMessageBox.Show(this, msg, "معرفی", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
