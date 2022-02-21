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
    public partial class MyDetailsUC : UserControl
    {
        public MyDetailsUC()
        {
            InitializeComponent();
        }
        DataTable SQL_METHOD(string q, SqlConnection c2)
        {
            SqlCommand cmd = new SqlCommand(q, c2);
            cmd.ExecuteNonQuery();                //command exucusion
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);            //it convert query result in data set what we declare in 28 line
            DataTable dt = ds.Tables[0];
            return dt;
        }

        private void MyDetailsUC_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn2 = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                conn2.Open();
                string query = "select * from RoleBaseAuth where username like '" + global_user_variable_declare.user_name + "' ";

                DataTable dt = SQL_METHOD(query, conn2);
                labelUserName.Text = dt.Rows[0]["username"].ToString();
                labelID.Text = dt.Rows[0]["id"].ToString();
                labelAddress.Text = dt.Rows[0]["address"].ToString();
                labelDob.Text = dt.Rows[0]["dob"].ToString();
                labelGender.Text = dt.Rows[0]["gender"].ToString();
                labelRole.Text = dt.Rows[0]["role"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
