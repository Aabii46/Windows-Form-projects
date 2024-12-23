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

namespace Aabith_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult Check = MessageBox.Show("Are You Want to Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Check == DialogResult.Yes)
            {
                MessageBox.Show("Logout Successfully");
                Form1 F = new Form1();
                F.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("sp_emp_register", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = textBox4.Text;

            SqlParameter p2 = new SqlParameter("@emp_name", SqlDbType.VarChar);
            cmd.Parameters.Add(p2).Value = textBox1.Text;

            SqlParameter p3 = new SqlParameter("@emp_salary", SqlDbType.VarChar);
            cmd.Parameters.Add(p3).Value = textBox2.Text;

            SqlParameter p4 = new SqlParameter("@emp_dept", SqlDbType.VarChar);
            cmd.Parameters.Add(p4).Value = comboBox1.SelectedItem.ToString();

            SqlParameter p5 = new SqlParameter("@emp_role", SqlDbType.VarChar);
            cmd.Parameters.Add(p5).Value = comboBox2.SelectedItem.ToString();

            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MessageBox.Show("Employee Details Added");
            }
            else
            {
                MessageBox.Show("Failed!!!!");
                Con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("sp_fetch", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter SD = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            SD.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            Con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Check = MessageBox.Show("Are You Want to delete Employee?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Check == DialogResult.Yes)
            {
                SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox3.Text;

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Data Deleted Successfully");
                }

                Con.Close();



            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
            Con.Open();
            SqlCommand cmd = new SqlCommand("sp_search", Con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@searchdata", SqlDbType.VarChar);
            cmd.Parameters.Add(p1).Value = textBox3.Text;

            SqlDataAdapter SD = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            SD.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
            Con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_update", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@emp_id", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox4.Text;

                SqlParameter p2 = new SqlParameter("@emp_name", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox1.Text;

                SqlParameter p3 = new SqlParameter("@emp_salary", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox2.Text;

                SqlParameter p4 = new SqlParameter("@emp_dept", SqlDbType.VarChar);
                cmd.Parameters.Add(p4).Value = comboBox1.SelectedItem.ToString();

                SqlParameter p5 = new SqlParameter("@emp_role", SqlDbType.VarChar);
                cmd.Parameters.Add(p5).Value = comboBox2.SelectedItem.ToString();

                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Data Updated");
                }
                else
                {
                    MessageBox.Show("Updation Failed!!!!");
                    Con.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap B = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(B, new Rectangle(0, 0 ,dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(B, 120, 120);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
