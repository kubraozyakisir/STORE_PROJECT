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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        STOREEntities baglanti = new STOREEntities();
        public void Listele()
        {
            dataGridView1.DataSource = baglanti.Malzeme.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Malzeme malzeme = new Malzeme();
            
            //malzeme.MalzemeNo = comboBox2.Text;
            malzeme.MagazaNo = Convert.ToInt32(comboBox1.Text);
            malzeme.MalzemeAdi = textBox2.Text;
            malzeme.MalzemeAdet = Convert.ToInt32(numericUpDown1.Text);
            malzeme.MalzemeBirimFiyat = Convert.ToDecimal(textBox4.Text);
            malzeme.MalzemeKod = Convert.ToInt32(textBox5.Text);
            malzeme.MalzemeAciklama = richTextBox1.Text;
            baglanti.Malzeme.Add(malzeme);
            baglanti.SaveChanges();
            Listele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();  
           
            form5.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int malzemenosu = Convert.ToInt32(comboBox2.Text);
            var sil = baglanti.Malzeme.Where(x => x.MalzemeNo == malzemenosu).FirstOrDefault();
            baglanti.Malzeme.Remove(sil);
            baglanti.SaveChanges();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int malzemenosu = Convert.ToInt32(comboBox2.Text);
            var güncelle = baglanti.Malzeme.Where(a => a.MalzemeNo == malzemenosu).SingleOrDefault();
            güncelle.MagazaNo =int.Parse(comboBox1.Text);
            güncelle.MalzemeAdi = textBox2.Text;
            güncelle.MalzemeAdet = Convert.ToInt32(numericUpDown1.Text);
            güncelle.MalzemeBirimFiyat = decimal.Parse(textBox4.Text);
            güncelle.MalzemeKod = Convert.ToInt32(textBox5.Text);
            güncelle.MalzemeAciklama = richTextBox1.Text;
            baglanti.SaveChanges();
            Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;

            comboBox2.Text= satir.Cells["MalzemeNo"].Value.ToString();
            comboBox1.Text = Convert.ToString(satir.Cells["MagazaNo"].Value);
            textBox2.Text = satir.Cells["MalzemeAdi"].Value.ToString();
            numericUpDown1.Text = satir.Cells["MalzemeAdet"].Value.ToString();
            textBox4.Text =Convert.ToString( satir.Cells["MalzemeBirimFiyat"].Value);
            textBox5.Text = satir.Cells["MalzemeKod"].Value.ToString();
            richTextBox1.Text = satir.Cells["MalzemeAciklama"].Value.ToString();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = baglanti.Magaza.ToList();
            comboBox1.ValueMember = "MagazaNo";
            comboBox2.DataSource=baglanti.Malzeme.ToList();
            comboBox2.ValueMember = "MalzemeNo";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Malzeme.Where(x => x.MalzemeAdi.ToLower().Contains(textBox3.Text) || x.MalzemeAdi.ToUpper().Contains(textBox3.Text)).ToList();
        }
    }
}
