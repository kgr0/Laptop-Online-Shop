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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            int customerID = 0;
            int discount = 0;
            if (MainForm.logined)
            {
                customerID = MainForm.user.id;
                discount = MainForm.user.discount;
            }
            if (textBox_name.Text == "" || textBox_tel.Text == "" || textBox_address.Text == "")
                MessageBox.Show("There are empty fields!!!");
            else
            {
               int orderID =  Operations.Add_order(customerID, textBox_name.Text, textBox_tel.Text, textBox_address.Text, Convert.ToInt32(label_total.Text), discount);
           
                for(int i=0; i<CartForm.items.Count; i++)
                {
                    Operations.Add_order_deatils(orderID, CartForm.items[i].id, CartForm.items[i].price);
                }
            }
            MessageBox.Show("Done");
            Close();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = CartForm.items.Count;
            int total = 0;
            for (int i = 0; i < CartForm.items.Count; i++)
            {
                dataGridView1.Rows[i].Height = 100;
                dataGridView1[0, i].Value = CartForm.items[i].id.ToString();
                dataGridView1[1, i].Value = CartForm.items[i].brand;
                dataGridView1[2, i].Value = CartForm.items[i].model;
                dataGridView1[3, i].Value = CartForm.items[i].price.ToString();
                dataGridView1[4, i].Value = CartForm.items[i].image1;
                total += CartForm.items[i].price;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            image.ImageLayout = DataGridViewImageCellLayout.Zoom;

            label_total.Text = total.ToString();
            if (MainForm.logined)
            {
                label_discount.Text = MainForm.user.discount.ToString() + "%";
                label_sum.Text = (Convert.ToInt32(label_total.Text) - Convert.ToInt32(label_total.Text) * MainForm.user.discount / 100).ToString() + "$";
            }
            else
            {
                label_discount.Text =  "0%";
                label_sum.Text = label_total.Text + "$";
            }
        }
    }
}
