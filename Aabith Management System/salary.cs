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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aabith_Management_System
{
    public partial class salary : Form
    {
        public salary()
        {
            InitializeComponent();
        }

        private void salary_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Green;
            radioButton2.ForeColor = Color.Red;

            comboBox1.Items.Clear();

            comboBox1.Items.Add("Vijay");
            comboBox1.Items.Add("Ajith");
            comboBox1.Items.Add("Surya");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = Color.Red;
            radioButton2.ForeColor = Color.Green;

            comboBox1.Items.Clear();

            comboBox1.Items.Add("Karthi");
            comboBox1.Items.Add("Kamal");
            comboBox1.Items.Add("Dhanush");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "Vijay")
            {
                textBox1.Text = "50000";
            }
            else if (comboBox1.SelectedItem.ToString() == "Ajith")
            {
                textBox1.Text = "40000";
            }
            else if (comboBox1.SelectedItem.ToString() == "Surya")
            {
                textBox1.Text = "35000";
            }
            else if (comboBox1.SelectedItem.ToString() == "Karthi")
            {
                textBox1.Text = "25000";
            }
            else if (comboBox1.SelectedItem.ToString() == "Kamal")
            {
                textBox1.Text = "20000";
            }
            else if (comboBox1.SelectedItem.ToString() == "Dhanush")
            {
                textBox1.Text = "15000";
            }
            else
            {
                textBox1.Text = "0";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length > 0)
            {
                textBox3.Text = (Convert.ToInt32 (textBox1.Text) + Convert.ToInt32 (textBox2.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("sp_salary_tbl", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = comboBox1.SelectedItem.ToString();

            SqlParameter p2 = new SqlParameter("@salary", SqlDbType.VarChar);
            cmd.Parameters.Add(p2).Value = textBox1.Text;

            SqlParameter p3 = new SqlParameter("@bonus", SqlDbType.VarChar);
            cmd.Parameters.Add(p3).Value = textBox2.Text;

            SqlParameter p4 = new SqlParameter("@total", SqlDbType.VarChar);
            cmd.Parameters.Add(p4).Value = textBox3.Text;

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Salary Added");
            }
            else
            {
                MessageBox.Show("Failed!!!!");
                Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("sp_salary_fetch", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SD = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            SD.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            Con.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightSeaGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.Linen;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Image Files(*.jpg;*jpeg;*.png;*.gif;*.bmp)|*.jpg;*jpeg;*.png;*.gif;*.bmp| All Files(*.*)|*.*";
            openfiledialog.FilterIndex = 1;
            openfiledialog.RestoreDirectory = true;

            if(openfiledialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openfiledialog.FileName);
            }

        } 
    }
}
