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
    public partial class FormRehin : Form
    {
        public FormRehin()
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
            SqlDataAdapter adtr = new SqlDataAdapter("select a_adi,a_soyad,rehin From alici where a_tckn='" + textBox1.Text + "' ", myCon);

            adtr.Fill(dtst, "alici");

            dataGridView1.DataSource = dtst.Tables["alici"];

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
            SqlCommand rehinDusur = new SqlCommand("update alici set rehin=rehin-@iade", myCon);
            
            
            
            rehinDusur.Parameters.AddWithValue("@iade",decimal.Parse(textBox2.Text));
            
            rehinDusur.ExecuteNonQuery();

            myCon.Close();
        }
    }
}
