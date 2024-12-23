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
    public partial class changepass : Form
    {
        public changepass()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
                Con.Open();
                SqlCommand cmd = new SqlCommand("sp_register_tbl", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
                cmd.Parameters.Add(p1).Value = textBox1.Text;

                SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
                cmd.Parameters.Add(p2).Value = textBox2.Text;

                SqlParameter p3 = new SqlParameter("@cpassword", SqlDbType.VarChar);
                cmd.Parameters.Add(p3).Value = textBox3.Text;


                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("Password Updation Success");
                    Form1 F = new Form1();
                    F.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Password Updation Failed!!!!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    Con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
