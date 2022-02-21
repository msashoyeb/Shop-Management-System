using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LabelNoAccountSignup_Click(object sender, EventArgs e)
        {
            Registration obj = new Registration();
            obj.Show();
            this.Hide();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {

            global_user_variable_declare.user_name = textBox1.Text;
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Please fill up all boxes");
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter username");
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter password");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=MR-LAPS\SQLEXPRESS;Initial Catalog=SM_DB;Integrated Security=True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_role_login", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@upass", textBox2.Text);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        if (rd[6].ToString() == "admin")
                        {
                            MessageBox.Show("Successfully login as admin");

                            Admin obj = new Admin();
                            obj.Show();
                            this.Hide();
                        }
                        else if (rd[6].ToString() == "user")
                        {
                            MessageBox.Show("Successfully login as user");

                            User obj = new User();
                            obj.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
    }
}
