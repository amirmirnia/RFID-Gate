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
    public partial class seting : MetroFramework.Forms.MetroForm
    {
        
        public seting()
        {

            InitializeComponent();
        }
        bool initOk = false;
        private void seting_Load(object sender, EventArgs e)
        {
            relav.Enabled = false;
        }

        private void imge_Click(object sender, EventArgs e)
        {

            try
            {
                if (MifareAPI.MF_InitComm(com.Text, 9600) == 0)
                {
                    byte[] devVer = new byte[32];
                    if (MifareAPI.MF_GetDevice_Ver(0, ref devVer[0]) == 0)
                    {
                        initOk = true;
                        textBox1.AppendText("\r\nارتباط با دستگاه برقرار شده");
                        MifareAPI.beepForOK();
                        
                        relav.Enabled = true;
                        com.Enabled = false;
                    }
                }
            }
            catch
            {
                textBox1.AppendText("\r\nارتباط با دستگاه برقرار نشده");
                textBox1.AppendText("\r\nلطفا نوع پورت را تغییر دهید");
            }
        }

        private void relav_Click(object sender, EventArgs e)
        {
            string[] arg = new string[1] { com.Text, };
            System.IO.File.WriteAllLines("ifd.ini", arg);
            textBox1.AppendText("\r\nتنظیمات جهت استفاده برنامه ذخیره شده است");
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void seting_FormClosing(object sender, FormClosingEventArgs e)
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
