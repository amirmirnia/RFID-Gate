namespace salmanzadehcart
{
    partial class insertcard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(insertcard));
            this.label2 = new System.Windows.Forms.Label();
            this.textseaarch = new System.Windows.Forms.TextBox();
            this.idcode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inset = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.rejistercard = new MetroFramework.Controls.MetroButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.reset = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(199, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "کد ملی";
            // 
            // textseaarch
            // 
            this.textseaarch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textseaarch.Location = new System.Drawing.Point(6, 24);
            this.textseaarch.Multiline = true;
            this.textseaarch.Name = "textseaarch";
            this.textseaarch.ReadOnly = true;
            this.textseaarch.Size = new System.Drawing.Size(249, 131);
            this.textseaarch.TabIndex = 5;
            // 
            // idcode
            // 
            this.idcode.Location = new System.Drawing.Point(6, 24);
            this.idcode.Multiline = true;
            this.idcode.Name = "idcode";
            this.idcode.ReadOnly = true;
            this.idcode.Size = new System.Drawing.Size(187, 32);
            this.idcode.TabIndex = 7;
            this.idcode.Leave += new System.EventHandler(this.idcode_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textseaarch);
            this.groupBox1.Controls.Add(this.inset);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(8, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(264, 253);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // inset
            // 
            this.inset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("inset.BackgroundImage")));
            this.inset.ForeColor = System.Drawing.Color.Black;
            this.inset.Highlight = true;
            this.inset.Location = new System.Drawing.Point(6, 163);
            this.inset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inset.Name = "inset";
            this.inset.Size = new System.Drawing.Size(249, 78);
            this.inset.TabIndex = 2;
            this.inset.Text = "جستجو";
            this.inset.UseCustomForeColor = true;
            this.inset.UseSelectable = true;
            this.inset.Click += new System.EventHandler(this.inset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.metroButton1);
            this.groupBox2.Controls.Add(this.idcode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rejistercard);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox2.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox2.Location = new System.Drawing.Point(8, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(264, 153);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ثبت کارت";
            // 
            // metroButton1
            // 
            this.metroButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton1.BackgroundImage")));
            this.metroButton1.ForeColor = System.Drawing.Color.Black;
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(6, 68);
            this.metroButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(122, 78);
            this.metroButton1.TabIndex = 14;
            this.metroButton1.Text = "حذف کارت کاربر";
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // rejistercard
            // 
            this.rejistercard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rejistercard.BackgroundImage")));
            this.rejistercard.ForeColor = System.Drawing.Color.Black;
            this.rejistercard.Highlight = true;
            this.rejistercard.Location = new System.Drawing.Point(134, 68);
            this.rejistercard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rejistercard.Name = "rejistercard";
            this.rejistercard.Size = new System.Drawing.Size(121, 78);
            this.rejistercard.TabIndex = 8;
            this.rejistercard.Text = "ثبت کارت";
            this.rejistercard.UseCustomForeColor = true;
            this.rejistercard.UseSelectable = true;
            this.rejistercard.Click += new System.EventHandler(this.rejistercard_Click);
            // 
            // reset
            // 
            this.reset.ForeColor = System.Drawing.Color.Black;
            this.reset.Highlight = true;
            this.reset.Location = new System.Drawing.Point(8, 513);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(264, 99);
            this.reset.TabIndex = 11;
            this.reset.Text = "برای ریست کردن کارت را مجاور دستگاه قرار دهید";
            this.reset.UseCustomForeColor = true;
            this.reset.UseSelectable = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(396, 118);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 396);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(168, 23);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 41);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // insertcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 638);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reset);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "insertcard";
            this.Padding = new System.Windows.Forms.Padding(20, 68, 20, 22);
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "تنظیمات کارت";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.insertcard_FormClosing);
            this.Load += new System.EventHandler(this.insertcard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton inset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textseaarch;
        private System.Windows.Forms.TextBox idcode;
        private MetroFramework.Controls.MetroButton rejistercard;
        private MetroFramework.Controls.MetroButton reset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}