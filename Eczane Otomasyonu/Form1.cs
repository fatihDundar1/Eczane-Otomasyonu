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

namespace Eczane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-PHKFHU8\\SQLEXPRESS;Initial Catalog=EczaneOtomasyonu;Integrated Security=True");
            cmd = new SqlCommand("SELECT * FROM kş WHERE şifre= @p2", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);

            con.Open();

            dr = cmd.ExecuteReader();


            if (dr.Read())
            {
               
                Form2 frm = new Form2();
                frm.Show();
               

            }
        
            else
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
           
            
            dr.Close();
            con.Close();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO kş VALUES (@p1,@p2)", con);

            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);

            con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Text = "";
        }
    }
}
