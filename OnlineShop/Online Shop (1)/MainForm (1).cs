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

namespace Online_Shop
{
    public partial class MainForm : Form
    {
        Color blue = Color.FromArgb(26, 96, 164);

        string searchBoxText = "Please, enter a brand and model";

        public static bool logined = false; // is someone logged in system

        public static User user = new User();
        public static Worker worker = new Worker();

        public static bool isWorker = false;

        MemoryStream ms;

        List<Product> listOfProduct;
        List<int> listID;
        int n;
        int numbOfEl;

        bool filtrPrice, filtrBrand, filtrProc, filtrRamType, filtrRamCap, filtrDisk, filtrColor; // checking filters

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Width = this.Width;
            panel_scroll.Width = this.Width;
            panel_scroll.AutoScroll = false;
            textBox_search.Height = 49;


            textBox_min_price.Text = Convert.ToString(Product.minPrice);
            textBox_max_price.Text = Convert.ToString(Product.maxPrice);
            textBox_min_price.ForeColor = Color.Gray;
            textBox_max_price.ForeColor = Color.Gray;

            textBox_search.Text = searchBoxText;
            textBox_search.ForeColor = Color.Gray;

            button_price_ok.Enabled = false;
            button_search.Enabled = false;

            // filtr processor
            checkBox_corei3.Enabled = false;
            checkBox_corei5.Enabled = false;
            checkBox_corei7.Enabled = false;
            checkBox_corei9.Enabled = false;

            checkBox_ryzen3.Enabled = false;
            checkBox_ryzen5.Enabled = false;
            checkBox_ryzen7.Enabled = false;
            checkBox_athlon.Enabled = false;

            // filtr hard disk
            checkBox_ssd_128.Enabled = false;
            checkBox_ssd_256.Enabled = false;
            checkBox_ssd_512.Enabled = false;
            checkBox_ssd_1024.Enabled = false;

            checkBox_hdd_500.Enabled = false;
            checkBox_hdd_750.Enabled = false;
            checkBox_hdd_1000.Enabled = false;
            checkBox_hdd_2000.Enabled = false;

            filtrPrice = false;
            filtrBrand = false;
            filtrProc = false;
            filtrRamType = false;
            filtrRamCap = false;
            filtrColor = false;
            filtrDisk = false;

            clear();
            button_prev.Enabled = false;

            listID = Operations.ListOfId();
            if (listID.Count < 12)
            {
                button_next.Enabled = false;
                n = listID.Count;
                display12(listID);
            }
            else
            {
                n = 12;
                display12(listID.GetRange(0, 12));
            }

        }

        private void clear() // clear all products
        {
            panel_laptop1.Visible = false;
            panel_laptop2.Visible = false;
            panel_laptop3.Visible = false;
            panel_laptop4.Visible = false;
            panel_laptop5.Visible = false;
            panel_laptop6.Visible = false;
            panel_laptop7.Visible = false;
            panel_laptop8.Visible = false;
            panel_laptop9.Visible = false;
            panel_laptop10.Visible = false;
            panel_laptop11.Visible = false;
            panel_laptop12.Visible = false;
        }

