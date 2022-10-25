using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Annonsinlämmning
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        Account acc;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            cmd = new SqlCommand(constr);
            acc = new Account();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            con.Open();
            con = new SqlConnection(constr);


            string missing = "";



            if (txtName.Text == "")
            {
                missing += "Förnamn";
            }
            if (txtSurname.Text == "")
            {
                missing += ",efternamn";
            }
            if (txtEmail.Text == "")
            {
                missing += ",email";
            }
            if (txtSsn.Text == "")
            {
                missing += ",personnumer";
            }
            if (txtStreet.Text == "")
            {
                missing += ",gatuadress";
            }
            if (missing == "")
            {
                MessageBox.Show("Alla fält är ifyllda");
            }
            else
            {
                if (missing.IndexOf(",") == 0)
                {
                    missing = missing.Substring(1, missing.Length - 1);
                }

                MessageBox.Show("Följande fält saknas: " + missing);
            }

            try
            {

                con = new SqlConnection(constr);
                cmd.Connection = con;

                con.Open();

                acc.Name = txtName.Text;
                acc.Surname = txtSurname.Text;
                acc.Adress = txtStreet.Text;
                acc.Ssn = int.Parse(txtSsn.Text);
                acc.Email = txtEmail.Text;

                cmd.CommandText = "insert into Person (Name , Surname, Street, Ssn, Email) values(@name, @surname, @street, @ssn, @email)";
                cmd.Parameters.AddWithValue(@"name", txtName.Text);
                cmd.Parameters.AddWithValue(@"surname", txtSurname.Text);
                cmd.Parameters.AddWithValue(@"street", txtStreet.Text);
                cmd.Parameters.AddWithValue(@"ssn", txtSsn.Text);
                cmd.Parameters.AddWithValue(@"email", txtEmail.Text);
                cmd.ExecuteNonQuery();

                con.Close();

                Form3 frm3 = new Form3();
                frm3.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }
    }
}
