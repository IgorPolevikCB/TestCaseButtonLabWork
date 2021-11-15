using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCaseButtonLabWork
{
    public partial class AddForm : Form
    {

        
        private string customerName;
        private int customerID, customerAge;
        private long customerPhoneNumber;
        Random IDGenerator = new Random();


        public AddForm()
        {
            InitializeComponent();
        }

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            if(tbName.Text == "" || tbAge.Text == "" || tbPhoneNumber.Text == "")
            {
                MessageBox.Show("Please, fill all fields.");
            }
            else
            {
                customerID = IDGenerator.Next(100000, 1000000);
                customerName = tbName.Text;
                customerAge = int.Parse(tbAge.Text);
                customerPhoneNumber = long.Parse(tbPhoneNumber.Text);

                using (var newCustomer = new TestCaseBtnWorkEntities())
                {

                    newCustomer.Customers.Add(new Customers()
                    {

                        Id = customerID,
                        Name = customerName,
                        Age = customerAge,
                        Phone_number = customerPhoneNumber 

                    });

                    newCustomer.SaveChanges();
                    MessageBox.Show("New data are inserted successfully!");

                    tbName.Text = "";
                    tbAge.Text = "";
                    tbPhoneNumber.Text = "";
                  
                }

            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        
        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        

    }
}
