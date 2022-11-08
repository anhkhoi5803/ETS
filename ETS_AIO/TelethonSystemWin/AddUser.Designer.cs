namespace TelethonSystemWin
{
    partial class AddUser
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
            this.btn_addUser = new System.Windows.Forms.Button();
            this.showPassNew = new System.Windows.Forms.CheckBox();
            this.txt_newpass = new System.Windows.Forms.TextBox();
            this.txt_username_new = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.showPassAuthorized = new System.Windows.Forms.CheckBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_authorized = new System.Windows.Forms.Button();
            this.txt_passauthorized = new System.Windows.Forms.TextBox();
            this.txt_username_authorized = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_newpassrepeat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_addUser
            // 
            this.btn_addUser.Enabled = false;
            this.btn_addUser.Location = new System.Drawing.Point(15, 315);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(184, 23);
            this.btn_addUser.TabIndex = 28;
            this.btn_addUser.Text = "Add User";
            this.btn_addUser.UseVisualStyleBackColor = true;
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // showPassNew
            // 
            this.showPassNew.AutoSize = true;
            this.showPassNew.Location = new System.Drawing.Point(72, 279);
            this.showPassNew.Name = "showPassNew";
            this.showPassNew.Size = new System.Drawing.Size(102, 17);
            this.showPassNew.TabIndex = 27;
            this.showPassNew.Text = "Show Password";
            this.showPassNew.UseVisualStyleBackColor = true;
            this.showPassNew.CheckedChanged += new System.EventHandler(this.showPassNew_CheckedChanged);
            // 
            // txt_newpass
            // 
            this.txt_newpass.Location = new System.Drawing.Point(72, 221);
            this.txt_newpass.Margin = new System.Windows.Forms.Padding(2);
            this.txt_newpass.Name = "txt_newpass";
            this.txt_newpass.Size = new System.Drawing.Size(127, 20);
            this.txt_newpass.TabIndex = 24;
            this.txt_newpass.UseSystemPasswordChar = true;
            // 
            // txt_username_new
            // 
            this.txt_username_new.Location = new System.Drawing.Point(72, 188);
            this.txt_username_new.Margin = new System.Windows.Forms.Padding(2);
            this.txt_username_new.Name = "txt_username_new";
            this.txt_username_new.Size = new System.Drawing.Size(127, 20);
            this.txt_username_new.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "New User Creation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 58);
            this.label1.TabIndex = 19;
            this.label1.Text = "Welcome to the \r\nETS Telethon System\r\n";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(369, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(8, 8);
            this.progressBar1.TabIndex = 29;
            // 
            // showPassAuthorized
            // 
            this.showPassAuthorized.AutoSize = true;
            this.showPassAuthorized.Location = new System.Drawing.Point(273, 244);
            this.showPassAuthorized.Name = "showPassAuthorized";
            this.showPassAuthorized.Size = new System.Drawing.Size(102, 17);
            this.showPassAuthorized.TabIndex = 37;
            this.showPassAuthorized.Text = "Show Password";
            this.showPassAuthorized.UseVisualStyleBackColor = true;
            this.showPassAuthorized.CheckedChanged += new System.EventHandler(this.showPassAuthorized_CheckedChanged);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(72, 372);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(266, 25);
            this.btn_exit.TabIndex = 36;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_authorized
            // 
            this.btn_authorized.Location = new System.Drawing.Point(216, 313);
            this.btn_authorized.Margin = new System.Windows.Forms.Padding(2);
            this.btn_authorized.Name = "btn_authorized";
            this.btn_authorized.Size = new System.Drawing.Size(184, 25);
            this.btn_authorized.TabIndex = 35;
            this.btn_authorized.Text = "Authorized";
            this.btn_authorized.UseVisualStyleBackColor = true;
            this.btn_authorized.Click += new System.EventHandler(this.btn_authorized_Click);
            // 
            // txt_passauthorized
            // 
            this.txt_passauthorized.Location = new System.Drawing.Point(273, 221);
            this.txt_passauthorized.Margin = new System.Windows.Forms.Padding(2);
            this.txt_passauthorized.Name = "txt_passauthorized";
            this.txt_passauthorized.Size = new System.Drawing.Size(127, 20);
            this.txt_passauthorized.TabIndex = 34;
            this.txt_passauthorized.UseSystemPasswordChar = true;
            // 
            // txt_username_authorized
            // 
            this.txt_username_authorized.Location = new System.Drawing.Point(273, 188);
            this.txt_username_authorized.Margin = new System.Windows.Forms.Padding(2);
            this.txt_username_authorized.Name = "txt_username_authorized";
            this.txt_username_authorized.Size = new System.Drawing.Size(127, 20);
            this.txt_username_authorized.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 193);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(212, 159);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 18);
            this.label7.TabIndex = 30;
            this.label7.Text = "For Authorized User:";
            // 
            // txt_newpassrepeat
            // 
            this.txt_newpassrepeat.Location = new System.Drawing.Point(72, 254);
            this.txt_newpassrepeat.Margin = new System.Windows.Forms.Padding(2);
            this.txt_newpassrepeat.Name = "txt_newpassrepeat";
            this.txt_newpassrepeat.Size = new System.Drawing.Size(127, 20);
            this.txt_newpassrepeat.TabIndex = 40;
            this.txt_newpassrepeat.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 248);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 26);
            this.label8.TabIndex = 39;
            this.label8.Text = "Repeat \r\nPassword";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 431);
            this.Controls.Add(this.txt_newpassrepeat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.showPassAuthorized);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_authorized);
            this.Controls.Add(this.txt_passauthorized);
            this.Controls.Add(this.txt_username_authorized);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_addUser);
            this.Controls.Add(this.showPassNew);
            this.Controls.Add(this.txt_newpass);
            this.Controls.Add(this.txt_username_new);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_addUser;
        private System.Windows.Forms.CheckBox showPassNew;
        private System.Windows.Forms.TextBox txt_newpass;
        private System.Windows.Forms.TextBox txt_username_new;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox showPassAuthorized;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_authorized;
        private System.Windows.Forms.TextBox txt_passauthorized;
        private System.Windows.Forms.TextBox txt_username_authorized;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_newpassrepeat;
        private System.Windows.Forms.Label label8;
    }
}