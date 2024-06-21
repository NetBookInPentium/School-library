using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolLibrary
{
    public partial class Menu : Form
    {
        Call_DB Call_DB = new Call_DB();
        public Menu()
        {
            InitializeComponent();
        }
        public void Select_table(string table)
        {
            Call_DB.Open();
            DataSet ds = Call_DB.Request($"SELECT * FROM {table}");
            dataGridView1.DataSource = ds.Tables[0];
            Call_DB.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {Select_table("Class");}
        private void button3_Click(object sender, EventArgs e)
        {Select_table("Schoolchild");}
        private void button4_Click(object sender, EventArgs e)
        {Select_table("Books");}
        private void button5_Click(object sender, EventArgs e)
        {Select_table("Books_return");}
    }
}
