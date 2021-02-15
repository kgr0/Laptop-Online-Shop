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
using System.IO;
using MySql.Data.MySqlClient;

namespace Online_Shop
{
    public partial class UserForm : Form
    {
        public static User user;
        public static bool isWorker = false;
        private BindingSource bindingSource1 = new BindingSource();
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private DataTable table = new DataTable();

     //   public UserForm()
       // {
         //   InitializeComponent();
        //}
        public UserForm(User u)
        {
            InitializeComponent();
            user = new User(u);
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            Text = user.login;
            label_first_name.Text = user.name;
            label_last_name.Text = user.surname;
            label_username.Text = user.login;

            dataGridView1.DataSource = bindingSource1;
            getOrders();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void getOrders()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT orders.id, `date`, `productID`, `brand`, `model`, orderdetails.price, `quantity` FROM orders JOIN (orderdetails, laptops) ON ( orders.id = orderdetails.orderID AND orderdetails.productID = laptops.id) WHERE orders.customerID = @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = MainForm.user.id;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            bindingSource1.DataSource = table;

            dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_new_password1.Text != textBox_new_password2.Text)
            {
                MessageBox.Show("Wrong password");
            }
            else
            {
                if(Operations.Change_password(user.id, textBox_old_password.Text, textBox_new_password1.Text))
                {
                    MessageBox.Show("Done");
                    user.password = textBox_new_password1.Text;
                    textBox_new_password1.Text = "";
                    textBox_new_password2.Text = "";
                    textBox_old_password.Text = "";
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }


    }
}
