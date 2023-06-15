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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        void veriGetir()
        {

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Müşteriler ", con);


            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();


        }

        
        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "";
            con = new SqlConnection("Data Source=DESKTOP-PHKFHU8\\SQLEXPRESS;Initial Catalog=EczaneOtomasyonu;Integrated Security=True");

            veriGetir();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("DELETE FROM Müşteriler WHERE TC=@p1", con);
            cmd.Parameters.AddWithValue("@p1", textBox3.Text);
          
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
           
            con.Close();

            veriGetir();

            MessageBox.Show("Müşteri Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DateTime alışTarihi = new DateTime();
            alışTarihi = DateTime.Today;

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Müşteriler(adı,soyAdı,TC,alınanİlaç,alışTarihi,adresi) VALUES (@p1,@p2,@p3,@p4,@p5,@p6) ", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", alışTarihi);
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);
           
            cmd.Connection = con;
            cmd.ExecuteNonQuery();


            con.Close();

            veriGetir();

            MessageBox.Show("Müşteri Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime alışTarihi = new DateTime();
            alışTarihi = DateTime.Today;

            con.Open();

            cmd = new SqlCommand("UPDATE Müşteriler SET adı=@p1,soyAdı=@p2,TC=@p3,alınanİlaç=@p4,alışTarihi=@p5,adresi=@p6 WHERE TC=@p3", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", alışTarihi);
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            veriGetir();

            MessageBox.Show("Müşteri Güncellendi");
        }
        //-------------------------------------------
     

        private void ilaçlar2_1_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Close();
        }


   
        private void tedarikçiler2_3_Click_1(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }
    }
    }
  
    

