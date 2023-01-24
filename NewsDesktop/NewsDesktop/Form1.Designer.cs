namespace NewsDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnDebugAndrei = new System.Windows.Forms.Button();
            this.btnDebugDaniel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(32, 85);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(227, 23);
            this.tbxEmail.TabIndex = 0;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(32, 146);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(227, 23);
            this.tbxPassword.TabIndex = 1;
            this.tbxPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(184, 207);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDebugAndrei
            // 
            this.btnDebugAndrei.Location = new System.Drawing.Point(296, 85);
            this.btnDebugAndrei.Name = "btnDebugAndrei";
            this.btnDebugAndrei.Size = new System.Drawing.Size(129, 23);
            this.btnDebugAndrei.TabIndex = 3;
            this.btnDebugAndrei.Text = "Andrei (Debug)";
            this.btnDebugAndrei.UseVisualStyleBackColor = true;
            this.btnDebugAndrei.Click += new System.EventHandler(this.btnAndreiDebug_Click);
            // 
            // btnDebugDaniel
            // 
            this.btnDebugDaniel.Location = new System.Drawing.Point(296, 146);
            this.btnDebugDaniel.Name = "btnDebugDaniel";
            this.btnDebugDaniel.Size = new System.Drawing.Size(129, 23);
            this.btnDebugDaniel.TabIndex = 4;
            this.btnDebugDaniel.Text = "Daniel (Debug)";
            this.btnDebugDaniel.UseVisualStyleBackColor = true;
            this.btnDebugDaniel.Click += new System.EventHandler(this.btnDanielDebug_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(134, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 15);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Welcome to WebApp";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(32, 67);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 15);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email: ";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(32, 128);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 15);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 250);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDebugDaniel);
            this.Controls.Add(this.btnDebugAndrei);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxEmail);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbxEmail;
        private TextBox tbxPassword;
        private Button btnLogin;
        private Button btnDebugAndrei;
        private Button btnDebugDaniel;
        private Label lblTitle;
        private Label lblEmail;
        private Label lblPassword;
    }
}