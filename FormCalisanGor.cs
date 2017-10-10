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
    public partial class FormCalisanGor : Form
    {
        public FormCalisanGor()
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

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select c_tckn,c_ad,c_soyad,c_telefon,c_maas,c_sergi_id From calisanlar where c_tckn='"+textBox1.Text+"' ", myCon);

            adtr.Fill(dtst, "calisanlar");

            dataGridView1.DataSource = dtst.Tables["calisanlar"];

            adtr.Dispose();

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

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From calisanlar ", myCon);

            adtr.Fill(dtst, "calisanlar");

            dataGridView1.DataSource = dtst.Tables["calisanlar"];

            adtr.Dispose();

            myCon.Close();
        }
    }
}
