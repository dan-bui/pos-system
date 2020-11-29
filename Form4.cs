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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("再確認してください");
            }
            else
            {
                string query = "select * from login1 where admin = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
                SqlDataAdapter bui = new SqlDataAdapter(query, con);
                DataTable minh = new DataTable();
                bui.Fill(minh);
                if (minh.Rows.Count == 1)
                {
                    Form1 a = new Form1();
                    this.Hide();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("パスワードまたはユーザー名間違います。再入力してください。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
