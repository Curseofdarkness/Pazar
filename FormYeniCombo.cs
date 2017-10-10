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
    public partial class FormYeniCombo : Form
    {
        
        public FormYeniCombo()
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
            SqlCommand alt_limit_belirle = new SqlCommand("update stok set alt_limit=@limit where s_cins_adi='"+textBox1.Text+"'",myCon);
            alt_limit_belirle.Parameters.AddWithValue("@limit",int.Parse(numericUpDown1.Value.ToString()));

            sorgu.Connection = myCon;
            
            sorgu.CommandType = CommandType.StoredProcedure;

            sorgu.CommandText = "urun_ekle";
            
            sorgu.Parameters.AddWithValue("@cins_adi",textBox1.Text);
            sorgu.Parameters.AddWithValue("@alis_fiyati", 0);
            sorgu.Parameters.AddWithValue("@satis_fiyati", 0);
            sorgu.Parameters.AddWithValue("@paket_turu","");


            DialogResult result = MessageBox.Show(textBox1.Text + " adlı ürünü eklemek istediğinizse emin misiniz? ", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                goto git;
            }
            else
            {
                
                goto bitir;
            }
            git:
            sorgu.ExecuteNonQuery();

            /////hata mesajlarını ekle
            MessageBox.Show("Kayıt başarıyla eklendi!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            alt_limit_belirle.ExecuteNonQuery();

            myCon.Close();
            bitir:
            this.Close();
            

        }

        private void FormYeniCombo_Load(object sender, EventArgs e)
        {

        }

        

        


       
            

        
    }
}
