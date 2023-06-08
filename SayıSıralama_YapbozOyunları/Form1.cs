using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayıSıralama_YapbozOyunları
{
    public partial class OyunEkranı : Form
    {
        public OyunEkranı()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
        public static int YapbozkareSayisi;//Yapboz oyunu için zorluğa göre belirlenen buton sayısı.
        public static int SayıKutularıkareSayisi;//SayıKutuları oyunu için zorluğa göre belirlenen buton sayısı.
        //YAPBOZ OYUNU SEÇİLİRSE YAŞANACAK OLAYLAR Satır(26-39).
        private void YapbozOyunu_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==false&& radioButton2.Checked == false)//Yapboz oyunu için zorluğun seçilmediğini belirtme Satır(28-31).
            {
                MessageBox.Show("Yapboz oyunu için bir zorluk seçmeniz gerekli.", "Uyarı");
            }
            else//Seçilen zorluğa göre oyun formunu açma Satır(32-38).
            {
                if (radioButton1.Checked == true) { YapbozkareSayisi = 3; }
                if (radioButton2.Checked == true) { YapbozkareSayisi = 4; }
                YapbozOyunu form2 = new YapbozOyunu();
                form2.ShowDialog();//Yapboz oyunu formunu ana form olarak açma.
            }
        }
        //SAYI KUTULARI OYUNU SEÇİLİRSE YAŞANACAK OLAYLAR Satır(41-54).
        private void SayıKutularıOyunu_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false && radioButton4.Checked == false)//Sayı kutuları oyunu için zorluğun seçilmediğini belirtme Satır(43-46).
            {
                MessageBox.Show("Sayı kutuları oyunu için bir zorluk seçmeniz gerekli.", "Uyarı");
            }
            else//Seçilen zorluğa göre oyun formunu açma Satır(47-53).
            {
                if (radioButton3.Checked == true) { SayıKutularıkareSayisi = 3; }
                if (radioButton4.Checked == true) { SayıKutularıkareSayisi = 4; }
                SayıKutularıOyunu form3 = new SayıKutularıOyunu();
                form3.ShowDialog();//Sayı kutuları oyunu formunu ana form olarak açma.
            }
        }
    }
}
