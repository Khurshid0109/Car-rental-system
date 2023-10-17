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

namespace Car_rental_system
{
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\xurshid\Documents\CarRentalDb.mdf;Integrated Security=True;Connect Timeout=30");
        public UserForm()
        {
            InitializeComponent();
        }

        private void populate()
        {
            con.Open();
            string query = "select * from UserTable";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var ds=new DataSet();
            adapter.Fill(ds);
            dataGridViewUsers.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UId.Text == "" || UName.Text == "" || UPass.Text == "")
                MessageBox.Show("Missing data");
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into UserTable " +
                        "values(" + UId.Text + ",'" + UName.Text + "','" + UPass.Text + "')";

                    SqlCommand cmd=new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User succesfully added");
                    populate();
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
