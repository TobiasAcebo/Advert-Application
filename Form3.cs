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
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        
        public Form3()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            cmd = new SqlCommand(constr);
        }

        private void btnAdAdvert_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Advert ad = new Advert();
            ad.Title = textBox1.Text;
            ad.Category = textBox1.Text;

            con = new SqlConnection(constr);
            con.Open();

            listBox1.Items.Clear();

            string query = "Select a.Posted, a.Titel, a.Price, p.Name, p.Email, c.CategoryName from Ad a " +
                 "Inner Join [Person] p " +
                 "On a.PersonID = p.ID Inner Join [Category] c on c.ID = a.CategoryID Where Titel Like '" + textBox1.Text + "%'";


            cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            
          

            while (dr.Read())
            {
                string CategoryName = dr["CategoryName"].ToString();
                string Date = dr["Posted"].ToString();
                string Tit = dr["Titel"].ToString();
                string Pri = dr["Price"].ToString();
                string Nam = dr["Name"].ToString();
                string Email = dr["Email"].ToString();

                listBox1.Items.Add(CategoryName + "," + Date + "," + Tit + "," + Pri + "," + Nam + "," + Email + ",");
            }






            con.Close();
        }

        private void btnUptAdvert_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Advert ad = new Advert();
            ad.Title = textBox1.Text;
            ad.Category = textBox1.Text;

            con = new SqlConnection(constr);
            con.Open();

            listBox1.Items.Clear();

            string query = "Select a.Posted, a.Titel, a.Price, p.Name, p.Email, c.CategoryName from Ad a " +
                 "Inner Join [Person] p " +
                 "On a.PersonID = p.ID Inner Join [Category] c on c.ID = a.CategoryID Where Titel Like '" + textBox1.Text + "%' OR CategoryName Like '" + textBox1.Text + "%' Order By a.Price";


            cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                string CategoryName = dr["CategoryName"].ToString();
                string Date = dr["Posted"].ToString();
                string Tit = dr["Titel"].ToString();
                string Pri = dr["Price"].ToString();
                string Nam = dr["Name"].ToString();
                string Email = dr["Email"].ToString();

                listBox1.Items.Add(CategoryName + "," + Date + "," + Tit + "," + Pri + "," + Nam + "," + Email + ",");
            }






            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Advert ad = new Advert();
            ad.Title = textBox1.Text;
            ad.Category = textBox1.Text;

            con = new SqlConnection(constr);
            con.Open();

            listBox1.Items.Clear();

            string query = "Select a.Posted, a.Titel, a.Price, p.Name, p.Email, c.CategoryName from Ad a " +
                 "Inner Join [Person] p " +
                 "On a.PersonID = p.ID Inner Join [Category] c on c.ID = a.CategoryID Where Titel Like '" + textBox1.Text + "%' OR CategoryName Like '" + textBox1.Text + "%' Order By a.Posted";


            cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                string CategoryName = dr["CategoryName"].ToString();
                string Date = dr["Posted"].ToString();
                string Tit = dr["Titel"].ToString();
                string Pri = dr["Price"].ToString();
                string Nam = dr["Name"].ToString();
                string Email = dr["Email"].ToString();

                listBox1.Items.Add(CategoryName + "," + Date + "," + Tit + "," + Pri + "," + Nam + "," + Email + ",");
            }






            con.Close();
        }
    }


   
}
