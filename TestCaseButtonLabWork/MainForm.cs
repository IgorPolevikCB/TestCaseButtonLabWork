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
    public partial class MainForm : Form
    {
        private AddForm addForm = new AddForm();

        TestCaseBtnWorkEntities ctx = new TestCaseBtnWorkEntities();

        public MainForm()
        {
            InitializeComponent();
            updateData();
        }

        public void updateData()
        {
            ctx = null;
            ctx = new TestCaseBtnWorkEntities();
            dataGridView1.DataSource = customersBindingSource.DataSource =
                ctx.Customers.ToList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addForm.ShowDialog();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            ctx.SaveChanges();
            MessageBox.Show("All changes are saved!");
        }
    }
}
