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
    public partial class seleckpage : MetroFramework.Forms.MetroForm
    {
        public seleckpage(long id)
        {
            InitializeComponent();
            textBox1.AppendText("" + id);
        }

        private void seleckpage_Load(object sender, EventArgs e)
        {
           
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            long id = int.Parse(textBox1.Text);
            mony mo = new mony(id);
            mo.ShowDialog();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            long id = int.Parse(textBox1.Text);
            insertcard mo = new insertcard(id);
            mo.ShowDialog();

        }
    }
}
