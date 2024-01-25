namespace CursovayaDB
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.AppNameLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.whatToDoLabel = new System.Windows.Forms.Label();
            this.keysPicture = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.keysPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginLabel
            // 
            resources.ApplyResources(this.LoginLabel, "LoginLabel");
            this.LoginLabel.Name = "LoginLabel";
            // 
            // PasswordLabel
            // 
            resources.ApplyResources(this.PasswordLabel, "PasswordLabel");
            this.PasswordLabel.Name = "PasswordLabel";
            // 
            // LoginTB
            // 
            resources.ApplyResources(this.LoginTB, "LoginTB");
            this.LoginTB.Name = "LoginTB";
            // 
            // PasswordTB
            // 
            resources.ApplyResources(this.PasswordTB, "PasswordTB");
            this.PasswordTB.Name = "PasswordTB";
            // 
            // LoginBtn
            // 
            resources.ApplyResources(this.LoginBtn, "LoginBtn");
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // ExitBtn
            // 
            resources.ApplyResources(this.ExitBtn, "ExitBtn");
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // AppNameLabel
            // 
            resources.ApplyResources(this.AppNameLabel, "AppNameLabel");
            this.AppNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AppNameLabel.Name = "AppNameLabel";
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Name = "statusStrip";
            // 
            // whatToDoLabel
            // 
            resources.ApplyResources(this.whatToDoLabel, "whatToDoLabel");
            this.whatToDoLabel.BackColor = System.Drawing.Color.White;
            this.whatToDoLabel.Name = "whatToDoLabel";
            // 
            // keysPicture
            // 
            resources.ApplyResources(this.keysPicture, "keysPicture");
            this.keysPicture.Name = "keysPicture";
            this.keysPicture.TabStop = false;
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.BackColor = System.Drawing.Color.Gold;
            this.versionLabel.Name = "versionLabel";
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.keysPicture);
            this.Controls.Add(this.whatToDoLabel);
            this.Controls.Add(this.AppNameLabel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.LoginTB);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.LoginLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.keysPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox LoginTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label AppNameLabel;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label whatToDoLabel;
        private System.Windows.Forms.PictureBox keysPicture;
        private System.Windows.Forms.Label versionLabel;
    }
}