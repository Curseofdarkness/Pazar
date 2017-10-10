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
    public partial class FormSTOK : Form
    {
        public FormSTOK()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select cins_adi,miktar,satis_fiyati,alis_fiyati,paket_turu From stok, urunler where s_cins_adi=cins_adi ", myCon);

            adtr.Fill(dtst,"stok");

            dataGridView1.DataSource = dtst.Tables["stok"];

            adtr.Dispose();

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

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select cins_adi,miktar,satis_fiyati,alis_fiyati,paket_turu From stok, urunler where s_cins_adi=cins_adi AND  cins_adi LIKE '%"+textBox1.Text+"%'", myCon);

            adtr.Fill(dtst,"stok");

            dataGridView1.DataSource = dtst.Tables["stok"];

            adtr.Dispose();

            myCon.Close();
            
            
        }
        }
    }

