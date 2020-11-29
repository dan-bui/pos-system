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
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD68PI5;Initial Catalog=Milk;Integrated Security=True");
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlDataAdapter dr;

        private int salesid;

        public int SalesID
        {
            get { return salesid; }
            set { salesid = value; }
        }


        private void Print_Load(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            cmd1 = new SqlCommand("select * from sales where id ='" + SalesID + "'", con);
            dr = new SqlDataAdapter(cmd1);
            dr.Fill(dt);

            DataTable dt1 = new DataTable();
            cmd2 = new SqlCommand("select * from sales_product where sales_id ='" + SalesID + "'", con);
            dr = new SqlDataAdapter(cmd2);
            dr.Fill(dt1);
            con.Close();

            CrystalReport2 cr2 = new CrystalReport2();
            cr2.Database.Tables["sales"].SetDataSource(dt);
            cr2.Database.Tables["sales_product"].SetDataSource(dt1);
            this.crystalReportViewer1.ReportSource = cr2;
        }
    }
}
