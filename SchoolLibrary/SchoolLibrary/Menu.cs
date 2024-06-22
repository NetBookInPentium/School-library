using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolLibrary
{
    public partial class Menu : Form
    {
        Call_DB Call_DB = new Call_DB();
        public Menu()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            DataSet dataSet = Call_DB.Request("SELECT * FROM Class");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(dataSet.Tables[0].Rows[i][0]);
                comboBox6.Items.Add(dataSet.Tables[0].Rows[i][1]);
            }
            dataSet = Call_DB.Request("SELECT * FROM Books");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox3.Items.Add(dataSet.Tables[0].Rows[i][0]);
                comboBox8.Items.Add(dataSet.Tables[0].Rows[i][1]);
            }
            dataSet = Call_DB.Request("SELECT * FROM Schoolchild");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox4.Items.Add(dataSet.Tables[0].Rows[i][0]);
                comboBox7.Items.Add(dataSet.Tables[0].Rows[i][1]);
            }
            dataSet = Call_DB.Request("SELECT * FROM Books_return");
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                comboBox9.Items.Add(dataSet.Tables[0].Rows[i][0]);
            }
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO Class(namess) VALUES('{textBox1.Text}')");
                Call_DB.Close();
                Select_table("Class");
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true) 
            {
                label13.Visible = false;
                comboBox5.Visible = false;
            }
            else 
            {
                label13.Visible = true;
                comboBox5.Visible = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0 && textBox3.Text.Length > 0 && textBox4.Text.Length > 0 && comboBox1.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO Schoolchild(surnamess, namess, father_namess, id_class) VALUES('{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', {comboBox1.Text})");
                Call_DB.Close();
                Select_table("Schoolchild");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length > 0  && comboBox2.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"INSERT INTO Books(namess, style) VALUES('{textBox6.Text}', '{comboBox2.Text}')");
                Call_DB.Close();
                Select_table("Books");
                textBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string return_book;
            if ( comboBox3.Text.Length > 0 && comboBox4.Text.Length > 0)
            {
                if (checkBox1.Checked == true)
                {
                    return_book = "Возвращена";
                    ins_retr_bok(return_book);
                }
                else
                {
                    if(comboBox5.Text.Length > 0)
                    {
                        return_book = comboBox5.Text;
                        ins_retr_bok(return_book);
                    }
                    else { MessageBox.Show("Некоторые поля оставлены паустыми!"); }
                }
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }
        public void ins_retr_bok(string status)
        {
            Call_DB.Open();
            Call_DB.Request($"INSERT INTO Books_return(id_book, id_child, status) VALUES({comboBox3.Text}, {comboBox4.Text}, '{status}')");
            Call_DB.Close();
            Select_table("Books_return");
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM Class WHERE namess = '{comboBox6.Text}'");
                Call_DB.Close();
                Select_table("Class");
                comboBox6.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM Schoolchild WHERE surnamess = '{comboBox7.Text}'");
                Call_DB.Close();
                Select_table("Schoolchild");
                comboBox7.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM Books WHERE namess = '{comboBox8.Text}'");
                Call_DB.Close();
                Select_table("Books");
                comboBox8.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox9.Text.Length > 0)
            {
                Call_DB.Open();
                Call_DB.Request($"DELETE FROM Books_return WHERE id = {comboBox9.Text}");
                Call_DB.Close();
                Select_table("Books_return");
                comboBox9.Text = "";
            }
            else
            {
                MessageBox.Show("Некоторые поля оставлены паустыми!");
            }
        }
    }
}
