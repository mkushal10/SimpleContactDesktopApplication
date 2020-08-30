using SimpleContactDesktopApplication.ContactClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleContactDesktopApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        Contact c = new Contact();
        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the value from input fields
            c.FirstName = txtFirstName.Text;
            c.LastName = txtLastName.Text;
            c.MobileNumber = txtMobileNumber.Text;
            c.Address = txtAddress.Text;
            c.Gender = comboGender.Text;

            //Inserting Data into Database using the method we created in Contact class
            bool success = c.Insert(c);
            if (success==true)
            {
                //successfully to inserte
                MessageBox.Show("New Contact Inserted.");
                clear();
            }
            else
            {
                //failed to insert
                MessageBox.Show("Failed to add new contact.");
            }
            //Load Data on Data GridView
            DataTable dt = c.Select();
            dvgContactList.DataSource = dt;
        }

        public void clear()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMobileNumber.Clear();
            txtAddress.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = c.Select();
            dvgContactList.DataSource = dt;
        }
    }
}
