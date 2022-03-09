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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        STOREEntities baglanti = new STOREEntities();
         
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            form5.Show();
            this.Hide();
        }
        public void Listele()
        {
            dataGridView1.DataSource = baglanti.Sorumluluk.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sorumluluk sorumluluk = new Sorumluluk();

          //  sorumluluk.SorumlulukNo = Convert.ToInt32(comboBox2.Text);
            sorumluluk.MagazaNo= Convert.ToInt32(comboBox1.Text);
            sorumluluk.SorumluAdi = textBox2.Text;
            sorumluluk.SorumluMaas = Convert.ToDecimal(textBox3.Text);
            sorumluluk.SorumluPrim = Convert.ToDecimal(textBox4.Text);
            sorumluluk.SorumluVardiya = Convert.ToInt32(textBox5.Text);
            baglanti.Sorumluluk.Add(sorumluluk);
            baglanti.SaveChanges();
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Sorumluluknosu = Convert.ToInt32(comboBox2.Text);
            var sil = baglanti.Sorumluluk.Where(x => x.SorumlulukNo == Sorumluluknosu).FirstOrDefault();
            baglanti.Sorumluluk.Remove(sil);
            baglanti.SaveChanges();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Sorumluluknosu = Convert.ToInt32(comboBox2.Text);
            var güncelle = baglanti.Sorumluluk.Where(a => a.SorumlulukNo == Sorumluluknosu).SingleOrDefault();
            güncelle.MagazaNo = Convert.ToInt32(comboBox1.Text);
            güncelle.SorumluAdi = textBox2.Text;
            güncelle.SorumluMaas = Convert.ToDecimal(textBox3.Text);
            güncelle.SorumluPrim = Convert.ToDecimal(textBox4.Text);
            güncelle.SorumluVardiya = Convert.ToInt32(textBox5.Text);
            baglanti.SaveChanges();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox2.Text = satir.Cells["SorumlulukNo"].Value.ToString();
            comboBox1.Text = satir.Cells["MagazaNo"].Value.ToString();
            textBox2.Text = satir.Cells["SorumluAdi"].Value.ToString();
            textBox3.Text = satir.Cells["SorumluMaas"].Value.ToString();
            textBox4.Text = satir.Cells["SorumluPrim"].Value.ToString();
            textBox5.Text = satir.Cells["SorumluVardiya"].Value.ToString();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Magaza.ToList();
            comboBox1.ValueMember = "MagazaNo";
            comboBox2.DataSource=baglanti.Sorumluluk.ToList();
            comboBox2.ValueMember = "SorumlulukNo";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Sorumluluk.Where(x => x.SorumluAdi.ToLower().Contains(textBox6.Text) || x.SorumluAdi.ToUpper().Contains(textBox6.Text)).ToList();
        }
    }
}
