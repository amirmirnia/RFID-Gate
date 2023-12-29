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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           

        }

        private void inset_Click(object sender, EventArgs e)
        {
            insert insert = new insert();
            insert.Show();
        }

        private void editinfo_Click(object sender, EventArgs e)
        {
            insert insert = new insert();
            insert.Show();
        }

        private void information_Click(object sender, EventArgs e)
        {
            tableuser tableuser = new tableuser();
            tableuser.Show();
        }

        private void Authentication_Click(object sender, EventArgs e)
        {
            cart cart = new cart();
            cart.Show();
        }

        //private void insertcard_Click(object sender, EventArgs e)
        //{
        //    insertcard card = new insertcard();
        //    card.Show();
        //}

        private void metroButton1_Click(object sender, EventArgs e)
        {
            seting seting = new seting();
            seting.Show();
        }

        private void list_Click(object sender, EventArgs e)
        {
            list list = new list();
            list.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Form2 list = new Form2();
            list.Show();
        }
    }
}
