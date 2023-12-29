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
    public partial class mony : MetroFramework.Forms.MetroForm
    {
        DatasalmanzadehlinqDataContext db = new DatasalmanzadehlinqDataContext();

        public mony(long Id)
        {
            InitializeComponent();
            var cm = db.Tableinserts.FirstOrDefault(x=>x.id==Id);
            idtext.Text = (Id).ToString();
            if (cm.mony=="No")
            {
                textBox1.AppendText(cm.firstname + "-" + cm.lastname + "بدهکار است" + "\r\n");

            }
            else
            {
                textBox1.AppendText(cm.firstname + "-" + cm.lastname + "شهریه را پرداخت کرد" + "\r\n");

            }
        }
       
     
        private void mony_Load(object sender, EventArgs e)
        {
           
        }

       

        private void falsecash_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idtext.Text);
            var cm = db.Tableinserts.FirstOrDefault(x => x.id == id);

            if (MetroFramework.MetroMessageBox.Show(this, "ایا از لغو پرداخت " + "." + cm.firstname + "-" + cm.lastname + "." + "مطمین هستید؟", "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cm.mony = "No";
                textBox1.AppendText("بدهکاری"+"\t" + cm.firstname + "-" + cm.lastname+" ثبت شد" + "\r\n");
                db.SubmitChanges();


            }
        }

        private void truecash_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idtext.Text);
            var cm = db.Tableinserts.FirstOrDefault(x => x.id == id);     

            if (MetroFramework.MetroMessageBox.Show(this, "ایا از پرداخت " + "." + cm.firstname + "-" + cm.lastname +"."+ "مطمین هستید؟" , "تایید", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                cm.mony = "yes";
                textBox1.AppendText(cm.firstname + "-" + cm.lastname + "شهریه را پرداخت کرد" + "\r\n");
                db.SubmitChanges();

            }
        }
    }
}
