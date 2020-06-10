namespace Stock
{
    partial class ChangePassword
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
            this.btnChangePass = new System.Windows.Forms.Button();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtoldPass = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChangePass
            // 
            this.btnChangePass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.Location = new System.Drawing.Point(164, 195);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(261, 41);
            this.btnChangePass.TabIndex = 24;
            this.btnChangePass.Text = "&Change Password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(164, 102);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '*';
            this.txtConfirmPass.Size = new System.Drawing.Size(261, 26);
            this.txtConfirmPass.TabIndex = 23;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(164, 64);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(261, 26);
            this.txtNewPass.TabIndex = 22;
            // 
            // txtoldPass
            // 
            this.txtoldPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoldPass.Location = new System.Drawing.Point(164, 25);
            this.txtoldPass.Name = "txtoldPass";
            this.txtoldPass.PasswordChar = '*';
            this.txtoldPass.Size = new System.Drawing.Size(261, 26);
            this.txtoldPass.TabIndex = 21;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(18, 102);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(130, 19);
            this.lblConfirmPassword.TabIndex = 20;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(42, 67);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(106, 19);
            this.lblNewPassword.TabIndex = 19;
            this.lblNewPassword.Text = "New Password";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.Location = new System.Drawing.Point(48, 28);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(100, 19);
            this.lblOldPassword.TabIndex = 18;
            this.lblOldPassword.Text = "Old Password";
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 261);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtoldPass);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnChangePass;
        public System.Windows.Forms.TextBox txtConfirmPass;
        public System.Windows.Forms.TextBox txtNewPass;
        public System.Windows.Forms.TextBox txtoldPass;
        public System.Windows.Forms.Label lblConfirmPassword;
        public System.Windows.Forms.Label lblNewPassword;
        public System.Windows.Forms.Label lblOldPassword;
    }
}