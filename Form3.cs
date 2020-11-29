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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand a = con.CreateCommand();
            a.CommandType = CommandType.Text;
            a.CommandText = "select sales_id, prodname, price, qty, total from sales_product where qty is not null;";
            a.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(a);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("再確認してください");
            }
            else
            {
                con.Open();
                SqlCommand bui = con.CreateCommand();
                bui.CommandType = CommandType.Text;
                bui.CommandText = "select * from sales_product where sales_id = '" + textBox1.Text + "'";
                bui.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(bui);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand bui = con.CreateCommand();
            bui.CommandType = CommandType.Text;
            bui.CommandText = "select * from sales_product where dateandtime between '" + dateTimePicker2.Value.ToString() + "' and '" + dateTimePicker1.Value.ToString() + "'";
            bui.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(bui);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
    }
}
