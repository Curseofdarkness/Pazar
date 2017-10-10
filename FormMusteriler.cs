using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hal_otomasyon_v1
{
    public partial class FormMusteriler : Form
    {
        public FormMusteriler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            
            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = myCon;
            sorgu.CommandType = CommandType.StoredProcedure;

            sorgu.CommandText = "satici_ekle";

            sorgu.Parameters.AddWithValue("@s_tckn",textBox8.Text);
            sorgu.Parameters.AddWithValue("@s_adi",textBox7.Text); 
            sorgu.Parameters.AddWithValue("@s_soyad",textBox6.Text);
            sorgu.Parameters.AddWithValue("@s_telefon",maskedTextBox2.Text);


            SqlCommand aynimi = new SqlCommand("Select count(*) from satici where s_tckn='" + textBox8.Text + "'", myCon);
            int a = (int)aynimi.ExecuteScalar();
            if (a > 0)
            {
                MessageBox.Show("Bu TC numarası kayıtlı lütfen tekrar deneyiniz!!");
                goto bitir;
            }


            sorgu.ExecuteNonQuery();
             
            /////hata mesajlarını ekle
               MessageBox.Show("Kayıt eklendi!");
           bitir:
            myCon.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            SqlCommand sorgu = new SqlCommand();
            sorgu.Connection = myCon;
            sorgu.CommandType = CommandType.StoredProcedure;

            sorgu.CommandText = "alici_ekle";

            sorgu.Parameters.AddWithValue("@a_tckn", textBox1.Text);
            sorgu.Parameters.AddWithValue("@a_adi", textBox3.Text);
            sorgu.Parameters.AddWithValue("@a_soyad", textBox5.Text);
            sorgu.Parameters.AddWithValue("@a_telefon", maskedTextBox1.Text);
            sorgu.Parameters.AddWithValue("@rehin", 0);


            SqlCommand aynimi = new SqlCommand("Select count(*) from alici where a_tckn='" + textBox1.Text + "'", myCon);
            int a = (int)aynimi.ExecuteScalar();
            if (a > 0)
            {
                MessageBox.Show("Bu TC numarası kayıtlı lütfen tekrar deneyiniz!!");
                goto bitir;
            }

            sorgu.ExecuteNonQuery();

            /////hata mesajlarını ekle
            MessageBox.Show("Kayıt eklendi!");
            bitir:
            myCon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From alici where a_tckn='" + textBox1.Text + "' ", myCon);

            adtr.Fill(dtst, "alici");

            dataGridView1.DataSource = dtst.Tables["alici"];

            adtr.Dispose();

            myCon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From alici ", myCon);

            adtr.Fill(dtst, "alici");

            dataGridView1.DataSource = dtst.Tables["alici"];

            adtr.Dispose();

            myCon.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From satici where s_tckn='"+textBox8.Text+"' ", myCon);

            adtr.Fill(dtst, "satici");

            dataGridView1.DataSource = dtst.Tables["satici"];

            adtr.Dispose();

            myCon.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From satici ", myCon);

            adtr.Fill(dtst, "satici");

            dataGridView1.DataSource = dtst.Tables["satici"];

            adtr.Dispose();

            myCon.Close();
        }

        private void FormMusteriler_Load(object sender, EventArgs e)
        {

        }
    }
}
