using CardLib;
using CardReader;
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
    public partial class insertcard : MetroFramework.Forms.MetroForm
    {
        public bool updateneeded = false;
        //CardReader.CardManagerLib crdmanager;
        bool initOk = false;
        DatasalmanzadehlinqDataContext db = new DatasalmanzadehlinqDataContext();
        public insertcard(long id)
        {
            // crdmanager = new CardReader.CardManagerLib();
            InitializeComponent();
            idcode.Text = (id).ToString();
        }

        private void insertcard_Load(object sender, EventArgs e)
        {
            var fm = db.Tableinserts.FirstOrDefault(x => x.id == int.Parse(idcode.Text));
            if (fm.card==1)
            {
                rejistercard.Enabled = false;
            }
            else
            {
                metroButton1.Enabled = false;
            }
            try
            {
                string[] lines = System.IO.File.ReadAllLines("ifd.ini");
                if (MifareAPI.MF_InitComm(lines[0], 9600) == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "پورت " + lines[0] + " انتخاب شده و اتصال با دستگاه برقرار است", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initOk = true;
                }

            }
            catch
            {
                string msg = "خطای تنظیمات\r\n";
                msg += "تنظیمات ارتباط با دستگاه کارتخوان ذخیره نشده";

                MetroFramework.MetroMessageBox.Show(this, msg, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void inset_Click(object sender, EventArgs e)
        {
            textseaarch.Text = "";
            if (initOk)
            {
                var crdmanager = new CardReader.CardManagerLib();
                if (MifareAPI.MF_Request(0, 0, ref crdmanager.cardT[0]) == 0)
                {
                    if (MifareAPI.MF_Anticoll(0, ref crdmanager.cardSN[0]) == 0)
                    {
                        if (MifareAPI.MF_Select(0, ref crdmanager.cardSN[0]) == 0)
                        {
                            long ID, NationalID;

                            if (crdmanager.ReadCardInfo(out ID, out NationalID))
                            {

                                var gm = db.Tableinserts.FirstOrDefault(x => x.id == NationalID);
                                if (gm!=null)
                                {
                                    MifareAPI.beepForOK();


                                    textseaarch.Text = gm.firstname + "-" + gm.lastname;
                                }
                                else
                                {
                                    MifareAPI.beepForDeny();
                                    textseaarch.Text ="کاربر این کارت از سیستم حذف شد";

                                }


                            }
                            else
                            {
                                MifareAPI.beepForDeny();
                                textseaarch.Text = "کارت غیر معتبر است";

                            }


                        }
                    }
                }
                else
                {
                    MifareAPI.beepForDeny();
                    MetroFramework.MetroMessageBox.Show(this, "کارت را مجاور دستگاه قرار دهید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }




        private void idcode_Leave(object sender, EventArgs e)
        {

        }


        private void rejistercard_Click(object sender, EventArgs e)
        {

            try
            {
                long NID;//---------
                if (long.TryParse(idcode.Text, out NID))//long
                {
                    var cm = db.Tableinserts.FirstOrDefault(x => x.id == NID);//-------
                    if (cm.card == 0)
                    {



                        if (initOk)
                        {
                            var crdmanager = new CardReader.CardManagerLib();
                            if (MifareAPI.MF_Request(0, 0, ref crdmanager.cardT[0]) == 0)
                            {
                                if (MifareAPI.MF_Anticoll(0, ref crdmanager.cardSN[0]) == 0)
                                {
                                    if (MifareAPI.MF_Select(0, ref crdmanager.cardSN[0]) == 0)
                                    {
                                        byte[] sector0;

                                        if (cm != null)
                                        {
                                            if (crdmanager.ActivateRawCardX(out sector0, NID))//---------
                                            {
                                                MifareAPI.beepForOK();
                                                updateneeded = true;

                                                MetroFramework.MetroMessageBox.Show(this, "کارت فعال شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                cm.card = 1;
                                                db.SubmitChanges();
                                            }
                                            else
                                            {
                                                MifareAPI.beepForDeny();
                                                MetroFramework.MetroMessageBox.Show(this, "ثبت و فعال سازی ناموفق ، کارت حاوی اطلاعات است", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                            }

                                        }
                                        else
                                        {
                                            MetroFramework.MetroMessageBox.Show(this, "چنین کد ملی ثبت نشد در سیستم تا کارت صادر شود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        }

                                    }
                                }
                            }
                            else
                            {
                                MifareAPI.beepForDeny();
                                MetroFramework.MetroMessageBox.Show(this, "کارت را مجاور دستگاه قرار دهید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "شخص با کد ملی وارد شده قبلا کارت یرایش صادر شد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        idcode.Text = "";

                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "کدملی را درست وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch 
            {

                MetroFramework.MetroMessageBox.Show(this, "در وارد کردن کد ملی دقت کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroFramework.MetroMessageBox.Show(this, "با رسیت کردن کارت اطلاعات آن از بین میرود. ایا مطمئن هستید؟", "تایید ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (initOk)
                    {
                        var crdmanager = new CardReader.CardManagerLib();
                        if (MifareAPI.MF_Request(0, 0, ref crdmanager.cardT[0]) == 0)
                        {
                            if (MifareAPI.MF_Anticoll(0, ref crdmanager.cardSN[0]) == 0)
                            {
                                if (MifareAPI.MF_Select(0, ref crdmanager.cardSN[0]) == 0)
                                {
                                    long ID, NationalID;
                                    crdmanager.ReadCardInfo(out ID, out NationalID);
                                    if (crdmanager.ResetCard())
                                    {

                                        //textBox1.AppendText(string.Format("writing done for {0} block", block));
                                        MifareAPI.beepForOK();
                                        MetroFramework.MetroMessageBox.Show(this, "کارت ریست شد", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        var dm = db.Tableinserts.FirstOrDefault(x => x.id == ID);
                                        if (dm!=null)
                                        {
                                            dm.card = 0;
                                            db.SubmitChanges();
                                        }
                                        else
                                        {
                                            MetroFramework.MetroMessageBox.Show(this, "کارت ریست شدولی صاحب این کارت قبلا از سیستم جذف شده بود", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        }
                                    }
                                    else
                                    {
                                        MifareAPI.beepForDeny();
                                        MetroFramework.MetroMessageBox.Show(this, "ریست ناموفق ، لطفا مجددا امتحان کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }

                                }
                            }
                        }
                        else
                        {
                            MifareAPI.beepForDeny();
                            MetroFramework.MetroMessageBox.Show(this, "کارت را مجاور دستگاه قرار دهید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch 
            {

                MetroFramework.MetroMessageBox.Show(this, "مشکل پایگاه داده", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "ایا با حذف کارت کاربر مشخص اطمینان دارید", "تایید ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                long NID;//---------
                if (long.TryParse(idcode.Text, out NID))//long
                {
                    var cm = db.Tableinserts.FirstOrDefault(x => x.id == NID);//-------
                    if (cm!=null)
                    {
                        if (cm.card == 0)
                        {
                            MetroFramework.MetroMessageBox.Show(this, "این کاربر از قبل دارای کارت نبود", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            cm.card = 0;
                            db.SubmitChanges();
                            MetroFramework.MetroMessageBox.Show(this, "می توانید برای کاربر خود کارت جدید صادر نمایید", "تایید", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "چنین کاربری با کد ملی وجود ندارد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "کدملی را درست وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines("ifd.ini");
                if (MifareAPI.MF_InitComm(lines[0], 9600) == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "پورت " + lines[0] + " انتخاب شده و اتصال با دستگاه برقرار است", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    initOk = true;
                }

            }
            catch
            {
                string msg = "خطای تنظیمات\r\n";
                msg += "تنظیمات ارتباط با دستگاه کارتخوان ذخیره نشده";

                MetroFramework.MetroMessageBox.Show(this, msg, "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void insertcard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (initOk)
            {
                if (MifareAPI.MF_ExitComm() == 0)
                {

                }

            }
        }
    }
}
