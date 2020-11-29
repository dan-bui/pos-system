using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace quyettam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
        SqlCommand cmd1;
        SqlCommand cmd3;
        SqlCommand cmd2;

        private void Button1_Click(object sender, EventArgs e)
        {
            string name;
            int price = 0;
            int qty;
            int tot = 0;
            int interest = 0;
            int interest_of_product = 0;


            if (checkBox1.Checked && numericUpDown1.Value != 0)
            {
                name = "Blend Coffee";
                qty = int.Parse(numericUpDown1.Value.ToString());

                price = 200;
                tot = qty * price;
                interest_of_product = 90;
                interest = qty * interest_of_product;

                this.dataGridView1.Rows.Add(name, price, qty, tot);
            }
            if (checkBox2.Checked && numericUpDown2.Value != 0)
            {
                name = "Moca Coffee";
                qty = int.Parse(numericUpDown2.Value.ToString());
                price = 250;
                tot = qty * price;
                interest = 110;
                interest_of_product = qty * interest;
                this.dataGridView1.Rows.Add(name, price, qty, tot);
            }

            if (checkBox3.Checked && numericUpDown3.Value != 0)
            {
                name = "Eppresso";
                qty = int.Parse(numericUpDown3.Value.ToString());
                price = 270;
                tot = qty * price;
                interest = 150;
                interest_of_product = qty * interest;
                this.dataGridView1.Rows.Add(name, price, qty, tot);
            }

            if (checkBox4.Checked && numericUpDown4.Value != 0)
            {
                name = "Latte Coffee";
                qty = int.Parse(numericUpDown4.Value.ToString());
                price = 300;
                tot = qty * price;
                interest = 160;
                interest_of_product = qty * interest;
                this.dataGridView1.Rows.Add(name, price, qty, tot);

            }

            if (checkBox5.Checked && numericUpDown5.Value != 0)
            {
                name = "Latte Matcha";
                qty = int.Parse(numericUpDown5.Value.ToString());
                price = 400;
                tot = qty * price;
                interest = 200;
                interest_of_product = qty * interest;
                this.dataGridView1.Rows.Add(name, price, qty, tot);

            }

            if (checkBox6.Checked && numericUpDown6.Value != 0)
            {
                name = "Mango Tea";
                qty = int.Parse(numericUpDown6.Value.ToString());
                price = 450;
                tot = qty * price;
                interest = 220;
                interest_of_product = qty * interest;
                this.dataGridView1.Rows.Add(name, price, qty, tot);

            }

            int sum = 0;

            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);

            }

            textBox1.Text = sum.ToString();

        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);

                int sum = 0;
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    sum = sum + Convert.ToInt32(dataGridView1.Rows[row].Cells[3].Value);
                }

                textBox1.Text = sum.ToString();


            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            



            if (textBox4.Text == "")
            {
                int a = 0;
                label16.Text = a.ToString();
                textBox4.Text = a.ToString();
            }
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("再確認してください");
            }
            else
            {


                int pay = int.Parse(textBox2.Text);
                int total = int.Parse(textBox1.Text);
                int bal = pay - total;

                if (bal < 0)
                {
                    MessageBox.Show("再確認してください");

                }
                else
                {
                    textBox3.Text = bal.ToString();

                    salessave();

                    int qty;
                    int interest = 0;
                    int interest_of_product = 0;
                    if (checkBox1.Checked)
                    {
                        qty = int.Parse(numericUpDown1.Value.ToString());
                        interest_of_product = 90;
                        interest = qty * interest_of_product;
                        string sql3;
                        con.Open();
                        sql3 = "insert into interest1 (interest, interest_of_product) values (@interest,@interest_of_product);";

                        cmd3 = new SqlCommand(sql3, con);
                        cmd3.Parameters.AddWithValue("@interest", interest);
                        cmd3.Parameters.AddWithValue("@interest_of_product", interest_of_product);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (checkBox2.Checked)
                    {
                        qty = int.Parse(numericUpDown2.Value.ToString());
                        interest_of_product = 110;
                        interest = qty * interest_of_product;
                        string sql3;
                        con.Open();
                        sql3 = "insert into interest1 (interest, interest_of_product) values (@interest,@interest_of_product);";

                        cmd3 = new SqlCommand(sql3, con);
                        cmd3.Parameters.AddWithValue("@interest", interest);
                        cmd3.Parameters.AddWithValue("@interest_of_product", interest_of_product);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (checkBox3.Checked)
                    {
                        qty = int.Parse(numericUpDown3.Value.ToString());
                        interest_of_product = 150;
                        interest = qty * interest_of_product;
                        string sql3;
                        con.Open();
                        sql3 = "insert into interest1 (interest, interest_of_product) values (@interest,@interest_of_product);";

                        cmd3 = new SqlCommand(sql3, con);
                        cmd3.Parameters.AddWithValue("@interest", interest);
                        cmd3.Parameters.AddWithValue("@interest_of_product", interest_of_product);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                    if (checkBox4.Checked)
                    {
                        qty = int.Parse(numericUpDown4.Value.ToString());
                        interest_of_product = 160;
                        interest = qty * interest_of_product;
                        string sql3;
                        con.Open();
                        sql3 = "insert into interest1 (interest, interest_of_product) values (@interest,@interest_of_product);";

                        cmd3 = new SqlCommand(sql3, con);
                        cmd3.Parameters.AddWithValue("@interest", interest);
                        cmd3.Parameters.AddWithValue("@interest_of_product", interest_of_product);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }

                    if (checkBox5.Checked)
                    {
                        qty = int.Parse(numericUpDown5.Value.ToString());
                        interest_of_product = 200;
                        interest = qty * interest_of_product;
                        string sql3;
                        con.Open();
                        sql3 = "insert into interest1 (interest, interest_of_product) values (@interest,@interest_of_product);";

                        cmd3 = new SqlCommand(sql3, con);
                        cmd3.Parameters.AddWithValue("@interest", interest);
                        cmd3.Parameters.AddWithValue("@interest_of_product", interest_of_product);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }

                    if (checkBox6.Checked)
                    {
                        qty = int.Parse(numericUpDown6.Value.ToString());
                        interest_of_product = 220;
                        interest = qty * interest_of_product;
                        string sql3;
                        con.Open();
                        sql3 = "insert into interest1 (interest, interest_of_product) values (@interest,@interest_of_product);";

                        cmd3 = new SqlCommand(sql3, con);
                        cmd3.Parameters.AddWithValue("@interest", interest);
                        cmd3.Parameters.AddWithValue("@interest_of_product", interest_of_product);
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                }


            }
        }
        public void salessave()
        {
            if (textBox4.Text == "" || textBox4.Text != "")
            {
                string tot = textBox1.Text;
                string pay = textBox2.Text;
                string bal = textBox3.Text;
                string discount = label16.Text;
                string dateandtime = label14.Text;
                string sql1;
                string sql2;



                sql1 = "insert into sales(subtotal,pay,balance,discount,dateandtime)values(@subtotal,@pay,@balance,@discount,@dateandtime) select @@identity; ";
                con.Open();
                cmd1 = new SqlCommand(sql1, con);
                cmd1.Parameters.AddWithValue("@subtotal", tot);
                cmd1.Parameters.AddWithValue("@pay", pay);
                cmd1.Parameters.AddWithValue("@balance", bal);
                cmd1.Parameters.AddWithValue("@discount", discount);
                cmd1.Parameters.AddWithValue("@dateandtime", dateandtime);
                int lastinsertid = int.Parse(cmd1.ExecuteScalar().ToString());



                string prodname;
                int price = 0;
                int qty = 0;
                int total = 0;

                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    prodname = dataGridView1.Rows[row].Cells[0].Value.ToString();
                    price = int.Parse(dataGridView1.Rows[row].Cells[1].Value.ToString());
                    qty = int.Parse(dataGridView1.Rows[row].Cells[2].Value.ToString());
                    total = int.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString());
                    sql2 = "insert into sales_product(sales_id,prodname,price,qty,total,dateandtime)values(@sales_id,@prodname,@price,@qty,@total,@dateandtime)";
                    cmd2 = new SqlCommand(sql2, con);
                    cmd2.Parameters.AddWithValue("@sales_id", lastinsertid);
                    cmd2.Parameters.AddWithValue("@prodname", prodname);
                    cmd2.Parameters.AddWithValue("@price", price);
                    cmd2.Parameters.AddWithValue("@qty", qty);
                    cmd2.Parameters.AddWithValue("@total", total);
                    cmd2.Parameters.AddWithValue("@dateandtime", dateandtime);
                    cmd2.ExecuteNonQuery();
                }



                print p = new print();
                p.SalesID = lastinsertid;
                p.Show();
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }



        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }




        private void button5_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            label5.Text = "";
            label16.Text = "";
            dataGridView1.Rows.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dang1 = DateTime.Now;
            this.label14.Text = dang1.ToString();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin管理 a = new Admin管理();
            a.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            
            if (textBox4.Text == "")
            {
                MessageBox.Show("%を入力してください");
            }
            else
            {
                int wari = int.Parse(textBox4.Text);
                int biki = int.Parse(textBox1.Text);
                int sales = wari * biki / 100;
                int sales1 = biki - sales;
                textBox1.Text = sales1.ToString();
                label16.Text = sales.ToString();
            }
        }
        

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
