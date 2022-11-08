using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelethonSystemWin
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }
        List<String[]> users = new List<String[]>();
        public static int create = 0;
        public AddUser(List<String[]> user)
        {
            InitializeComponent();
            this.users = user;
        }

        private void SaveUser()
        {
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\login.txt"))
            {
                foreach (var user in users)
                {
                    sw.WriteLine(user[0]+","+user[1]);
                }
            }
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            if(txt_username_new.Text == null || txt_newpass.Text == null|| txt_newpassrepeat.Text == null)
            {
                create++;
                MessageBox.Show("These field cannot be empty\nRetry Left:" + (3 - create), "Caution",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            else if(txt_newpass.Text != txt_newpassrepeat.Text)
            {
                create++;
                MessageBox.Show("Password doesnt match\n Retry left:" + (3 - create));
            }
            else
            {
                string[] arr = { txt_username_new.Text, txt_newpass.Text };

                users.Add(arr);

                MessageBox.Show("New user added!");
                SaveUser();
                this.Close();
            }
            

            if (create == 3)
            {
                create = 0;
                Application.Exit();
            }
        }

        private void btn_authorized_Click(object sender, EventArgs e)
        {
            bool login = false;
            foreach (string[] user in users)
            {
                if (txt_username_authorized.Text == user[0] && txt_passauthorized.Text == user[1])
                {
                    login = true;

                }
            }

            if (login)
            {
                txt_username_authorized.Enabled=false;
                txt_passauthorized.Enabled=false;
                showPassAuthorized.Checked=false;
                showPassAuthorized.Enabled=false;
                MessageBox.Show("Authorized successful");

                btn_addUser.Enabled = true;
            }
            else
            {
                txt_username_authorized.Text = "";
                txt_passauthorized.Text = "";
                create++;
                MessageBox.Show("Authorized unsuccessful\nRetry Left:"+(3-create));
            }

            if (create == 3)
            {
                create = 0;
                Application.Exit();
            }
        
    }

        private void showPassNew_CheckedChanged(object sender, EventArgs e)
        {
            if (showPassNew.Checked== true)
            {
                txt_newpass.UseSystemPasswordChar = false;
                txt_newpassrepeat.UseSystemPasswordChar = true;
            }
            else
            {
                txt_newpass.UseSystemPasswordChar = true;
                txt_newpassrepeat.UseSystemPasswordChar = true;
            }
        }

        private void showPassAuthorized_CheckedChanged(object sender, EventArgs e)
        {
            if(showPassAuthorized.Checked== true)
            {
                txt_passauthorized.UseSystemPasswordChar = false;
            }
            else
            {
                txt_passauthorized.UseSystemPasswordChar= true;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
