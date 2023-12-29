namespace salmanzadehcart
{
    partial class mony
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.falsecash = new MetroFramework.Controls.MetroButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.truecash = new MetroFramework.Controls.MetroButton();
            this.idtext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // falsecash
            // 
            this.falsecash.Location = new System.Drawing.Point(145, 73);
            this.falsecash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.falsecash.Name = "falsecash";
            this.falsecash.Size = new System.Drawing.Size(112, 75);
            this.falsecash.TabIndex = 6;
            this.falsecash.Text = "لغو پرداخت";
            this.falsecash.UseSelectable = true;
            this.falsecash.Click += new System.EventHandler(this.falsecash_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 194);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(696, 368);
            this.textBox1.TabIndex = 8;
            // 
            // truecash
            // 
            this.truecash.Location = new System.Drawing.Point(15, 73);
            this.truecash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.truecash.Name = "truecash";
            this.truecash.Size = new System.Drawing.Size(112, 75);
            this.truecash.TabIndex = 9;
            this.truecash.Text = "تایید پرداخت";
            this.truecash.UseSelectable = true;
            this.truecash.Click += new System.EventHandler(this.truecash_Click);
            // 
            // idtext
            // 
            this.idtext.Location = new System.Drawing.Point(15, 155);
            this.idtext.Name = "idtext";
            this.idtext.ReadOnly = true;
            this.idtext.Size = new System.Drawing.Size(242, 32);
            this.idtext.TabIndex = 10;
            // 
            // mony
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 562);
            this.Controls.Add(this.idtext);
            this.Controls.Add(this.truecash);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.falsecash);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mony";
            this.Padding = new System.Windows.Forms.Padding(28, 90, 28, 30);
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "شهریه";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.mony_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton falsecash;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroButton truecash;
        private System.Windows.Forms.TextBox idtext;
    }
}