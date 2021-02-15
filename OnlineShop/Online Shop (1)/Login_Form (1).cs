using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopLibrary;

namespace Online_Shop
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }
  
        private void button_sign_in_Click(object sender, EventArgs e)
        {
            Log_User();
        }

        protected void Log_User() // log in for user
        {
            if (!Operations.Check_password(textBox_login.Text, textBox_password.Text))
            {
                Log_Worker();
            }
            else
            {
                MessageBox.Show("Done");
                MainForm.logined = true;
                MainForm.isWorker = false;

                MainForm.user = new User(Operations.user_info(textBox_login.Text));
                UserForm.user = new User(Operations.user_info(textBox_login.Text));
                Close();
            }
        }

        protected void Log_Worker() // log in for worker
        {
            int w;
            w = Operations.Check_passwordW(textBox_login.Text, textBox_password.Text);
            if (w == 0)
            {
                MessageBox.Show("Wrong login or password" + textBox_password.Text);
            }
            else
            {
                MessageBox.Show("Done");
                MainForm.logined = true;
                MainForm.isWorker = true;
                MainForm.worker = new Worker(Operations.worker_info(textBox_login.Text));
                WorkerForm.worker = new Worker(Operations.worker_info(textBox_login.Text));
                if (w == 1)
                    WorkerForm.Admin = false;
                else
                    WorkerForm.Admin = true;
                Close();
            }
        }
    }
}