        private void display12(List<int> list) // display laptops on screen
        {
            listOfProduct = Operations.ListOfProducts(list);
            numbOfEl = listOfProduct.Count;

            if (numbOfEl > 0)
            {
                panel_laptop1.Visible = true;
                ms = new MemoryStream(listOfProduct[0].image1);
                pictureBox_laptop1.BackgroundImage = Image.FromStream(ms);
                label_laptop1.Text = "$" + Convert.ToString(listOfProduct[0].price);
                label_d1.Text = Convert.ToString(listOfProduct[0].brand) + " " + Convert.ToString(listOfProduct[0].model);
            }
            if (numbOfEl > 1)
            {
                panel_laptop2.Visible = true;
                ms = new MemoryStream(listOfProduct[1].image1);
                pictureBox_laptop2.BackgroundImage = Image.FromStream(ms);
                label_laptop2.Text = "$" + Convert.ToString(listOfProduct[1].price);
                label_d2.Text = Convert.ToString(listOfProduct[1].brand) + " " + Convert.ToString(listOfProduct[1].model);
            }
            if (numbOfEl > 2)
            {
                panel_laptop3.Visible = true;
                ms = new MemoryStream(listOfProduct[2].image1);
                pictureBox_laptop3.BackgroundImage = Image.FromStream(ms);
                label_laptop3.Text = "$" + Convert.ToString(listOfProduct[2].price);
                label_d3.Text = Convert.ToString(listOfProduct[2].brand) + " " + Convert.ToString(listOfProduct[2].model);
            }
            if (numbOfEl > 3)
            {
                panel_laptop4.Visible = true;
                ms = new MemoryStream(listOfProduct[3].image1);
                pictureBox_laptop4.BackgroundImage = Image.FromStream(ms);
                label_laptop4.Text = "$" + Convert.ToString(listOfProduct[3].price);
                label_d4.Text = Convert.ToString(listOfProduct[3].brand) + " " + Convert.ToString(listOfProduct[3].model);
            }
            if (numbOfEl > 4)
            {
                panel_laptop5.Visible = true;
                ms = new MemoryStream(listOfProduct[4].image1);
                pictureBox_laptop5.BackgroundImage = Image.FromStream(ms);
                label_laptop5.Text = "$" + Convert.ToString(listOfProduct[4].price);
                label_d5.Text = Convert.ToString(listOfProduct[4].brand) + " " + Convert.ToString(listOfProduct[4].model);
            }
            if (numbOfEl > 5)
            {
                panel_laptop6.Visible = true;
                ms = new MemoryStream(listOfProduct[5].image1);
                pictureBox_laptop6.BackgroundImage = Image.FromStream(ms);
                label_laptop6.Text = "$" + Convert.ToString(listOfProduct[5].price);
                label_d6.Text = Convert.ToString(listOfProduct[5].brand) + " " + Convert.ToString(listOfProduct[5].model);
            }
            if (numbOfEl > 6)
            {
                panel_laptop7.Visible = true;
                ms = new MemoryStream(listOfProduct[6].image1);
                pictureBox_laptop7.BackgroundImage = Image.FromStream(ms);
                label_laptop7.Text = "$" + Convert.ToString(listOfProduct[6].price);
                label_d7.Text = Convert.ToString(listOfProduct[6].brand) + " " + Convert.ToString(listOfProduct[6].model);
            }
            if (numbOfEl > 7)
            {
                panel_laptop8.Visible = true;
                ms = new MemoryStream(listOfProduct[7].image1);
                pictureBox_laptop8.BackgroundImage = Image.FromStream(ms);
                label_laptop8.Text = "$" + Convert.ToString(listOfProduct[7].price);
                label_d8.Text = Convert.ToString(listOfProduct[7].brand) + " " + Convert.ToString(listOfProduct[7].model);
            }
            if (numbOfEl > 8)
            {
                panel_laptop9.Visible = true;
                ms = new MemoryStream(listOfProduct[8].image1);
                pictureBox_laptop9.BackgroundImage = Image.FromStream(ms);
                label_laptop9.Text = "$" + Convert.ToString(listOfProduct[8].price);
                label_d9.Text = Convert.ToString(listOfProduct[8].brand) + " " + Convert.ToString(listOfProduct[8].model);
            }
            if (numbOfEl > 9)
            {
                panel_laptop10.Visible = true;
                ms = new MemoryStream(listOfProduct[9].image1);
                pictureBox_laptop10.BackgroundImage = Image.FromStream(ms);
                label_laptop10.Text = "$" + Convert.ToString(listOfProduct[9].price);
                label_d10.Text = Convert.ToString(listOfProduct[9].brand) + " " + Convert.ToString(listOfProduct[9].model);
            }
            if (numbOfEl > 10)
            {
                panel_laptop11.Visible = true;
                ms = new MemoryStream(listOfProduct[10].image1);
                pictureBox_laptop11.BackgroundImage = Image.FromStream(ms);
                label_laptop11.Text = "$" + Convert.ToString(listOfProduct[10].price);
                label_d11.Text = Convert.ToString(listOfProduct[10].brand) + " " + Convert.ToString(listOfProduct[10].model);
            }
            if (numbOfEl > 11)
            {
                panel_laptop12.Visible = true;
                ms = new MemoryStream(listOfProduct[11].image1);
                pictureBox_laptop12.BackgroundImage = Image.FromStream(ms);
                label_laptop12.Text = "$" + Convert.ToString(listOfProduct[11].price);
                label_d12.Text = Convert.ToString(listOfProduct[11].brand) + " " + Convert.ToString(listOfProduct[11].model);
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            clear();
            string[] text = textBox_search.Text.Split(' ');
            for (int i = 2; i < text.Length; i++)
                text[1] += " " + text[i];
            List<int> list = Operations.Find(text[0], text[1]);
            if (list.Count < 12)
            {
                display12(list);
            }
            else
            {
                display12(list.GetRange(0, 12));
            }
        }

        // Filters
        private void textBox_min_price_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox_min_price.Text == Convert.ToString(Product.minPrice))
            {
                textBox_min_price.Text = "";
                textBox_min_price.ForeColor = blue;
            }
            if (textBox_min_price.Text != "")
            {
                button_price_ok.Enabled = true;
            }
        }
        private void textBox_min_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox_min_price.Text == Convert.ToString(Product.minPrice))
            {
                textBox_min_price.Text = "";
                textBox_min_price.ForeColor = blue;
            }
            button_price_ok.Enabled = true;
        }
        private void textBox_min_price_Leave(object sender, EventArgs e)
        {
            if (textBox_min_price.Text == "" || textBox_min_price.Text == Convert.ToString(Product.minPrice))
            {
                textBox_min_price.Text = Convert.ToString(Product.minPrice);
                textBox_min_price.ForeColor = Color.Gray;
                if (textBox_max_price.Text == "" || textBox_max_price.Text == Convert.ToString(Product.maxPrice))
                    button_price_ok.Enabled = false;
            }
        }
        private void textBox_max_price_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox_max_price.Text == Convert.ToString(Product.maxPrice))
            {
                textBox_max_price.Text = "";
                textBox_max_price.ForeColor = blue;
            }
            if (textBox_max_price.Text != "")
            {
                button_price_ok.Enabled = true;
            }
        }
        private void textBox_max_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox_max_price.Text == Convert.ToString(Product.maxPrice))
            {
                textBox_max_price.Text = "";
                textBox_max_price.ForeColor = blue;
            }
            button_price_ok.Enabled = true;
        }
        private void textBox_max_price_Leave(object sender, EventArgs e)
        {
            if (textBox_max_price.Text == "" || textBox_max_price.Text == Convert.ToString(Product.maxPrice))
            {
                textBox_max_price.Text = Convert.ToString(Product.maxPrice);
                textBox_max_price.ForeColor = Color.Gray;
                if (textBox_min_price.Text == "" || textBox_min_price.Text == Convert.ToString(Product.minPrice))
                    button_price_ok.Enabled = false;
            }
        }
        private void textBox_search_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox_search.Text == searchBoxText)
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = blue;
            }
            if (textBox_search.Text != "" && textBox_search.Text != searchBoxText)
            {
                button_search.Enabled = true;
            }
        }
        private void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox_search.Text == searchBoxText)
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = blue;
            }
            button_search.Enabled = true;
        }
        private void textBox_search_Leave(object sender, EventArgs e)
        {
            if (textBox_search.Text == "" || textBox_search.Text == searchBoxText)
            {
                textBox_search.Text = searchBoxText;
                textBox_search.ForeColor = Color.Gray;
                button_search.Enabled = false;
            }
        }
        private void checkBox_intel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_intel.Checked)
            {
                filtrProc = true;
                checkBox_corei3.Enabled = true;
                checkBox_corei5.Enabled = true;
                checkBox_corei7.Enabled = true;
                checkBox_corei9.Enabled = true;
            }
            else
            {
                if(!checkBox_amd.Checked)
                filtrProc = false;
                checkBox_corei3.Enabled = false;
                checkBox_corei5.Enabled = false;
                checkBox_corei7.Enabled = false;
                checkBox_corei9.Enabled = false;

                checkBox_corei3.Checked = false;
                checkBox_corei5.Checked = false;
                checkBox_corei7.Checked = false;
                checkBox_corei9.Checked = false;
            }
        }
        private void checkBox_amd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_amd.Checked)
            {
                filtrProc = true;
                checkBox_ryzen3.Enabled = true;
                checkBox_ryzen5.Enabled = true;
                checkBox_ryzen7.Enabled = true;
                checkBox_athlon.Enabled = true;
            }
            else
            {
                if(!checkBox_intel.Checked)
                   filtrProc = false;
                checkBox_ryzen3.Enabled = false;
                checkBox_ryzen5.Enabled = false;
                checkBox_ryzen7.Enabled = false;
                checkBox_athlon.Enabled = false;

                checkBox_ryzen3.Checked = false;
                checkBox_ryzen5.Checked = false;
                checkBox_ryzen7.Checked = false;
                checkBox_athlon.Checked = false;
            }
        }
        private void checkBox_ssd_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_ssd.Checked)
            {
                filtrDisk = true;
                checkBox_ssd_128.Enabled = true;
                checkBox_ssd_256.Enabled = true;
                checkBox_ssd_512.Enabled = true;
                checkBox_ssd_1024.Enabled = true;
            }
            else
            {
                if(!checkBox_hdd.Checked)
                filtrDisk = false;
                checkBox_ssd_128.Enabled = false;
                checkBox_ssd_256.Enabled = false;
                checkBox_ssd_512.Enabled = false;
                checkBox_ssd_1024.Enabled = false;

                checkBox_ssd_128.Checked = false;
                checkBox_ssd_256.Checked = false;
                checkBox_ssd_512.Checked = false;
                checkBox_ssd_1024.Checked = false;
            }
        }
        private void checkBox_hdd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_hdd.Checked)
            {
                filtrDisk = true;
                checkBox_hdd_500.Enabled = true;
                checkBox_hdd_750.Enabled = true;
                checkBox_hdd_1000.Enabled = true;
                checkBox_hdd_2000.Enabled = true;
            }
            else
            {
                if(!checkBox_ssd.Checked)
                filtrDisk = false;
                checkBox_hdd_500.Enabled = false;
                checkBox_hdd_750.Enabled = false;
                checkBox_hdd_1000.Enabled = false;
                checkBox_hdd_2000.Enabled = false;

                checkBox_hdd_500.Checked = false;
                checkBox_hdd_750.Checked = false;
                checkBox_hdd_1000.Checked = false;
                checkBox_hdd_2000.Checked = false;
            }
        }

        // end Filters

        // Laptops

        private void pictureBox_laptop1_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop1.Visible)
                return;
            Product p = listOfProduct[0];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop1.BackgroundImage = Image.FromStream(ms);
            label_d1.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop1_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop1.Visible)
                return;
            Product p = listOfProduct[0];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop1.BackgroundImage = Image.FromStream(ms);
            label_d1.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop2_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop2.Visible)
                return;
            Product p = listOfProduct[1];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop2.BackgroundImage = Image.FromStream(ms);
            label_d2.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop2_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop2.Visible)
                return;
            Product p = listOfProduct[1];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop2.BackgroundImage = Image.FromStream(ms);
            label_d2.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop3_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop3.Visible)
                return;
            Product p = listOfProduct[2];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop3.BackgroundImage = Image.FromStream(ms);
            label_d3.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop3_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop3.Visible)
                return;
            Product p = listOfProduct[2];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop3.BackgroundImage = Image.FromStream(ms);
            label_d3.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop4_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop4.Visible)
                return;
            Product p = listOfProduct[3];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop4.BackgroundImage = Image.FromStream(ms);
            label_d4.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop4_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop4.Visible)
                return;
            Product p = listOfProduct[3];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop4.BackgroundImage = Image.FromStream(ms);
            label_d4.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop5_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop5.Visible)
                return;
            Product p = listOfProduct[4];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop5.BackgroundImage = Image.FromStream(ms);
            label_d5.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop5_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop5.Visible)
                return;
            Product p = listOfProduct[4];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop5.BackgroundImage = Image.FromStream(ms);
            label_d5.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop6_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop6.Visible)
                return;
            Product p = listOfProduct[5];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop6.BackgroundImage = Image.FromStream(ms);
            label_d6.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop6_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop6.Visible)
                return;
            Product p = listOfProduct[5];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop6.BackgroundImage = Image.FromStream(ms);
            label_d6.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop7_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop7.Visible)
                return;
            Product p = listOfProduct[6];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop7.BackgroundImage = Image.FromStream(ms);
            label_d7.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop7_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop7.Visible)
                return;
            Product p = listOfProduct[6];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop7.BackgroundImage = Image.FromStream(ms);
            label_d7.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop8_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop8.Visible)
                return;
            Product p = listOfProduct[7];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop8.BackgroundImage = Image.FromStream(ms);
            label_d8.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop8_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop8.Visible)
                return;
            Product p = listOfProduct[7];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop8.BackgroundImage = Image.FromStream(ms);
            label_d8.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop9_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop9.Visible)
                return;
            Product p = listOfProduct[8];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop9.BackgroundImage = Image.FromStream(ms);
            label_d9.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop9_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop9.Visible)
                return;
            Product p = listOfProduct[8];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop9.BackgroundImage = Image.FromStream(ms);
            label_d9.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop10_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop10.Visible)
                return;
            Product p = listOfProduct[9];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop10.BackgroundImage = Image.FromStream(ms);
            label_d10.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop10_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop10.Visible)
                return;
            Product p = listOfProduct[9];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop10.BackgroundImage = Image.FromStream(ms);
            label_d10.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop11_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop11.Visible)
                return;
            Product p = listOfProduct[10];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop11.BackgroundImage = Image.FromStream(ms);
            label_d11.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }
        private void pictureBox_laptop11_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop11.Visible)
                return;
            Product p = listOfProduct[10];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop11.BackgroundImage = Image.FromStream(ms);
            label_d11.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }
        private void pictureBox_laptop12_MouseHover(object sender, EventArgs e)
        {
            if (!panel_laptop12.Visible)
                return;
            Product p = listOfProduct[11];
            ms = new MemoryStream(p.image2);
            pictureBox_laptop12.BackgroundImage = Image.FromStream(ms);
            label_d12.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model) + "\n" +
                Convert.ToString(p.proc_brand) + " " + Convert.ToString(p.proc_type) + " " + Convert.ToString(p.proc_model) + "\n" +
                Convert.ToString(p.ram_type) + " " + Convert.ToString(p.ram_capacity) + "GB\n" +
                Convert.ToString(p.disk_type) + " " + Convert.ToString(p.disk_capacity) + "GB";
        }

   

       

        private void pictureBox_laptop12_MouseLeave(object sender, EventArgs e)
        {
            if (!panel_laptop12.Visible)
                return;
            Product p = listOfProduct[11];
            ms = new MemoryStream(p.image1);
            pictureBox_laptop12.BackgroundImage = Image.FromStream(ms);
            label_d12.Text = Convert.ToString(p.brand) + " " + Convert.ToString(p.model);
        }

        private void button_cart_Click(object sender, EventArgs e)
        {
            CartForm form = new CartForm();
            form.Show();
        }

        // selecting item
        private void pictureBox_laptop1_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[0]));
            form.Show();
        }

        private void pictureBox_laptop2_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[1]));
            form.Show();
        }
        private void pictureBox_laptop3_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[2]));
            form.Show();
        }
        private void pictureBox_laptop4_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[3]));
            form.Show();
        }

        private void pictureBox_laptop5_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[4]));
            form.Show();
        }

        private void pictureBox_laptop6_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[5]));
            form.Show();
        }

        private void pictureBox_laptop7_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[6]));
            form.Show();
        }

        private void pictureBox_laptop8_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[7]));
            form.Show();
        }

        private void pictureBox_laptop9_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[8]));
            form.Show();
        }

        private void pictureBox_laptop10_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[9]));
            form.Show();
        }

        private void pictureBox_laptop11_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[10]));
            form.Show();
        }

        private void pictureBox_laptop12_Click(object sender, EventArgs e)
        {
            LaptopForm form = new LaptopForm(new Product(listOfProduct[11]));
            form.Show();
        }


        // end Laptops

        private void button_apply_filters_Click(object sender, EventArgs e)
        {
            clear();
            listID = filters();
            if (listID.Count < 12)
            {
                display12(listID);
            }
            else
            {
                display12(listID.GetRange(0, 12));
            }
        }
 
        private List<int> filters()
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            if (checkBox_black.Checked || checkBox_gold.Checked || checkBox_gray.Checked || checkBox_white.Checked || checkBox_silver.Checked)
            {
                filtrColor = true;
                if (checkBox_gray.Checked)
                {
                    list1 = list1.Concat(Operations.Filtr(color.gray)).ToList();
                }
                if (checkBox_black.Checked)
                {
                    list1 = list1.Concat(Operations.Filtr(color.black)).ToList();
                }
                if (checkBox_gold.Checked)
                {
                    list1 = list1.Concat(Operations.Filtr(color.gold)).ToList();
                }
                if (checkBox_white.Checked)
                {
                    list1 = list1.Concat(Operations.Filtr(color.white)).ToList();
                }
                if (checkBox_silver.Checked)
                {
                    list1 = list1.Concat(Operations.Filtr(color.silver)).ToList();
                }
            }
            else filtrColor = false;


            if (checkBox_Dell.Checked || checkBox_HP.Checked || checkBox_Lenovo.Checked || checkBox_Apple.Checked || checkBox_Asus.Checked || checkBox_Acer.Checked)
            {
                filtrBrand = true;
                if (checkBox_Apple.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr("Apple")).ToList();
                }
                if (checkBox_HP.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr("HP")).ToList();
                }
                if (checkBox_Dell.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr("Dell")).ToList();
                }
                if (checkBox_Acer.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr("Acer")).ToList();
                }
                if (checkBox_Lenovo.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr("Lenovo")).ToList();
                }
                if (checkBox_Asus.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr("Asus")).ToList();
                }
            }
            else filtrBrand = false;

            if(filtrBrand && filtrColor)
            {
                list1 = list1.Intersect(list2).ToList();
            }
            else if (filtrBrand)
                list1 = new List<int> (list2);

            list2.Clear();
            if (checkBox_ddr3.Checked || checkBox_ddr4.Checked)
            {
                filtrRamType = true;
                
                if (checkBox_ddr3.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.DDR3, 0)).ToList();
                }
                if (checkBox_ddr4.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.DDR4, 0)).ToList();
                }
              }
            else filtrRamType = false;

            if (filtrRamType && (filtrBrand || filtrColor))
            {
                list1 = list1.Intersect(list2).ToList();
            }
            else if (filtrRamType)
                list1 = new List<int>(list2);

            list2.Clear();
            if (checkBox_4GB.Checked || checkBox_6GB.Checked || checkBox_8GB.Checked || checkBox_12GB.Checked || checkBox_16GB.Checked)
            {
                filtrRamCap = true;
                if (checkBox_4GB.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.etc, 4)).ToList();
                }
                if (checkBox_6GB.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.etc, 6)).ToList();
                }
                if (checkBox_8GB.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.etc, 8)).ToList();
                }
                if (checkBox_12GB.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.etc, 12)).ToList();
                }
                if (checkBox_16GB.Checked)
                {
                    list2 = list2.Concat(Operations.Filtr(memory_type.etc, 16)).ToList();
                }
            }
            else filtrRamCap = false;

            if (filtrRamCap && (filtrBrand || filtrColor || filtrRamType))
            {
                list1 = list1.Intersect(list2).ToList();
            }
            else if (filtrRamCap)
                list1 = new List<int>(list2);
            list2.Clear();

            
            if (filtrDisk)
            {
                bool t = false;
                if (checkBox_ssd.Checked)
                {
                    if (checkBox_ssd_1024.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.SSD, 1024)).ToList();
                        t = true;
                    }
                    if (checkBox_ssd_512.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.SSD, 512)).ToList();
                        t = true;
                    }
                    if (checkBox_ssd_256.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.SSD, 256)).ToList();
                        t = true;
                    }
                    if (checkBox_ssd_128.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.SSD, 128)).ToList();
                        t = true;
                    }
                    if (!t)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.SSD, 0)).ToList();
                    }
                }
                t = false;
                if (checkBox_hdd.Checked)
                {
                    if (checkBox_hdd_500.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.HDD, 500)).ToList();
                        t = true;
                    }
                    if (checkBox_hdd_750.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.HDD, 750)).ToList();
                        t = true;
                    }
                    if (checkBox_hdd_1000.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.HDD, 1000)).ToList();
                        t = true;
                    }
                    if (checkBox_hdd_2000.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.HDD, 2000)).ToList();
                        t = true;
                    }
                    if (!t)
                    {
                        list2 = list2.Concat(Operations.Filtr(drive_type.HDD, 0)).ToList();
                    }
                }
            }

            if (filtrDisk && (filtrBrand || filtrColor || filtrRamType || filtrRamCap))
            {
                list1 = list1.Intersect(list2).ToList();
            }
            else if (filtrDisk)
                list1 = new List<int>(list2);
            list2.Clear();

            
            if (filtrProc)
            {
                bool t = false;
                if (checkBox_intel.Checked)
                {
                    if (checkBox_corei3.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.Intel, "Core i3")).ToList();
                        t = true;
                    }
                    if (checkBox_corei5.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.Intel, "Core i5")).ToList();
                        t = true;
                    }
                    if (checkBox_corei7.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.Intel, "Core i7")).ToList();
                        t = true;
                    }
                    if (checkBox_corei9.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.Intel, "Core i9")).ToList();
                        t = true;
                    }
                    if (!t)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.Intel, "")).ToList();
                    }
                }
                t = false;
                if (checkBox_amd.Checked)
                {
                    if (checkBox_ryzen3.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.AMD, "Ryzen 3")).ToList();
                        t = true;
                    }
                    if (checkBox_ryzen5.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.AMD, "Ryzen 5")).ToList();
                        t = true;
                    }
                    if (checkBox_ryzen7.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.AMD, "Ryzen 7")).ToList();
                        t = true;
                    }
                    if (checkBox_athlon.Checked)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.AMD, "Athlon")).ToList();
                        t = true;
                    }
                    if (!t)
                    {
                        list2 = list2.Concat(Operations.Filtr(proc_producer.AMD, "")).ToList();
                    }
                }
            }
            if (filtrProc  && (filtrBrand || filtrColor || filtrRamType || filtrRamCap || filtrDisk))
            {
                list1 = list1.Intersect(list2).ToList();
            }
            else if (filtrProc)
                list1 = new List<int>(list2);
            list2.Clear();

            if (textBox_max_price.Text != "400" || textBox_min_price.Text!="3000")
            {
                filtrPrice = true;
                list2 = list2.Concat(Operations.Filtr(Convert.ToInt32(textBox_max_price.Text), Convert.ToInt32(textBox_min_price.Text))).ToList();
            }
            else filtrPrice = false;

            button_price_ok.Text = Convert.ToString(list2.Count);

            if (filtrPrice && (filtrProc || filtrBrand || filtrColor || filtrRamType || filtrRamCap || filtrDisk))
            {
                list1 = list1.Intersect(list2).ToList();
            }
            else if (filtrPrice)
            {
                list1 = new List<int>(list2);
            }

            if (!(filtrPrice || filtrProc || filtrBrand || filtrColor || filtrRamType || filtrRamCap || filtrDisk || filtrPrice))
            {
                return Operations.ListOfId();
            }
            if (list1.Count < 12)
                button_next.Enabled = false;
            return list1;
        }  
        private void button_next_Click(object sender, EventArgs e)
        {
            if (!button_next.Enabled)
                return;
            button_prev.Enabled = true;
            clear();
            if (listID.Count - n < 12)
            {
                button_next.Enabled = false;
                button_price_ok.Text = Convert.ToString(listID.Count - n);
                display12(listID.GetRange(n, listID.Count - n));
                n = listID.Count;
            }
            else
            {
                display12(listID.GetRange(n, 12));
                n += 12;
            }
        
        }
        private void button_prev_Click(object sender, EventArgs e)
        {
            if (!button_prev.Enabled)
                return;
            if(n <= 12)
            {
                button_prev.Enabled = false;
                return;
            }

            button_next.Enabled = true;
            clear();
            n -= numbOfEl;
            if (n <= 12)
                button_prev.Enabled = false;
            display12(listID.GetRange(n-12, 12));
            

        } 
        private void button_login_Click(object sender, EventArgs e)
        {
            if (!MainForm.logined)
            {

                Login_Form form = new Login_Form();
                form.Show();
                form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            }
            else
            {
                if (isWorker)
                {
                    WorkerForm form = new WorkerForm(worker);
                    form.Show();
                }
                else
                {
                    UserForm form = new UserForm(user);
                    form.Show();
                }
            }
        }

        private void button_register_Click(object sender, EventArgs e)
        {

                Registration_Form form1 = new Registration_Form();
                form1.Show();
                form1.FormClosing += new FormClosingEventHandler(form1_FormClosing);
        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logined)
            {
                button_register.Enabled = false;
                button_register.Visible = false;
                button_login.Text = "My Profile";

                if (isWorker)
                {
                    button_cart.Enabled = false;
                    button_cart.Visible = false;
                }
            }
        }
        void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (logined)
            {
                button_register.Enabled = false;
                button_register.Visible = false;
                button_login.Text = "My Profile";

                if (isWorker)
                {
                    button_cart.Enabled = false;
                    button_cart.Visible = false;
                }
            }
        }


    }
}
