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

namespace Aabith_Management_System
{
    public partial class Loading2 : Form
    {
        public Loading2()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                circularProgressBar1.Value += 1;
                circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";

            if (circularProgressBar1.Value == 100)
            {
                timer1.Enabled = false;
            }

        }

        private void Loading2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
