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
    public partial class AdminUC : UserControl
    {
        private bool isNew = false;
        public AdminUC()
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

        private void AdminUC_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "select * from RoleBaseAuth";
            DataTable dt = SQL_METHOD(query, conn);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = "ID";
            textBox1.Visible = true;
            buttonUpdate.Text = "Update";
            if (e.RowIndex >= 0)
            {
                try
                {
                    int id_prim = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                    conn.Open();
                    string query = "select * from RoleBaseAuth where id=" + id_prim;
                    DataTable dt = SQL_METHOD(query, conn);
                    textBox1.Text = dt.Rows[0]["id"].ToString();
                    textBox2.Text = dt.Rows[0]["username"].ToString();
                    textBox3.Text = dt.Rows[0]["address"].ToString();
                    dateTimePicker1.Text = dt.Rows[0]["dob"].ToString();
                    textBox5.Text = dt.Rows[0]["gender"].ToString();
                    textBox6.Text = dt.Rows[0]["role"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "select * from RoleBaseAuth";

            DataTable dt = SQL_METHOD(query, conn);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            conn.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                conn.Open();
                DateTime dtp = Convert.ToDateTime(dateTimePicker1.Text);
                string query;
                if (isNew == false)
                {
                    query = " update RoleBaseAuth set username= '" + textBox2.Text + "', address= '" + textBox3.Text + "', dob= '" + dtp + "', gender= '" + textBox5.Text + "', role= '" + textBox6.Text + "' where id='" + textBox1.Text + "'";
                    MessageBox.Show("Data updated!");
                }
                else
                {
                    string pass = "123";
                    query = "insert into RoleBaseAuth (username,password,address,dob,gender,role) values ('" + textBox2.Text + "','" + pass + "','" + textBox3.Text + "','" + dtp + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    isNew = false;
                    MessageBox.Show("Successfully data inserted!");
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                query = "select * from RoleBaseAuth";

                DataTable dt = SQL_METHOD(query, conn);

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                buttonUpdate.Text = "Update";
                label1.Text = "ID";
                textBox1.Visible = true;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select a row first");
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                conn.Open();
                string query = "delete from RoleBaseAuth where id='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                query = "select * from RoleBaseAuth";
                DataTable dt = SQL_METHOD(query, conn);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                conn.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please select a row first");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                    conn.Open();
                    string query = "select * from RoleBaseAuth where username like '%" + textBox2.Text + "%' or id like '%" + textBox1.Text + "%'";

                    DataTable dt = SQL_METHOD(query, conn);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "ID will be auto generated";
                textBox1.Visible = false;
                textBox2.Text = "";
                textBox3.Text = "";
                isNew = true;
                buttonUpdate.Text = "Save";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
