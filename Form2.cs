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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e)
        {
            string str = (@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter da;
            
            DataSet ds;

            string query = "select prodname as 商品名, sum(qty) as 販売数 from sales_product group by prodname";
            
            da = new SqlDataAdapter(query, con);
            
            ds = new DataSet();
            da.Fill(ds);
            
            con.Close();
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = (@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd;

            string query = "SELECT SUM(total) FROM sales_product";
            try
            {
                con.Open();

                cmd = new SqlCommand(query, con);
                Int32 dang = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                label5.ForeColor = Color.Blue;
                label5.Text = "一日の合計金額 " + dang.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string str = (@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd;

            string query = "SELECT SUM(interest) FROM interest1";
            try
            {
                con.Open();

                cmd = new SqlCommand(query, con);
                Int32 dang = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                con.Close();
                label3.ForeColor = Color.Blue;
                label3.Text = "一日の売上 " + dang.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
