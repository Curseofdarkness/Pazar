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
    public partial class FormCalisanSil : Form
    {
        public FormCalisanSil()
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
            SqlCommand calisanSil = new SqlCommand("delete from calisanlar where c_tckn='"+textBox1.Text+"' ", myCon);
            if (calisanSil.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Başarıyla Silindi!");
            }
            else
            {
                MessageBox.Show("Kayıtlı Olmayan Bir TC Numarası Girdiniz!");
            }
            
            
                myCon.Close();
        }
    }
}
