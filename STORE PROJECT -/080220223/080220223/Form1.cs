using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _080220223
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        STOREEntities baglanti = new STOREEntities();
        private bool giris_yap(string ad, string sifre)
        {

            var sorgu = from p in baglanti.Kullanicilar
                        where p.KullaniciAdSoyad == ad && p.Sifre == sifre
                        select p;
            if (sorgu.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (giris_yap(textBox1.Text, textBox2.Text))
            {
                Form5 form5 = new Form5();
                form5.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI GİRİŞ YAPILDI.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //burada kullanicilardan bir nesne üretttik ve yeni kişiye değer atadıkk
            Kullanicilar kullanicilar = new Kullanicilar();

            kullanicilar.KullaniciAdSoyad = textBox4.Text;
            kullanicilar.Sifre =  textBox3.Text; 
            baglanti.Kullanicilar.Add(kullanicilar);  //SQL e atma bölümü
            baglanti.SaveChanges(); //değişiklikleri kaydet
        }
    }
}
