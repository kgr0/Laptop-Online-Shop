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
    public partial class LaptopForm : Form
    {
        Product p = new Product();
        public LaptopForm()
        {
            InitializeComponent();
        }
        public LaptopForm(Product p)
        {
            InitializeComponent();
            this.p = new Product(p);
        }

        private void LaptopForm_Load(object sender, EventArgs e)
        {
            this.Text = p.brand + " " + p.model;
            MemoryStream ms;
            ms = new MemoryStream(p.image1);
            pictureBox_laptop1.BackgroundImage = Image.FromStream(ms);
            ms = new MemoryStream(p.image2);
            pictureBox_laptop2.BackgroundImage = Image.FromStream(ms);
            label_laptop_name.Text = p.brand + " " + p.model;
            label_price.Text = "$" + Convert.ToString(p.price);
            label_proc.Text = p.proc_brand + " " + p.proc_type + p.proc_model;
            label_ram.Text = p.ram_type + " " + p.ram_capacity + "GB";
            label_disk.Text = p.disk_type + " " + p.disk_capacity + "GB";
            label_color.Text = p.color;

            //coments settings
            if(!comments())
            {
                Label label = new Label
                {
                    Name = "com",
                    Size = new Size(300, 150),
                    Location = new Point(100, 100),
                    Text = "There are no reviews yet"
                };
                panel.Controls.Add(label);

            }

            if(MainForm.isWorker)
            {
                button_add_to_cart.Enabled = false;
                button_add_to_cart.Visible = false;
            }
        }
        private bool comments()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `comments` WHERE `productId` = @uD", db.getConnection());
            command.Parameters.Add("@uD", MySqlDbType.VarChar).Value = p.id;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            int x = 14, y = 17;
            int i = 1;
            Font font = new Font("Cambria", 12.0f);

            foreach (DataRow row in table.Rows)
            {

                Label label = new Label
                {
                    Name = "com" + i,
                    Size = new Size(300, 150),
                    Location = new Point(x, y),
                    Text = Convert.ToString(row["username"] + " " + Convert.ToString(row["date"]) + " " + Convert.ToString(row["text"])),
                    Font = font
                };
                y += 150;
                i++;
                panel.Controls.Add(label);
            }
            if (table.Rows.Count == 0)
                return false;
            return true;

        }
        private void button_add_to_cart_Click(object sender, EventArgs e)
        {
            CartForm.items.Add(new Product(p));
            MessageBox.Show("Done");
        }
    }
}
