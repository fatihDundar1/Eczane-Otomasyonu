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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;


        void veriGetir()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Tedarikçiler  ", con);

            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

        }
        private void Form4_Load(object sender, EventArgs e)
        {   this.Text = "";    
            con = new SqlConnection("Data Source=DESKTOP-PHKFHU8\\SQLEXPRESS;Initial Catalog=EczaneOtomasyonu;Integrated Security=True");
            veriGetir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();

            cmd = new SqlCommand("DELETE FROM Tedarikçiler WHERE tedarikçi=@p1", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();


            con.Close();

            veriGetir();

            MessageBox.Show("Tedarikçi Silindi");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DateTime alışVerişTarihi = new DateTime();
            alışVerişTarihi = DateTime.Today;
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Tedarikçiler(tedarikçi,alışVerişTarihi) VALUES (@p1,@p2)", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", alışVerişTarihi);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();


            con.Close();

            veriGetir();

            MessageBox.Show("Tedarikçi Eklendi");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DateTime alışVerişTarihi = new DateTime();
            alışVerişTarihi = DateTime.Today;
            con.Open();

            cmd = new SqlCommand("UPDATE Tedarikçiler SET tedarikçi=@p1,alışVerişTarihi=@p2 WHERE tedarikçi=@p1", con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", alışVerişTarihi);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();


            con.Close();

            veriGetir();

            MessageBox.Show("Tedarikçi Güncellendi");
        }

        //------------------------------------------



        private void ilaçlar2_1_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Close();

        }

        private void müşteriler2_2_Click_1(object sender, EventArgs e)
        {

            Form3 frm = new Form3();
            frm.Show();
            this.Close();

        }

       

       
    }
}
