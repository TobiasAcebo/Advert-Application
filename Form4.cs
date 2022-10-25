using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace Annonsinlämmning
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        public string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
            con = new SqlConnection(constr);
            cmd = new SqlCommand();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
            con.Open();

            cmd = new SqlCommand("Select CategoryName from Category", con);
            string query = "Select Titel from Ad";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            while (dr.Read())
            {
                collection.Add(dr["CategoryName"].ToString());

            }

            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox2.AutoCompleteCustomSource = collection;

            dr.Close();
            con.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Advert ad = new Advert();
            ad.Title = textBox2.Text;
            ad.Category = textBox2.Text;

            con = new SqlConnection(constr);
            con.Open();

            listBox1.Items.Clear();

            string query = "Select a.Posted, a.Titel, a.Price, p.Name, p.Email, c.CategoryName from Ad a " +
                 "Inner Join [Person] p " +
                 "On a.PersonID = p.ID Inner Join [Category] c on c.ID = a.CategoryID Where Titel Like '" + textBox2.Text + "%' ";


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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            Advert ad = new Advert();
            ad.Title = textBox2.Text;
            ad.Category = textBox2.Text;

            con = new SqlConnection(constr);
            con.Open();

            listBox1.Items.Clear();

            string query = "Select a.Posted, a.Titel, a.Price, p.Name, p.Email, c.CategoryName from Ad a " +
                 "Inner Join [Person] p " +
                 "On a.PersonID = p.ID Inner Join [Category] c on c.ID = a.CategoryID Where Titel Like '" + textBox2.Text + "%' OR CategoryName Like '" + textBox2.Text + "%' Order By a.Posted";


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

        private void btnPrice_Click(object sender, EventArgs e)
        {
            Advert ad = new Advert();
            ad.Title = textBox2.Text;
            ad.Category = textBox2.Text;

            con = new SqlConnection(constr);
            con.Open();

            listBox1.Items.Clear();

            string query = "Select a.Posted, a.Titel, a.Price, p.Name, p.Email, c.CategoryName from Ad a " +
                 "Inner Join [Person] p " +
                 "On a.PersonID = p.ID Inner Join [Category] c on c.ID = a.CategoryID Where Titel Like '" + textBox2.Text + "%' OR CategoryName Like '" + textBox2.Text + "%' Order By a.Price";


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

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }

       
    
}
