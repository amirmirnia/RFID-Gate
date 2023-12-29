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
    public partial class load : MetroFramework.Forms.MetroForm
    {
        CardReader.CardManagerLib crdmanager;
        System.Threading.Thread deviceThread;
        bool initOk = false;
        public bool Error = false;
        string devicePort;
        public string msg = "";
        public long ID = 0;
        public long NationalID =0;
        public load(string deviceport)
        {
            crdmanager = new CardReader.CardManagerLib();
            this.devicePort = deviceport;
            InitializeComponent();
        }


        private void CheckForcards()
        {
            //while (true)
            //{
            //    try
            //    {
            //        if (initOk)

            //            if (MifareAPI.MF_Request(0, 0, ref crdmanager.cardT[0]) == 0)
            //                if (MifareAPI.MF_Anticoll(0, ref crdmanager.cardSN[0]) == 0)
            //                    if (MifareAPI.MF_Select(0, ref crdmanager.cardSN[0]) == 0)
            //                    {
            //                        long ID, NationalID;

            //                        if (crdmanager.ReadCardInfo(out ID, out NationalID))
            //                        {
            //                            if (ID != -1)
            //                            {
            //                                MifareAPI.beepForOK();
            //                                salmanzadehcart.cart.getid(ID);
            //                            }

            //                            else
            //                            {
            //                                return;
            //                            }

            //                        }
            //                        else
            //                        {
            //                            return;

            //                        }
            //                        //CloseForm(this);
            //                    }
            //    }
            //    catch
            //    {

            //    }
            //}



            while (true)
            {
                try
                {
                    if (initOk)
                        if (MifareAPI.MF_Request(0, 0, ref crdmanager.cardT[0]) == 0)
                            if (MifareAPI.MF_Anticoll(0, ref crdmanager.cardSN[0]) == 0)
                                if (MifareAPI.MF_Select(0, ref crdmanager.cardSN[0]) == 0)
                                {
                                    if (crdmanager.ReadCardInfo(out ID, out NationalID))
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        msg = "کارت غیر معتبر می باشد";
                                        Error = true;


                                    }
                                    CloseForm(this);
                                }
                }
                catch (Exception ex)
                {

                }
            }





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




        private void load_Load(object sender, EventArgs e)
        {
           
        
            if (MifareAPI.MF_InitComm(devicePort, 9600) == 0)
            {
                initOk = true;
                deviceThread = new System.Threading.Thread(CheckForcards);
                deviceThread.IsBackground = true;
                MifareAPI.beepForOK();
                deviceThread.Start();
            }
        }

        private void load_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ID == -1)
                this.DialogResult = DialogResult.Abort;
            deviceThread.Abort();
        }

       
    }
}
