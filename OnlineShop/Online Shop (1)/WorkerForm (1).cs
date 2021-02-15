using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using ShopLibrary;


namespace Online_Shop
{
    public partial class WorkerForm : Form
    {
        private BindingSource bindingSource1;
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        private DataTable table = new DataTable();
        private byte[] img1;
        private byte[] img2;
        public static Worker worker;
        public static bool Admin = false;

        public WorkerForm()
        {
        }
        public WorkerForm(Worker w)
        {
            InitializeComponent();
            worker = new Worker(w);
        }

        private void WorkerForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            if(!Admin)
            {
                panel_add_worker.Enabled = false;
                panel_add_worker.Visible = false;
                panel_del_worker.Enabled = false;
                panel_del_worker.Visible = false;
                panel_edit_worker.Enabled = false;
                panel_edit_worker.Visible = false;
                panel_workers.Enabled = false;
                panel_workers.Visible = false;

                label_add_worker.Visible = false;
                label_del_worker.Visible = false;
                label_edit_worker.Visible = false;
                label_workers.Visible = false;
            }
            bindingSource1 = new BindingSource();
            dataGridView1.DataSource = bindingSource1;
            getOrders();

            bindingSource1 = new BindingSource();
            dataGridView2.DataSource = bindingSource1;
            getOrderDetails();

            bindingSource1 = new BindingSource();
            dataGridView3.DataSource = bindingSource1;
            getProducts();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            if (Admin)
            {
                bindingSource1 = new BindingSource();
                dataGridView4.DataSource = bindingSource1;
                getWorkers();
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }
        private void getOrders()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `orders`", db.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);


            bindingSource1.DataSource = table;

            dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

        }
        private void getOrderDetails()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `orderdetails`", db.getConnection());

            table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            bindingSource1.DataSource = table;

            dataGridView2.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        private void getProducts()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `laptops`", db.getConnection());

            table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            bindingSource1.DataSource = table;

           dataGridView3.AutoResizeColumns(
           DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }
        private void getWorkers()
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `workers`", db.getConnection());

            table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            bindingSource1.DataSource = table;

