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
    public partial class FormCalisanEkle : Form
    {
        public FormCalisanEkle()
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

            sorgu.CommandText = "calisan_ekle";

            sorgu.Parameters.AddWithValue("@c_tckn",textBox1.Text);
            sorgu.Parameters.AddWithValue("@c_ad", textBox2.Text);
            sorgu.Parameters.AddWithValue("@c_soyad", textBox3.Text);
            sorgu.Parameters.AddWithValue("@c_telefon", maskedTextBox1.Text);
            sorgu.Parameters.AddWithValue("@c_maas", textBox4.Text);
            sorgu.Parameters.AddWithValue("@c_sergi_id", 243);


           SqlCommand aynimi = new SqlCommand("Select count(*) from calisanlar where c_tckn='" + textBox1.Text+"'",myCon);
           int a=(int)aynimi.ExecuteScalar();
            if (a>0)
           {
               MessageBox.Show("Bu TC numarası kayıtlı lütfen tekrar deneyiniz!!");
               goto bitir;
           }
           
            sorgu.ExecuteNonQuery();

            MessageBox.Show("Kayıt eklendi  calisanlar!");
            bitir:
            myCon.Close();
        }
    }
}
