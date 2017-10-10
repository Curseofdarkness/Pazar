using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hal_otomasyon_v1
{
    public partial class FormCalisanlarMenu : Form
    {
        FormCalisanEkle frmEkle = new FormCalisanEkle();
        FormCalisanSil frmSil = new FormCalisanSil();
        FormCalisanGor frmGor = new FormCalisanGor();

        public FormCalisanlarMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            frmEkle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGor.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSil.ShowDialog();
        }
    }
}