            dataGridView4.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void button_add_product_Click(object sender, EventArgs e)
        {
            Operations.Add_product(0, textBox_brand.Text, textBox_model.Text,
            Convert.ToInt32(textBox_price.Text), (memory_type)Enum.Parse(typeof(memory_type), textBox_ram_type.Text),
            Convert.ToInt32(textBox_ram_capacity.Text),
            (color)Enum.Parse(typeof(color), textBox_color.Text),
            (proc_producer)Enum.Parse(typeof(proc_producer), textBox_proc_brand.Text),
            Convert.ToString(textBox_proc_type.Text),
            (drive_type)Enum.Parse(typeof(drive_type), textBox_disk_type.Text),
            Convert.ToInt32(textBox_disk_capacity.Text), textBox_descriptipon.Text,
            textBox_proc_model.Text,
            img1, img2);

            MessageBox.Show("Done");
            textBox_brand.Text = "";
            textBox_model.Text = "";
            textBox_price.Text = "";
            textBox_ram_type.Text = "";
            textBox_ram_capacity.Text = "";
            textBox_color.Text = "";
            textBox_proc_brand.Text = "";
            textBox_proc_type.Text = "";
            textBox_disk_type.Text = "";
            textBox_disk_capacity.Text = "";
            textBox_descriptipon.Text = "";
            textBox_proc_model.Text = "";

            if (Admin)
            {
                bindingSource1 = new BindingSource();
                dataGridView3.DataSource = bindingSource1;
                getProducts();
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }

        private void button_image1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "D:\\Desktop";

            open.Filter = "PNG(*.png) | *.png | JPG(*.jpg) | *.jpg | All files (*.*)|*.*";


            open.FilterIndex = 3;

            open.Title = "Choose the picture";

            string FileName = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileName = open.FileName;

                using (System.IO.FileStream fs = new System.IO.FileStream(FileName, FileMode.Open))
                {
                    img1 = new byte[fs.Length];
                    fs.Read(img1, 0, img1.Length);
                }
            }
        }

        private void button_image2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "D:\\Desktop";

            open.Filter = "PNG(*.png) | *.png | JPG(*.jpg) | *.jpg | All files (*.*)|*.*";


            open.FilterIndex = 3;

            open.Title = "Choose the picture";

            string FileName = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileName = open.FileName;

                using (System.IO.FileStream fs = new System.IO.FileStream(FileName, FileMode.Open))
                {
                    img2 = new byte[fs.Length];
                    fs.Read(img2, 0, img2.Length);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_new_password1.Text != textBox_new_password2.Text)
            {
                MessageBox.Show("Wrong new password");
            }
            else
            {
                if (Operations.Change_passwordW(worker.id, textBox_old_password.Text, textBox_new_password1.Text))
                {
                    MessageBox.Show("Done");
                    worker.password = textBox_new_password1.Text;
                    textBox_new_password1.Text = "";
                    textBox_new_password2.Text = "";
                    textBox_old_password.Text = "";
                    if (Admin)
                    {
                        bindingSource1 = new BindingSource();
                        dataGridView4.DataSource = bindingSource1;
                        getWorkers();
                        dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Operations.Find_worker(textBox3.Text);
            if (id != 0)
            {
                MessageBox.Show("This login is unavailable");
            }
            if (!Operations.Add_worker(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text))
            {
                MessageBox.Show("Error");
            }
            else
            {
                MessageBox.Show("Done");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

                if (Admin)
                {
                    bindingSource1 = new BindingSource();
                    dataGridView4.DataSource = bindingSource1;
                    getWorkers();
                    dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Operations.Edit_product(Convert.ToInt32(textBox12.Text),
            textBox14.Text, 
            textBox15.Text,
            Convert.ToInt32(textBox16.Text),
            (memory_type)Enum.Parse(typeof(memory_type), textBox10.Text),
            Convert.ToInt32(textBox9.Text), 
            (color)Enum.Parse(typeof(color),textBox18.Text),
            (proc_producer)Enum.Parse(typeof(proc_producer), textBox17.Text),
            Convert.ToString(textBox13.Text),
            (drive_type)Enum.Parse(typeof(drive_type),  textBox8.Text),
            Convert.ToInt32(textBox19.Text),
            textBox20.Text,
            textBox11.Text,
            img1, img2);
            MessageBox.Show("Done");

            textBox12.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
            textBox13.Text = "";
            textBox8.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox11.Text = "";


                bindingSource1 = new BindingSource();
                dataGridView3.DataSource = bindingSource1;
                getProducts();
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
           
        }

        private void button_i1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "D:\\Desktop";

            open.Filter = "PNG(*.png) | *.png | JPG(*.jpg) | *.jpg | All files (*.*)|*.*";


            open.FilterIndex = 3;

            open.Title = "Choose the picture";

            string FileName = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileName = open.FileName;

                using (System.IO.FileStream fs = new System.IO.FileStream(FileName, FileMode.Open))
                {
                    img1 = new byte[fs.Length];
                    fs.Read(img1, 0, img1.Length);
                }
            }
          
        }

        private void button_i2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "D:\\Desktop";

            open.Filter = "PNG(*.png) | *.png | JPG(*.jpg) | *.jpg | All files (*.*)|*.*";


            open.FilterIndex = 3;

            open.Title = "Choose the picture";

            string FileName = "";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileName = open.FileName;

                using (System.IO.FileStream fs = new System.IO.FileStream(FileName, FileMode.Open))
                {
                    img2 = new byte[fs.Length];
                    fs.Read(img2, 0, img2.Length);
                }
            }
        }

        private void button_del_product_Click(object sender, EventArgs e)
        {
            Operations.Delete_product(Convert.ToInt32(textBox_del_p.Text));
            MessageBox.Show("Done");
 
                bindingSource1 = new BindingSource();
                dataGridView3.DataSource = bindingSource1;
                getProducts();
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Operations.Delete_worker(Convert.ToInt32(textBox_del_w.Text));
            MessageBox.Show("Done");
            if (Admin)
            {
                bindingSource1 = new BindingSource();
                dataGridView4.DataSource = bindingSource1;
                getWorkers();
                dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
        }


    }
}
