using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class HistoryUC : UserControl
    {
        public HistoryUC()
        {
            InitializeComponent();
        }
        DataTable SQL_METHOD(string q, SqlConnection c2)
        {
            SqlCommand cmd = new SqlCommand(q, c2);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        private void HistoryUC_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "select * from HistoryTableUser where username in ('" + global_user_variable_declare.user_name + "') ";
            DataTable dt = SQL_METHOD(query, conn);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "select * from HistoryTableUser where username in ('" + global_user_variable_declare.user_name + "') ";

            DataTable dt = SQL_METHOD(query, conn);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "delete from HistoryTableUser where username like ('"+global_user_variable_declare.user_name+"')";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            query = "select * from HistoryTableUser where username in ('" + global_user_variable_declare.user_name + "') ";
            DataTable dt = SQL_METHOD(query, conn);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }
    }
}
