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
using System.Configuration;

namespace Annonsinlämmning
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        Account acc;
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            acc = new Account();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
          



            if (txtEmail.Text == "" || txtPwd.Text == "")
            {
                MessageBox.Show("Var snäll och fyll i din information");
            }

            else
            {
                try
                {
                    con.Open();
                    acc.Email = txtEmail.Text;
                    acc.Ssn = Convert.ToInt32(txtPwd.Text);
                    con = new SqlConnection(constr);
                    string query = "Select * from Person where Email ='" + txtEmail.Text.Trim() + "' and Ssn = " + txtPwd.Text.Trim();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        Form3 frm3 = new Form3();
                        this.Hide();
                        frm3.Show();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Kolla om du har skrivit rätt");
                }


                
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }
    }
}
