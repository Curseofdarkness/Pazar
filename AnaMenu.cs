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
    public partial class AnaMenu : Form
    {
        //MenuFrom giris = new MenuFrom();
        
        
        
        
        
        
        
        

        public AnaMenu()
        {
            InitializeComponent();
        }

        private void stokBtn_Click(object sender, EventArgs e)
        {
            FormSTOK frm = new FormSTOK();
            frm.ShowDialog();
        }

        private void AlimSatimBtn_Click(object sender, EventArgs e)
        {
            FormAlımSatım frm2 = new FormAlımSatım();
            frm2.ShowDialog();
        }

        private void FatMakBtn_Click(object sender, EventArgs e)
        {
            FormFatMak frm3 = new FormFatMak();
            frm3.ShowDialog();
        }

        private void musteriBtn_Click(object sender, EventArgs e)
        {
            FormMusteriler frm4 = new FormMusteriler();
            frm4.ShowDialog();
        }

        private void calisanBtn_Click(object sender, EventArgs e)
        {
            FormCalisanlarMenu frm5 = new FormCalisanlarMenu();
            frm5.ShowDialog();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            //giris.ShowDialog();
        }

        private void AylıkDrmBtn_Click(object sender, EventArgs e)
        {
            FormAylikDurum frm7 = new FormAylikDurum();
            frm7.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRehin frm6 = new FormRehin();
            frm6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult result = MessageBox.Show("Programı Kapatmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    
                    System.Windows.Forms.Application.Exit();
                    


                }
                else
                {
                    e.Cancel = true;


                }

            }
            else
                e.Cancel = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FormMuh frm8 = new FormMuh();
            frm8.ShowDialog();
        }

       
    }
}
