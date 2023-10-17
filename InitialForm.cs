using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Car_rental_system
{
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 1;
            MyProgress.Value= startPoint;
            Percentage.Text = startPoint.ToString();
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
               
                timer1.Stop();
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void InitialForm_Load(object sender, EventArgs e)
        {
           timer1.Start();
        }

        private void Percentage_Click(object sender, EventArgs e)
        {

        }
    }
}
