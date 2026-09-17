namespace WinFormsApp4
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
            label1 = new Label();
            txtLogin = new TextBox();
            label2 = new Label();
            lblCaptcha = new Label();
            txtPassword = new TextBox();
            txtCaptcha = new TextBox();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(293, 107);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(293, 125);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(190, 23);
            txtLogin.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 166);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Пароль:";
            // 
            // lblCaptcha
            // 
            lblCaptcha.AutoSize = true;
            lblCaptcha.Location = new Point(365, 277);
            lblCaptcha.Name = "lblCaptcha";
            lblCaptcha.Size = new Size(40, 15);
            lblCaptcha.TabIndex = 3;
            lblCaptcha.Text = "Капча";
            lblCaptcha.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(293, 184);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(190, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Location = new Point(293, 295);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.Size = new Size(190, 23);
            txtCaptcha.TabIndex = 5;
            txtCaptcha.Visible = false;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.ForestGreen;
            btnSubmit.Location = new Point(293, 232);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(190, 31);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Войти";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubmit);
            Controls.Add(txtCaptcha);
            Controls.Add(txtPassword);
            Controls.Add(lblCaptcha);
            Controls.Add(label2);
            Controls.Add(txtLogin);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLogin;
        private Label label2;
        private Label lblCaptcha;
        private TextBox txtPassword;
        private TextBox txtCaptcha;
        private Button btnSubmit;
    }
}
