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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            
        }

        private List<string[]> readUser()
        {
            List<string[]> list = new List<string[]>();
            using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\login.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string str;
                    string[] strArray;
                    str = sr.ReadLine();
                    strArray = str.Split(',');
                    list.Add(strArray); 

                }

            }
            return list;

        }
        private static int login_try = 0;
        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (txt_username.Text == "" && txt_password.Text == "")
            {
                login_try++;
                MessageBox.Show("User name and password are required!\nRetry left:" + (3 - login_try));

            }
            else
            {
                List<string[]> users = readUser();
                bool login = false;
                foreach (string[] user in users)
                {
                    if (txt_username.Text == user[0] && txt_password.Text == user[1])
                    {
                        login = true;

                    }
                }
                if (login)
                {
                    txt_username.Text = "";
                    txt_password.Text = "";
                    MessageBox.Show("Login successful");

                    /*ETSTelethon eTSTelethon = new ETSTelethon();
                    eTSTelethon.Visible = true;
                    eTSTelethon.Activate();*/

                    ETSTelethon_v2 eTSTelethon_V2 = new ETSTelethon_v2();
                    eTSTelethon_V2.Visible = true;
                    eTSTelethon_V2.Activate();

                }
                else
                {
                    txt_username.Text = "";
                    txt_password.Text = "";
                    login_try++;
                    MessageBox.Show("Login unsuccessful\nRetry left:" + (3 - login_try));
                }
            }
            if (login_try == 3)
            {
                login_try = 0;
                Application.Exit();
            }
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser(readUser());
            addUser.Visible = true;
            addUser.Activate();
        }
    }
}
