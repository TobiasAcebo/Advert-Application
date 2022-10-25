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
    public partial class Form7 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        int pwd;
        public Form7()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
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

        private void btnPwd_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text.Length != 10)
            {
                MessageBox.Show("Ditt lösenord innehöll inte 10 siffor");
            }

            else
            {
                try
                {
                    con.Open();
                  
                    
                        
                        cmd = new SqlCommand("Delete from Ad where ID = '" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'", con);
                        cmd.ExecuteNonQuery();
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        MessageBox.Show("Du har raderat en annons");
                       
                    

                    con.Close();

                    con.Open();
                    cmd = new SqlCommand("Select ID from Person where Ssn = '" + txtPwd.Text + "'", con);
                    cmd.ExecuteNonQuery();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        pwd = Convert.ToInt32(reader["ID"]);

                    }


                    con.Close();


                }
                catch (SqlException ex)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }
    }
}
