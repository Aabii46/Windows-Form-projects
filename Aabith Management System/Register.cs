using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace Aabith_Management_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult Check = MessageBox.Show("Are You Want to Logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Check == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public bool IsEmailValid(string email)
        {
            string pattern = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";

            Regex r = new Regex(pattern);
            return r.IsMatch(email);
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (reguname_tbl.Text.Trim() != "" && regpass_tbl.Text.Trim() != "" && regcpass_tbl.Text.Trim() != "" && regemail_tbl.Text.Trim() != "" && regmblnum_tbl.Text.Trim() != "")
                {
                    if (regpass_tbl.Text.Trim().Length >= 8)
                    {

                        string emailaddress = regemail_tbl.Text;
                        bool isvalid = IsEmailValid(emailaddress);

                        if (isvalid)
                        {

                            if (regpass_tbl.Text.Trim() == regcpass_tbl.Text.Trim())
                            {
                                SqlConnection Con = new SqlConnection(@"Data Source = AABITH-MUSHARAF ;Initial Catalog = Employeemanagement;Integrated Security =True");
                                Con.Open();
                                SqlCommand cmd = new SqlCommand("sp_register1", Con);
                                cmd.CommandType = CommandType.StoredProcedure;

                                SqlParameter p1 = new SqlParameter("@uname", SqlDbType.VarChar);
                                cmd.Parameters.Add(p1).Value = reguname_tbl.Text;

                                SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar);
                                cmd.Parameters.Add(p2).Value = regpass_tbl.Text;

                                SqlParameter p3 = new SqlParameter("@cpassword", SqlDbType.VarChar);
                                cmd.Parameters.Add(p3).Value = regcpass_tbl.Text;

                                SqlParameter p4 = new SqlParameter("@email", SqlDbType.VarChar);
                                cmd.Parameters.Add(p4).Value = regemail_tbl.Text;

                                SqlParameter p5 = new SqlParameter("@mblnum", SqlDbType.VarChar);
                                cmd.Parameters.Add(p5).Value = regmblnum_tbl.Text;

                                int a = cmd.ExecuteNonQuery();

                                if (a > 0)
                                {
                                    MessageBox.Show("Registered Succesfully");
                                }
                                else
                                {
                                    MessageBox.Show("Registration Failed");
                                    Con.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Miss Matching Password");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Password must have 8 digits");
                        }
                    }

                    else
                    {
                        MessageBox.Show("Enter Email in correct format");
                    }

                }
                else
                {
                    MessageBox.Show("Fill All the Data's");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 F = new Form1();
            F.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           if( WindowState == FormWindowState.Normal)
           {
                WindowState = FormWindowState.Maximized;
           }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            reguname_tbl.Clear();
            regpass_tbl.Clear();
            regcpass_tbl.Clear();
            regemail_tbl.Clear();
            regmblnum_tbl.Clear();
        }
    }
}
