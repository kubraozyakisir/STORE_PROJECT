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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        STOREEntities baglanti = new STOREEntities();
        public void Listele()
        {
              dataGridView1.DataSource = baglanti.Magaza.ToList();
        }
        private void button1_Click(object sender, EventArgs e) //EKLE
        {
            Magaza magaza = new Magaza();
           
            magaza.MagazaAdi = textBox1.Text;
            magaza.MagazaCiro =  Convert.ToDecimal(textBox2.Text);
            magaza.MagazaAdres =  textBox3.Text;
            magaza.SevkiyatTarih = dateTimePicker1.Value;
            magaza.SevkiyatGunu = comboBox2.Text;
            baglanti.Magaza.Add(magaza);
            baglanti.SaveChanges();
            Listele();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "MagazaNo";
            comboBox1.DataSource = baglanti.Magaza.ToList();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            comboBox1.Text = satir.Cells["MagazaNo"].Value.ToString();
            textBox1.Text = satir.Cells["MagazaAdi"].Value.ToString();
            textBox2.Text = satir.Cells["MagazaCiro"].Value.ToString();
            textBox3.Text = satir.Cells["MagazaAdres"].Value.ToString();
            dateTimePicker1.Text = satir.Cells["SevkiyatTarih"].Value.ToString();
            comboBox2.Text = satir.Cells["SevkiyatGunu"].Value.ToString();
        
        }

        private void button2_Click(object sender, EventArgs e) //SİL
        {
            int magazaNosu = Convert.ToInt32(comboBox1.Text);
            var sil = baglanti.Magaza.Where(x => x.MagazaNo == magazaNosu).FirstOrDefault();
            baglanti.Magaza.Remove(sil);
            baglanti.SaveChanges();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e) //GÜNCELLE
        {
            int magazaNosu = Convert.ToInt32(comboBox1.Text);
            var güncelle = baglanti.Magaza.Where(a => a.MagazaNo == magazaNosu).SingleOrDefault();
            güncelle.MagazaAdi = textBox1.Text;
            güncelle.MagazaCiro = Convert.ToDecimal(textBox2.Text);
            güncelle.MagazaAdres = textBox3.Text;
            güncelle.SevkiyatTarih = dateTimePicker1.Value;
            güncelle.SevkiyatGunu = comboBox2.Text;
            baglanti.SaveChanges();
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();

            form5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Magaza.Where(x => x.MagazaAdi.ToLower().Contains(textBox4.Text) || x.MagazaAdi.ToUpper().Contains(textBox4.Text)).ToList();
        }
    }
}
