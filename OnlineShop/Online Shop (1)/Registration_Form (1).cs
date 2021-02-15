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
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        private void button_register_now_Click(object sender, EventArgs e)
        {
            if(textBox_first_name.Text == "" || textBox_last_name.Text == "")
            {
                MessageBox.Show("Please, enter first and last name.");
            }
            if (textBox_login.Text == "" || textBox_password.Text == "" || textBox_confirm_password.Text == "")
            {
                MessageBox.Show("Please, enter login and password.");
            }
            
            if (textBox_password.Text != textBox_confirm_password.Text)
            {
                MessageBox.Show("Wrong password!!!");
            }
            int id = Operations.Find_user(textBox_login.Text);
            if (id != 0)
            {
                MessageBox.Show("This login is unavailable");
            }
            if (Operations.Registration(textBox_first_name.Text, textBox_last_name.Text, textBox_login.Text, textBox_password.Text))
            {
                MainForm.logined = true;
                MainForm.user = new User(Operations.Find_user(textBox_login.Text), textBox_first_name.Text, textBox_last_name.Text, textBox_login.Text, textBox_password.Text);
                MessageBox.Show("Done");
                Close();
            }
            else
            {
                MessageBox.Show("Error"); 
            }
        }

    }
}
