using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitySonKisim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbOgrenciSinavEntities db = new DbOgrenciSinavEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLOGRENCI.OrderBy(x => x.SEHIR).GroupBy(y => y.SEHIR).Select(z =>
                new
                {
                    Şehir = z.Key,
                    Toplam = z.Count()
                });
            dataGridView1.DataSource = degerler.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var deger = db.TBLOGRENCI.GroupBy(y=>y.SEHIR).Select(z =>
                new
                {
                    Sehir = z.Key,
                    Toplam = z.Count()
                }).OrderByDescending(a=>a.Toplam);
            dataGridView1.DataSource = deger.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = db.TBLNOTLAR.Max(x => x.ORTALAMA).ToString();
            label2.Text = db.TBLNOTLAR.Min(x => x.ORTALAMA).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = db.TBLNOTLAR.Where(x => x.DURUM == false).Max(y => y.ORTALAMA).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Text = db.TBLURUN.Count().ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = db.TBLURUN.Average(x => x.FIYAT).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label7.Text = (from x in db.TBLURUN
                           orderby x.STOK descending
                           select x.AD).First();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.OGRKULUPLER();
        }
    }
}
