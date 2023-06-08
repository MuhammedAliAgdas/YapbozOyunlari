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
    public partial class SayıKutularıOyunu : Form
    {
        public SayıKutularıOyunu()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int[] BenzersizSayilar = new int[OyunEkranı.SayıKutularıkareSayisi* OyunEkranı.SayıKutularıkareSayisi];
        //SAYIKUTULARI OYUNU FORMU YÜKLENDİĞİNDE YAŞANACAK OLAYLAR Satır(22-61).
        private void SayıKutularıOyunu_Load(object sender, EventArgs e)
        {
            int randomSayi;
            for (int k = 0; k <= (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi-1); k++)//BenzersizSayılar dizisini sıralı sayılarla doldurma Satır(25-28).
            {
                BenzersizSayilar[k] = (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi + 1);
            }
            //BenzersizSayılar dizisini random sayılar atama Satır(30-37).
            for (int j = 0; j <= (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi - 1); j++)
            {
                do
                {
                    randomSayi = rnd.Next(1, (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi + 1));
                } while (Array.IndexOf(BenzersizSayilar, randomSayi) > -1);
                BenzersizSayilar[j] = randomSayi;
            }
            //Seçilen zorluğa göre butonlar oluşturma boyutlarını ayarlama hepsine random sayı atama ve yerleştirme Satır(39-61).
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;//Butonların konum değişkenleri.
            for (int i = 1; i <= OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi; i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = BenzersizSayilar[i-1].ToString();
                btn.BackColor = Color.LightGray;
                if (btn.Text== (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi).ToString()) { btn.Text = "";}
                btn.Click += btn_click;
                if (OyunEkranı.SayıKutularıkareSayisi == 3) { btn.Size = new Size(133, 133); btn.Location = new Point(x1, y1); }
                if (OyunEkranı.SayıKutularıkareSayisi == 4) { btn.Size = new Size(100, 100); btn.Location = new Point(x2, y2); }
                x1 += 133;
                x2+= 100;
                if (i % OyunEkranı.SayıKutularıkareSayisi == 0)
                {
                    y1 += 133;
                    x1 = 0;
                    y2 += 100;
                    x2 = 0;
                }
                btn.Enabled=false;
                groupBox1.Controls.Add(btn);
            }
        }
        //BUTONLARA TIKLANILARAK ÜZERLERİNDEKİ SAYILARI DEĞİŞTİRME Satır(64-83).
        string sayiDegistirme;
        Button tikla1, tikla2;
        int tikSayisi = 0;
        Boolean boslukTik = false;
        private void btn_click(object sender, EventArgs e)
        {
            Button tiklananButon= (Button)sender;
            tikSayisi++;
            if (tikSayisi % 2 == 1 && tiklananButon.Text == "") {tikla1 = tiklananButon; boslukTik = true;}//İlk tıklanılan butonu belirleme ve textini alma.
            if (tikSayisi %2==0 && tiklananButon.Text != "" && boslukTik==true)//İlk tıklanılan ile ikinci tıklanılan butonlarn sayılarını değiştirme Satır(73-80).
            {
                sayiDegistirme = tiklananButon.Text;
                tikla2 = tiklananButon;
                tikla1.Text= sayiDegistirme;
                tikla2.Text = "";
                boslukTik = false;
            }
            label1.Text = "Hareket Sayısı: " + tikSayisi / 2;
            oyunBitis();//oyunBitis fonksiyonunu çağırma.
        }
        int bitisSayaci = 0;
        Boolean direktKapanis=false;
        //OYUNUN BİTİP BİTMEDİĞİNİ KONTROL EDEN FONKSİYON Satır(87-119).
        private void oyunBitis()
        {
            for (int i = 1; i <= (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi - 1); i++)//Sayı doğru sırasına geldiğinde butonun yeşil rengi almasını sağlama Satır(89-99).
            {
                if(((Button)this.groupBox1.Controls[i.ToString()]).Name== ((Button)this.groupBox1.Controls[i.ToString()]).Text)
                {
                    ((Button)this.groupBox1.Controls[i.ToString()]).BackColor = Color.Green;
                }
                else
                {
                    ((Button)this.groupBox1.Controls[i.ToString()]).BackColor = Color.LightGray;
                }
            }
            var nesneler = groupBox1.Controls.OfType<Button>();//Gorubox1 deki butonları nesneler değişkenine atma.

            foreach (var nesne in nesneler)//Bütün butonlar yeşil mi diye kontrol etme(102-108).
            {
                if (nesne.BackColor==Color.Green)
                {
                    bitisSayaci++;
                }
            }
            if (bitisSayaci != (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi-1)) { bitisSayaci = 0;}//Bütün butonlar yeşil değilse sayacı sıfırlama.
            else //Bütün butonlar yeşilse yaşanacak olaylar Satır(110-119).
            {
                ((Button)this.groupBox1.Controls[(OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi).ToString()]).BackColor=Color.Green;
                if (tikSayisi /2<=150) { MessageBox.Show(tikSayisi / 2 + " Hamlede kazandındınız.", "ÜST SEVİYE BAŞARI!!!"); }
                if (tikSayisi / 2 >= 150&& tikSayisi / 2 <= 300) { MessageBox.Show(tikSayisi / 2 + " Hamlede kazandındınız.", "ORTA SEVİYE BAŞARI!!!");}
                if (tikSayisi / 2 >=300) { MessageBox.Show(tikSayisi / 2 + " Hamlede kazandındınız.", "DÜŞÜK SEVİYE BAŞARI!!!");}
                direktKapanis = true;//Eğer oyun bittiyse formu direkt kapatmaya yarayacak değişken.
                this.Dispose();
            }
        }
        //BAŞLA BUTONUNA TIKLANILDIĞINDA YAŞANACAK OLAYLAR Satır(121-127).
        private void BaslaButonu_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= (OyunEkranı.SayıKutularıkareSayisi * OyunEkranı.SayıKutularıkareSayisi); i++)
            {
                ((Button)this.groupBox1.Controls[i.ToString()]).Enabled = true;//Butonlara erişilebilir yapma.
            }
        }
        //FORMUN KAPATMA TUŞUNA BASILDIĞINDA YAŞANACAK OLAYLAR Satır(129-137)
        private void SayıKutularıOyunu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!direktKapanis) 
            {
                DialogResult cevap = new DialogResult();
                cevap = MessageBox.Show("İlerleme silinecek. Ayarlara dönmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes) { this.Dispose(); }
                else if (cevap == DialogResult.No) { e.Cancel = true; }
            }
        }
    }
}
