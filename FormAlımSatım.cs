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
    
    public partial class FormAlımSatım : Form
    {
        FormYeniCombo frm = new FormYeniCombo();
        FormMusteriler m = new FormMusteriler();
        
        
        public FormAlımSatım()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            
            sorgu.CommandText = "makbuz_ekle";
           
            sorgu.Parameters.AddWithValue("@makbuz_tarihi",DateTime.Today.ToLocalTime() );
            sorgu.Parameters.AddWithValue("@makbuz_tutari", ((decimal.Parse(textBox3.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBox5.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBox6.Text, CultureInfo.InvariantCulture))));
            sorgu.Parameters.AddWithValue("@m_urun_cins", comboBox1.SelectedItem.ToString());
            sorgu.Parameters.AddWithValue("@m_satici_tc", textBox1.Text);
            sorgu.Parameters.AddWithValue("@m_sergi_id", 243);
            sorgu.Parameters.AddWithValue("@m_paket_aded", decimal.Parse(textBox5.Text));
            
            SqlCommand komut = new SqlCommand("select s_tckn from satici ", myCon);
            SqlDataReader okunan_veri;
            okunan_veri = komut.ExecuteReader();
            int x = 0;
            while (okunan_veri.Read())
            {
                if (textBox1.Text == okunan_veri[0].ToString())
                {
                    x = 1;
                }

            }
            if (x == 1)
            {
                okunan_veri.Close();

            }
            else
            {
                MessageBox.Show("Bu Tc numarası kayıtlı değil! Lütfen Ekleyin...", "Kayıtlı Olmayan TC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //m.ShowDialog();
                
                okunan_veri.Close();
                myCon.Close();
                this.Close();
                goto son;
            }
            
            sorgu.ExecuteNonQuery();
            SqlCommand sorgu2 = new SqlCommand("update urunler set alis_fiyati=@alis,paket_turu='" + comboBox2.SelectedItem.ToString() + "' where cins_adi='" + comboBox1.SelectedItem.ToString() + "'  ", myCon);
            sorgu2.Parameters.AddWithValue("@alis", decimal.Parse(textBox3.Text, CultureInfo.InvariantCulture));
            sorgu2.ExecuteNonQuery();


            /////hata mesajlarını ekle
            MessageBox.Show("Kayıt başarıyla eklendi!","",MessageBoxButtons.OK,MessageBoxIcon.Information);


            ////Anaparayı Etkile
            SqlCommand ana_para_al = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);

            decimal ana_paramiz = (decimal)(ana_para_al.ExecuteScalar());
            
            SqlCommand ana_para_artir = new SqlCommand("insert into muhasebe(islem_tipi,islem_tarihi,ucret,ana_para) values('Alım İşlemi',@tarih,@tutar,@ana_para-@tutar)", myCon);
            ana_para_artir.Parameters.AddWithValue("@tarih", DateTime.Today.ToLocalTime());
            ana_para_artir.Parameters.AddWithValue("@ana_para", ana_paramiz);
            ana_para_artir.Parameters.AddWithValue("@tutar", ((decimal.Parse(textBox3.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBox5.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBox6.Text, CultureInfo.InvariantCulture))));
            ana_para_artir.ExecuteNonQuery();

            ////Anaparayı Etkile


            
            son:
            
            myCon.Close();
            


        }

        private void FormAlımSatım_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            SqlCommand kmt = new SqlCommand();
            SqlDataReader read;
            kmt.Connection = myCon;
            kmt.CommandText = "select * from urunler";

            read = kmt.ExecuteReader();

            while (read.Read())
            {
                comboBox1.Items.Add(read[0].ToString());
                comboBox4.Items.Add(read[0].ToString());

            }
            comboBox1.Items.Add("Yeni ürün girin...");

            myCon.Close();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Yeni ürün girin...")
            {
                
                frm.ShowDialog();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            SqlCommand kmt = new SqlCommand();
            SqlDataReader read;
            kmt.Connection = myCon;
            kmt.CommandText = "select * from urunler";

            read = kmt.ExecuteReader();

            while (read.Read())
            {
                comboBox1.Items.Add(read[0].ToString());
                comboBox4.Items.Add(read[0].ToString());

            }
            comboBox1.Items.Add("Yeni ürün girin...");

            myCon.Close();
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Kasa")
                label15.Text = (10 * int.Parse(textBoxs5.Text)).ToString() ;
            else if (comboBox3.SelectedItem.ToString() == "Koli")
                label15.Text = (1 * int.Parse(textBoxs5.Text)).ToString() ;
            else
                label15.Text = "0";
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
            SqlCommand sorgu2 = new SqlCommand("update urunler set satis_fiyati=@satis where cins_adi='" + comboBox4.SelectedItem.ToString() + "' ", myCon);
            sorgu2.Parameters.AddWithValue("@satis",decimal.Parse(textBoxs3.Text, CultureInfo.InvariantCulture));
            sorgu2.ExecuteNonQuery();
            sorgu.CommandText = "fatura_ekle";
                        
            sorgu.Parameters.AddWithValue("@fatura_tarihi", DateTime.Today.ToLocalTime());
            sorgu.Parameters.AddWithValue("@fatura_tutari", ((decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBoxs3.Text, CultureInfo.InvariantCulture))));
            sorgu.Parameters.AddWithValue("@f_urun_cins", comboBox4.SelectedItem.ToString());
            sorgu.Parameters.AddWithValue("@f_alici_tc", textBoxs1.Text);
            sorgu.Parameters.AddWithValue("@f_sergi_id", 243);
            sorgu.Parameters.AddWithValue("@paket_adet", decimal.Parse(textBoxs5.Text));
            sorgu.Parameters.AddWithValue("@f_calisan_tc", textBoxs7.Text);
            sorgu.Parameters.AddWithValue("@f_rehin", decimal.Parse(label15.Text));


            SqlCommand komut = new SqlCommand("select a_tckn from alici ", myCon);
            SqlDataReader okunan_veri;
            okunan_veri = komut.ExecuteReader();
            int x = 0;
            while (okunan_veri.Read())
            {
                if (textBoxs1.Text == okunan_veri[0].ToString())
                {
                    x = 1;
                }

            }
            if (x == 1)
            {
                okunan_veri.Close();

            }
            else
            {
                MessageBox.Show("Bu Tc numarası kayıtlı değil! Lütfen Ekleyin...", "Kayıtlı Olmayan TC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //m.ShowDialog();

                okunan_veri.Close();
                myCon.Close();
                this.Close();
                goto bitir;
            }


            SqlCommand cmd_stok = new SqlCommand("select count(*) from stok where s_cins_adi='" + comboBox4.SelectedItem.ToString() + "' AND @satilacak > miktar", myCon);
            cmd_stok.Parameters.AddWithValue("@satilacak",textBoxs5.Text);
            int point = 0;
            point = (int)cmd_stok.ExecuteScalar();
            if (point>0)
            {
                MessageBox.Show("Stokta " + comboBox4.SelectedItem.ToString()+ " ürününden yeteri kadar yok!","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Information);
                goto bitir;
            }

            SqlCommand komut2 = new SqlCommand("select c_tckn from calisanlar ", myCon);
            SqlDataReader okunan_veri2;
            okunan_veri2 = komut2.ExecuteReader();
            int y = 0;
            while (okunan_veri2.Read())
            {
                if (textBoxs7.Text == okunan_veri2[0].ToString())
                {
                    y = 1;
                }

            }
            if (y == 1)
            {


            }
            else
            {

                MessageBox.Show("Böyle bir çalışan yok! Tekrar Deneyiniz", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                okunan_veri2.Close();
                myCon.Close();
                goto bitir;

            }
            okunan_veri2.Close();
            
            //PRİM HESAPLAMA
            SqlCommand primHesapla = new SqlCommand("select count(*) from calisanlar",myCon);
            double calisan_sayisi = 0;
            calisan_sayisi = (int)primHesapla.ExecuteScalar();
            
            double prim = double.Parse(textBoxs5.Text)*(0.5)/(calisan_sayisi) ;
            
            primHesapla.CommandText = "update calisanlar set prim=prim+@prim  ";
            primHesapla.Parameters.AddWithValue("@prim", prim);
            primHesapla.Connection = myCon;
            primHesapla.ExecuteNonQuery();
            //PRİM HESAPLAMA
            

            sorgu.ExecuteNonQuery();

            MessageBox.Show("Kayıt başarıyla eklendi!","",MessageBoxButtons.OK,MessageBoxIcon.Information);

            ////Anaparayı Etkile
            SqlCommand ana_para_al = new SqlCommand("select ana_para from muhasebe where islem_id in (select max(islem_id) from muhasebe)", myCon);

            decimal ana_paramiz = (decimal) (ana_para_al.ExecuteScalar());

            SqlCommand ana_para_artir = new SqlCommand("insert into muhasebe(islem_tipi,islem_tarihi,ucret,ana_para) values('Satış İşlemi',@tarih,@tutar,@ana_para+@tutar)", myCon);
            ana_para_artir.Parameters.AddWithValue("@tarih", DateTime.Today.ToLocalTime());
            ana_para_artir.Parameters.AddWithValue("@ana_para",ana_paramiz );
            ana_para_artir.Parameters.AddWithValue("@tutar", ((decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture)) * (decimal.Parse(textBoxs3.Text, CultureInfo.InvariantCulture))));
            ana_para_artir.ExecuteNonQuery();
            
            ////Anaparayı Etkile


            ///Alt Limit uyarısı
            SqlCommand limit_uyarisi = new SqlCommand("select count(*) from stok where s_cins_adi='"+comboBox4.SelectedItem.ToString()+"' AND alt_limit >= miktar",myCon);
            int flag = 0;
            flag = (int)limit_uyarisi.ExecuteScalar();
            if (flag > 0)
            {
                MessageBox.Show(comboBox4.SelectedItem.ToString() + " ürünü stokta belirtilen limitin altına düşmüştür!","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
            ///alt limit uyarısı
            


            ////KAR HESAPLAMA
            DateTime date = DateTime.Now;
            int gun = int.Parse(date.Day.ToString());
            int ay = int.Parse(date.Month.ToString());
            SqlCommand kar_hesapla = new SqlCommand();
            kar_hesapla.Connection = myCon;
            
           
            
            switch (ay)
            {
                    
                case 1:
                    kar_hesapla.CommandText = "update urunler set kar_ocak=kar_ocak+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar", decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture));
                    kar_hesapla.ExecuteNonQuery();
                    if (gun==31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_subat=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 2:
                    kar_hesapla.CommandText = "update urunler set kar_subat=kar_subat+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 28)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_mart=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 3:
                    kar_hesapla.CommandText = "update urunler set kar_mart=kar_mart+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_nisan=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 4:
                    kar_hesapla.CommandText = "update urunler set kar_nisan=kar_nisan+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 30)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_mayis=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 5:
                    kar_hesapla.CommandText = "update urunler set kar_mayis=kar_mayis+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_haziran=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 6:
                    kar_hesapla.CommandText = "update urunler set kar_haziran=kar_haziran+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    
                    if (gun == 30)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_temmuz=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 7:
                    kar_hesapla.CommandText = "update urunler set kar_temmuz=kar_temmuz+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_agustos=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 8:
                    kar_hesapla.CommandText = "update urunler set kar_agustos=kar_agustos+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_eylul=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 9:
                    kar_hesapla.CommandText = "update urunler set kar_eylul=kar_eylul+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 30)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_ekim=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 10:
                    kar_hesapla.CommandText = "update urunler set kar_ekim=kar_ekim+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_kasim=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 11:
                    kar_hesapla.CommandText = "update urunler set kar_kasim=kar_kasim+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 30)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_aralik=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;
                case 12:
                    kar_hesapla.CommandText ="update urunler set kar_aralik=kar_aralik+(@kar*(satis_fiyati-alis_fiyati)) where cins_adi='" + comboBox4.SelectedItem.ToString() + "'";
                    kar_hesapla.Parameters.AddWithValue("@kar",decimal.Parse(textBoxs5.Text, CultureInfo.InvariantCulture) * decimal.Parse(textBoxs6.Text, CultureInfo.InvariantCulture) );
                    kar_hesapla.ExecuteNonQuery();
                    if (gun == 31)
                    {
                        kar_hesapla.CommandText = "update urunler set kar_ocak=0 ";
                        kar_hesapla.ExecuteNonQuery();
                    }
                    break;

              
            }
            
            ///KAR HESAPLAMA



            //SqlCommand komut = new SqlCommand("select a_tckn from alici ", myCon);
            //SqlDataReader okunan_veri;
            //okunan_veri = komut.ExecuteReader();
            //int x = 0;
            //while (okunan_veri.Read())
            //{
            //    if (textBoxs1.Text == okunan_veri[0].ToString())
            //    {
            //        x = 1;
            //    }

            //}
            //if (x == 1)
            //{


            //}
            //else
            //{
            //    MessageBox.Show("Bu Tc numarası kayıtlı değil! Lütfen Ekleyin...","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    this.Hide();
            //    m.Show();
            //}
            //okunan_veri.Close();



            bitir:
            myCon.Close();

        }

        private void FormAlımSatım_FormClosing(object sender, FormClosingEventArgs e)
        {

            
        }

        

        }

        

       
    
}
