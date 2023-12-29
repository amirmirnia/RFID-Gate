namespace salmanzadehcart
{
    partial class seting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(seting));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.com = new System.Windows.Forms.ComboBox();
            this.imge = new MetroFramework.Controls.MetroButton();
            this.relav = new MetroFramework.Controls.MetroButton();
            this.refresh = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 166);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(692, 368);
            this.textBox1.TabIndex = 0;
            // 
            // com
            // 
            this.com.FormattingEnabled = true;
            this.com.Items.AddRange(new object[] {
            "USB",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.com.Location = new System.Drawing.Point(15, 94);
            this.com.Margin = new System.Windows.Forms.Padding(4);
            this.com.Name = "com";
            this.com.Size = new System.Drawing.Size(169, 32);
            this.com.TabIndex = 14;
            // 
            // imge
            // 
            this.imge.Location = new System.Drawing.Point(208, 94);
            this.imge.Margin = new System.Windows.Forms.Padding(4);
            this.imge.Name = "imge";
            this.imge.Size = new System.Drawing.Size(102, 63);
            this.imge.TabIndex = 15;
            this.imge.Text = "تست";
            this.imge.UseSelectable = true;
            this.imge.Click += new System.EventHandler(this.imge_Click);
            // 
            // relav
            // 
            this.relav.Location = new System.Drawing.Point(341, 94);
            this.relav.Margin = new System.Windows.Forms.Padding(4);
            this.relav.Name = "relav";
            this.relav.Size = new System.Drawing.Size(102, 63);
            this.relav.TabIndex = 16;
            this.relav.Text = "ثبت تنظیمات";
            this.relav.UseSelectable = true;
            this.relav.Click += new System.EventHandler(this.relav_Click);
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refresh.BackgroundImage")));
            this.refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refresh.Location = new System.Drawing.Point(645, 94);
            this.refresh.Margin = new System.Windows.Forms.Padding(4);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(34, 36);
            this.refresh.TabIndex = 17;
            this.refresh.UseSelectable = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // seting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 532);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.relav);
            this.Controls.Add(this.imge);
            this.Controls.Add(this.com);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "seting";
            this.Padding = new System.Windows.Forms.Padding(28, 90, 28, 30);
            this.Resizable = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "تنظیمات";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.seting_FormClosing);
            this.Load += new System.EventHandler(this.seting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox com;
        private MetroFramework.Controls.MetroButton imge;
        private MetroFramework.Controls.MetroButton relav;
        private MetroFramework.Controls.MetroButton refresh;
    }
}