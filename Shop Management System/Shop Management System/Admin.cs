using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop_Management_System
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            Load+=Admin_Load;
        }

        public void SetActivePanel(UserControl control)
        {
            homeUC1.Visible = false;
            myDetailsUC1.Visible = false;
            productUC1.Visible = false;
            totalSellUC1.Visible = false;
            adminUC1.Visible = false;

            control.Visible = true;  //this control is method
        }


        private void Admin_Load(object sender, EventArgs e)
        {
            SetActivePanel(homeUC1);
            label2.Text = global_user_variable_declare.user_name;
        }


        private void buttonControlProduct_Click(object sender, EventArgs e)
        {
            SetActivePanel(productUC1);
        }



        private void buttonHome_Click(object sender, EventArgs e)
        {
            SetActivePanel(homeUC1);
        }

        private void buttonAddAdmin_Click(object sender, EventArgs e)
        {
            SetActivePanel(adminUC1);
        }

        private void buttonTotalSell_Click(object sender, EventArgs e)
        {
            SetActivePanel(totalSellUC1);
        }

        private void buttonMyDetailsAdmin_Click(object sender, EventArgs e)
        {
            SetActivePanel(myDetailsUC1);
        }

        private void LabelLogout_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
