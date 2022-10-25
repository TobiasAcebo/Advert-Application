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
    public partial class Form6 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        int pwd;
        public Form6()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
        }

        private void btnPwd_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text.Length != 10)
            {
                MessageBox.Show("Ditt lösenord innehöll inte 10 siffor");
            }

            else
            {
                
                con.Open();
                cmd = new SqlCommand("Select ID from Person where Ssn = '" + txtPwd.Text + "'", con);
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                   
                    pwd = Convert.ToInt32(reader["ID"]);
                    
                }
                con.Close();

                try
                {
                    for (int item = 0; item < dataGridView1.Rows.Count - 1; item++)
                    {
                        con.Open();
                        cmd = new SqlCommand("Update Ad set CategoryID = @catid, Posted = @posted, Titel = @titel, Price = @price where ID = @id", con);
                        cmd.Parameters.AddWithValue(@"catid", dataGridView1.Rows[item].Cells[1].Value);
                        cmd.Parameters.AddWithValue(@"posted", dataGridView1.Rows[item].Cells[2].Value);
                        cmd.Parameters.AddWithValue(@"titel", dataGridView1.Rows[item].Cells[3].Value);
                        cmd.Parameters.AddWithValue(@"price", dataGridView1.Rows[item].Cells[4].Value);
                        cmd.Parameters.AddWithValue(@"id", dataGridView1.Rows[item].Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    MessageBox.Show("Du har updaterat din annons!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }


            
            
            
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void btnShowAds_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select ID, CategoryID, Posted, Titel, Price from Ad", con);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            con.Close();
        }
    }
}
