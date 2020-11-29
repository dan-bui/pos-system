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

namespace quyettam
{
    public partial class Admin管理 : Form
    {
        public Admin管理()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e)
        {
           
        }
        public void b()
        {
            con.Open();
            SqlCommand a = con.CreateCommand();
            a.CommandType = CommandType.Text;
            a.CommandText = "select admin, password from login1 where admin is not null order by admin desc";
            a.ExecuteNonQuery();
            DataTable b = new DataTable();
            SqlDataAdapter c = new SqlDataAdapter(a);
            c.Fill(b);
            dataGridView2.DataSource = b;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Admin管理_Load(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand a = con.CreateCommand();
            a.CommandType = CommandType.Text;
            a.CommandText = "insert into login1(admin, password) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
            a.ExecuteNonQuery();
            con.Close();
            b();
            MessageBox.Show("追加しました");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand a = con.CreateCommand();
            a.CommandType = CommandType.Text;
            a.CommandText = "delete from login1 where admin = '" + textBox1.Text + "'";
            a.ExecuteNonQuery();
            con.Close();
            b();
            MessageBox.Show("取り消ししました");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("再確認してください");
            }
            else
            {
                con.Open();
                SqlCommand a = con.CreateCommand();
                a.CommandType = CommandType.Text;
                a.CommandText = "select * from login1 where admin = '" + textBox1.Text + "'";
                a.ExecuteNonQuery();
                DataTable b = new DataTable();
                SqlDataAdapter c = new SqlDataAdapter(a);
                c.Fill(b);
                dataGridView2.DataSource = b;
                con.Close();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime a = DateTime.Now;
            this.label5.Text = a.ToString();
        }

        private void Admin管理_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
            
        }
        
    }
}
