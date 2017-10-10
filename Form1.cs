using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace hal_otomasyon_v1
{
    public partial class MenuFrom : Form
    {
        

        public MenuFrom()
        {
            InitializeComponent();
        }

        private void t_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            string nickname = textBoxKullaniciAdi.Text;
            string parola = textBox2sifre.Text;

            SqlCommand komut = new SqlCommand("select * from Kullanicilar order by kullanici_adi,sifre", myCon);
            SqlDataReader reader;
            reader = komut.ExecuteReader();
            bool x = false;

            while (reader.Read())
            {
                if (nickname == reader["kullanici_adi"].ToString() && parola == reader["sifre"].ToString())
                {
                    x = true;


                }
            }
            if (x == true)
            {
                MessageBox.Show("Başarıyla Giriş Yaptınız", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                reader.Close();
                myCon.Close();
                AnaMenu frm = new AnaMenu();
                this.Hide();
                frm.ShowDialog();
                this.Close();
                
                
                
    
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Parola", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                reader.Close();
                myCon.Close();
            }
            
            
           // this.Close();

            
        }

        private void MenuFrom_Load(object sender, EventArgs e)
        {

        }

        private void MenuFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void MenuFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
