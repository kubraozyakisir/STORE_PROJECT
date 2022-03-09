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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        STOREEntities baglanti = new STOREEntities();
 
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Sorumluluk.Where(x => x.SorumluMaas>10000).ToList();


        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Magaza.Where(x => x.SevkiyatGunu == "Pazar,Cuma").ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Sorumluluk.Where(x => x.SorumluMaas < 10000).ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Magaza.Where(x => x.SevkiyatGunu == "Salı,Pazar").ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Magaza.Where(x => x.SevkiyatGunu == "Pazartesi,Perşembe").ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var salary = from maas in baglanti.Sorumluluk
                         orderby maas.SorumluPrim descending
                         select  maas;
            dataGridView1.DataSource = salary.Take(5).ToList();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            var adet = from sayi in baglanti.Malzeme
                         orderby sayi.MalzemeAdet descending
                         select sayi;
            dataGridView1.DataSource = adet.Take(10).ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var ciro=from money in baglanti.Magaza
                     orderby money.MagazaCiro descending
                     select money;
            dataGridView1.DataSource=ciro.Take(5).ToList(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var piazza=from store in baglanti.Magaza
                       where store.MagazaAdres=="PİAZZA"
                       select store;
            dataGridView1.DataSource = piazza.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
