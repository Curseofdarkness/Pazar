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
    public partial class FormFatMak : Form
    {
        public FormFatMak()
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
            SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where f_alici_tc='"+textBox1.Text+"' ", myCon);

            adtr.Fill(dtst, "fatura");

            dataGridView1.DataSource = dtst.Tables["fatura"];

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
            SqlDataAdapter adtr = new SqlDataAdapter("select * From fatura where fatura_tarihi='"+dateTimePicker1.Text+"' ", myCon);

            adtr.Fill(dtst, "fatura");

            dataGridView1.DataSource = dtst.Tables["fatura"];

            adtr.Dispose();

            myCon.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormFatMak_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }
            
            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From makbuz where makbuz_tarihi='" + dateTimePicker2.Text + "' ", myCon);

            adtr.Fill(dtst, "makbuz");

            dataGridView1.DataSource = dtst.Tables["makbuz"];

            adtr.Dispose();

            myCon.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string baglanti_cumlesi = "Data Source=.; Initial Catalog=hal_otomasyonu; Integrated Security=true";
            SqlConnection myCon = new SqlConnection(baglanti_cumlesi);
            if (myCon.State == ConnectionState.Closed)
            {
                myCon.Open();
            }

            DataSet dtst = new DataSet();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From makbuz where m_satici_tc='" + textBox2.Text + "' ", myCon);

            adtr.Fill(dtst, "makbuz");

            dataGridView1.DataSource = dtst.Tables["makbuz"];

            adtr.Dispose();

            myCon.Close();
        }
    }
}
