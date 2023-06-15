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
    public partial class Form2 : Form
    {
        public Form2()
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

            SqlCommand cmd = new SqlCommand("SELECT * FROM İlaçlar  ", con);


            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "";

            con = new SqlConnection("Data Source=DESKTOP-PHKFHU8\\SQLEXPRESS;Initial Catalog=EczaneOtomasyonu;Integrated Security=True");


            veriGetir();

        }

        private void button1_Click(object sender, EventArgs e)
        {// İlaç SİLME
            con.Open();

            cmd = new SqlCommand("DELETE FROM İlaçlar WHERE ilaçAdı=@p1", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            veriGetir();

            MessageBox.Show("İlaç Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String KullanmaŞekli = comboBox1.Text;

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO İlaçlar (ilaçAdı,skt,fiyat,firma,kullanmaŞekli,stok ) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", KullanmaŞekli);
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            veriGetir();

            MessageBox.Show("İlaç Eklendi");




        }

        private void button3_Click(object sender, EventArgs e)
        {
            String KullanmaŞekli = comboBox1.Text;
            con.Open();

            cmd = new SqlCommand("UPDATE İlaçlar SET ilaçAdı=@p1,skt=@p2,fiyat=@p3,firma=@p4,kullanmaŞekli=@p5,stok=@p6 WHERE ilaçAdı=@p1", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", textBox2.Text);
            cmd.Parameters.AddWithValue("@p3", textBox3.Text);
            cmd.Parameters.AddWithValue("@p4", textBox4.Text);
            cmd.Parameters.AddWithValue("@p5", KullanmaŞekli);
            cmd.Parameters.AddWithValue("@p6", textBox6.Text);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            veriGetir();

            MessageBox.Show("İlaç Güncellendi");
        }

        //-------------------------------------------


        private void müşteriler2_2_Click(object sender, EventArgs e)
        {

            Form3 frm = new Form3();
            frm.Show();
            this.Close();

        }

        private void tedarikçiler2_3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }

    }
}
