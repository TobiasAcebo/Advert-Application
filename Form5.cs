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
    public partial class Form5 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        Advert advert;
        string cat;
        int pwd;
        public Form5()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
            advert = new Advert();
            Combobox();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            con.Open();
            con = new SqlConnection(constr);


            string missing = "";

            if (comboBox1.Text == "")
            {
                missing += "Categori";
            }
            if (txtDate.Text == "")
            {
                missing += ",datum";
            }
            if (txtTitle.Text == "")
            {
                missing += ",titel";
            }
            if (txtPrice.Text == "")
            {
                missing += ",pris";
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
                con.Open();

                con = new SqlConnection(constr);
                string query = "Select * from Person where Ssn ='" + txtPwd.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Kontrollera om du har skrivit rätt lösenord");
            }
            finally
            {
                con = new SqlConnection(constr);
                cmd.Connection = con;

                con.Open();

                advert.Category = comboBox1.Text;
                advert.Date = txtDate.Text;
                advert.Title = txtTitle.Text;
                advert.Price = int.Parse(txtPrice.Text);
                

                cmd = new SqlCommand("Select ID from Person where Ssn = '" + txtPwd.Text + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pwd = Convert.ToInt32(reader["ID"]);
                }

                con.Close();

                con.Open();

                cmd.CommandText = "insert into Ad (CategoryID , Posted, Titel, Price, PersonID) values(@categoryid, @posted, @titel, @price, @personid)";
                cmd.Parameters.AddWithValue(@"categoryid", cat);
                cmd.Parameters.AddWithValue(@"posted", txtDate.Text);
                cmd.Parameters.AddWithValue(@"titel", txtTitle.Text);
                cmd.Parameters.AddWithValue(@"price", int.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue(@"personid", pwd);
                cmd.ExecuteNonQuery();

                con.Close();
            }

            con.Close();

            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void Combobox()
        {
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("Select CategoryName, ID From Category",con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["CategoryName"].ToString());
                comboBox1.DisplayMember = (dr["CategoryName"].ToString());
                comboBox1.ValueMember = (dr["ID"].ToString());
            }

            con.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("Select ID From Category where CategoryName ='" + comboBox1.SelectedItem + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cat = dr[0].ToString();
            }

            con.Close();
        }
    }
}
