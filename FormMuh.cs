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
    public partial class FormMuh : Form
    {
        public FormMuh()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            SqlCommand sorgu = new SqlCommand("insert into muhasebe(islem_tipi,islem_tarihi,ucret,ana_para) values('Para Yatırma',@tarih,"+textBox1.Text+",@yatir+@ana_para)", myCon);
            sorgu.Parameters.AddWithValue("@tarih", DateTime.Today.ToLocalTime());
            sorgu.Parameters.AddWithValue("@ana_para", decimal.Parse(label2.Text));
            sorgu.Parameters.AddWithValue("@yatir", decimal.Parse(textBox1.Text,CultureInfo.InvariantCulture));
            sorgu.ExecuteNonQuery();
            myCon.Close();

            
            
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            SqlCommand anaPara = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);
            label2.Text = anaPara.ExecuteScalar().ToString();
            myCon.Close();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
                     
            SqlCommand anaParaGiris = new SqlCommand("insert into muhasebe(islem_tipi,islem_tarihi,ucret,ana_para) values('Ana Para Girişi',@tarih,"+textBox1.Text+","+textBox1.Text+")", myCon);
            anaParaGiris.Parameters.AddWithValue("@tarih", DateTime.Today.ToLocalTime());
            anaParaGiris.ExecuteNonQuery();
            myCon.Close();

            
            
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            SqlCommand anaPara = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);
            label2.Text = anaPara.ExecuteScalar().ToString();
            myCon.Close();
        }

        private void FormMuh_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            SqlCommand anaPara = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);
            label2.Text = anaPara.ExecuteScalar().ToString();
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

            SqlCommand sorgu = new SqlCommand("insert into muhasebe(islem_tipi,islem_tarihi,ucret,ana_para) values('Para Çekme',@tarih," + textBox1.Text + ",@ana_para-@cek)", myCon);
            sorgu.Parameters.AddWithValue("@tarih", DateTime.Today.ToLocalTime());
            sorgu.Parameters.AddWithValue("@ana_para", decimal.Parse(label2.Text));
            sorgu.Parameters.AddWithValue("@cek", decimal.Parse(textBox1.Text, CultureInfo.InvariantCulture));
            sorgu.ExecuteNonQuery();
            myCon.Close();



            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            SqlCommand anaPara = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);
            label2.Text = anaPara.ExecuteScalar().ToString();
            myCon.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Maaşları ödemek istediğinizden emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                
                            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
                            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
                            if (myCon.State == ConnectionState.Closed)
                            {
                                myCon.Open();
                            }

                            SqlCommand sorgu = new SqlCommand("select sum(c_maas+prim) from calisanlar", myCon);
                            decimal maaslar=(decimal)(sorgu.ExecuteScalar());
            
                            SqlCommand maasode = new SqlCommand("insert into muhasebe(islem_tipi,islem_tarihi,ucret,ana_para) values('Maaş Ödemeleri',@tarih,@maas,@ana_para-@maas)", myCon);
                            maasode.Parameters.AddWithValue("@tarih", DateTime.Today.ToLocalTime());
                            maasode.Parameters.AddWithValue("@ana_para", decimal.Parse(label2.Text));
                            maasode.Parameters.AddWithValue("@maas", maaslar);
                            maasode.ExecuteNonQuery();



                            if (myCon.State == ConnectionState.Closed)
                            {
                                myCon.Open();
                            }
                            SqlCommand anaPara = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);
                            label2.Text = anaPara.ExecuteScalar().ToString();
            
                            SqlCommand primsifirla = new SqlCommand("update calisanlar set prim = 0", myCon);
                            primsifirla.ExecuteNonQuery();
                            myCon.Close();

            }
            
        
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
            SqlDataAdapter adtr = new SqlDataAdapter("select * from muhasebe ", myCon);

            adtr.Fill(dtst, "muhasebe");

            dataGridView1.DataSource = dtst.Tables["muhasebe"];

            adtr.Dispose();

            myCon.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from muhasebe where islem_tipi='"+comboBox1.SelectedItem.ToString()+"' ", myCon);

            adtr.Fill(dtst, "muhasebe");

            dataGridView1.DataSource = dtst.Tables["muhasebe"];

            adtr.Dispose();

            myCon.Close();
        
        }

        


        
    }
}
