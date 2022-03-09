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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        STOREEntities baglanti=new STOREEntities(); 
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
        public void Listele()
        {
            dataGridView1.DataSource = baglanti.Bolum.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bolum bolum=new Bolum();

            bolum.BolumAdi = comboBox1.Text;
            bolum.BolumUrunSayisi = Convert.ToInt32(textBox2.Text);
            bolum.SorumluNo = Convert.ToInt32(textBox3.Text);
            baglanti.Bolum.Add(bolum);
            baglanti.SaveChanges();
            Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bolumno=Convert.ToInt32(textBox1.Text);
            var sil = baglanti.Bolum.Where(x=>x.BolumNo == bolumno).FirstOrDefault();
            baglanti.Bolum.Remove(sil);
            baglanti.SaveChanges();
            Listele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int bolumnosu = Convert.ToInt32(textBox1.Text);
            var güncelle = baglanti.Bolum.Where(a => a.BolumNo == bolumnosu).SingleOrDefault();
            güncelle.BolumAdi = comboBox1.Text;
            güncelle.BolumUrunSayisi = Convert.ToInt32(textBox2.Text);
            güncelle.SorumluNo = Convert.ToInt32(textBox3.Text);
            baglanti.SaveChanges();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["BolumNo"].Value.ToString();
            comboBox1.Text = satir.Cells["BolumAdi"].Value.ToString();
            textBox2.Text = satir.Cells["BolumUrunSayisi"].Value.ToString();
            textBox3.Text = satir.Cells["SorumluNo"].Value.ToString();
            

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "BolumAdi";
            comboBox1.DataSource = baglanti.Bolum.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = baglanti.Bolum.Where(x => x.BolumAdi.ToLower().Contains(textBox4.Text) || x.BolumAdi.ToUpper().Contains(textBox4.Text)).ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
