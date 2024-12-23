using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace Aabith_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lp_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (lpuname_tbl.Text == "" || lppass_tbl.Text == "")
                {
                    MessageBox.Show("Fill All the Data's");
                }
                else if (lpuname_tbl.Text == "Admin" || lppass_tbl.Text == "123")
                {
                    MessageBox.Show("Welcome Back Admin");
                    Dashboard D = new Dashboard();
                    D.Show();
                    this.Hide();
                }
                else
                {
                    SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("sp_login", Con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
                    cmd.Parameters.Add(p1).Value = lpuname_tbl.Text;

                    SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
                    cmd.Parameters.Add(p2).Value = lppass_tbl.Text;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    int a = Convert.ToInt32(ds.Tables[0].Rows.Count);
                    if (a > 0)
                    {
                        MessageBox.Show("Welcome Back "+ lpuname_tbl.Text);
                        Empdashboard ED = new Empdashboard();
                        ED.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User");
                    }
                    Con.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lpuname_tbl.Clear();
            lppass_tbl.Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lppass_tbl.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             Register R= new Register();
             R.Show();
             this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            DialogResult Check = MessageBox.Show("Are You Want to Exit?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgotpass F = new Forgotpass();
            F.Show();
            this.Hide();
        }
    }
    
}
