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
    public partial class FormAylikDurum : Form
    {
        public FormAylikDurum()
        {
            InitializeComponent();
        }

        private void FormAylikDurum_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hal_otomasyonuDataSet.urunler' table. You can move, or remove it, as needed.
            this.urunlerTableAdapter.Fill(this.hal_otomasyonuDataSet.urunler);
            
            comboBox1.Items.Clear();
            
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
                

            }
            this.chart1.Show();

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
            SqlDataAdapter adaptor = new SqlDataAdapter("select * from urunler where cins_adi='" + comboBox1.SelectedItem.ToString() + "'", myCon);
            DataSet ds = new DataSet();
            adaptor.Fill(ds);

            DataView source = new DataView(ds.Tables[0]);

            chart1.DataSource = source;

            chart1.DataBind();

            myCon.Close();
           
        }
    }
}
