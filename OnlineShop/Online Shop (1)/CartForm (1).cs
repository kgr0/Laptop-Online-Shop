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
    public partial class CartForm : Form
    {
        public static List<Product> items = new List<Product>();
        public CartForm()
        {
            InitializeComponent();
        }

        private void button_buy_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm();
            form.Show();
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Cart is empty");
                Close();
                return;
            }
            dataGridView1.RowCount = items.Count;
            int total = 0;
            for(int i=0; i<items.Count; i++)
            {
                dataGridView1.Rows[i].Height = 100;
                dataGridView1[0, i].Value = items[i].id.ToString();
                dataGridView1[1, i].Value = items[i].brand;
                dataGridView1[2, i].Value = items[i].model;
                dataGridView1[3, i].Value = items[i].price.ToString();
                dataGridView1[4, i].Value = items[i].image1;
                total += items[i].price;
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
                label_discount.Text = "0%";
                label_sum.Text = label_total.Text + "$";
            }
        }

    }
}

