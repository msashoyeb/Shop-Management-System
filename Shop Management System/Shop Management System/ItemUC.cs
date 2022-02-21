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
    public partial class ItemUC : UserControl
    {
        public ItemUC()
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

        private void ItemUC_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "select * from ProductListTable";
            DataTable dt = SQL_METHOD(query, conn);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int p_code = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                    SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                    conn.Open();
                    string query = "select * from ProductListTable where product_code=" + p_code;
                    DataTable dt = SQL_METHOD(query, conn);
                    textBox1.Text = dt.Rows[0]["product_code"].ToString();
                    textBox2.Text = dt.Rows[0]["name"].ToString();
                    textBox3.Text = dt.Rows[0]["amount"].ToString();
                    textBox4.Text = dt.Rows[0]["quantity"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void buttonAddCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please select a row first");
                }

                else
                {
                    if (textBoxOrderQuantity.Text == "")
                    {
                        MessageBox.Show("Please enter quantity");
                    }
                    else
                    {
                        SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                        conn.Open();

                        int bill = 0, new_quantity=0;

                        int box_order = Convert.ToInt32(textBoxOrderQuantity.Text);
                        int box_have = Convert.ToInt32(textBox4.Text);
                        int box_price = Convert.ToInt32(textBox3.Text);

                        if (box_order > box_have && box_have !=0)
                        {
                            MessageBox.Show("Out of our stock range!");
                        }
                        else if (box_order > box_have && box_have == 0)
                        {
                            MessageBox.Show("There are no products left in our stock!");
                        }
                        else if (box_have!=0 && box_order == 0)
                        {
                            MessageBox.Show("You should order at list 1 product");
                        }
                        else if (box_have == 0 && box_order == 0)
                        {
                            MessageBox.Show("Order not successful");
                        }
                        else
                        {
                            bill += (box_price * box_order);
                            new_quantity += (box_have - box_order);

                            string query = "insert into HistoryTableUserTemp (product_code,username,product_name,amount,quantity,order_quantity,total_bill) values ('" + textBox1.Text + "','" + global_user_variable_declare.user_name + "','" + textBox2.Text + "', '" + textBox3.Text + "' , '" + textBox4.Text + "','" + textBoxOrderQuantity.Text + "','" + bill + "') ";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("This product added into the cart!");

                            query = " update ProductListTable set quantity= '" + new_quantity + "' where product_code='" + textBox1.Text + "'";
                            cmd = new SqlCommand(query, conn);
                            cmd.ExecuteNonQuery();

                            query = "select * from ProductListTable";
                            DataTable dt = SQL_METHOD(query, conn);

                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = dt;
                            dataGridView1.Refresh();
                            conn.Close();
                            bill = 0;
                            new_quantity = 0;
                            textBoxOrderQuantity.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
            conn.Open();
            string query = "select * from ProductListTable";

            DataTable dt = SQL_METHOD(query, conn);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBoxOrderQuantity.Text = "";
            conn.Close();
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
                    string query = "select * from ProductListTable where name like '%" + textBox5.Text + "%' or product_code like '%" + textBox5.Text + "%'";

                    DataTable dt = SQL_METHOD(query, conn);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    textBox1.Text = dt.Rows[0]["product_code"].ToString();
                    textBox2.Text = dt.Rows[0]["name"].ToString();
                    textBox3.Text = dt.Rows[0]["amount"].ToString();
                    textBox4.Text = dt.Rows[0]["quantity"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
