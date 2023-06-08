using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SayıSıralama_YapbozOyunları
{
    public partial class YapbozOyunu : Form
    {
        public YapbozOyunu()
        {
            InitializeComponent();
        }
        int[] BenzersizSayilar = new int[OyunEkranı.YapbozkareSayisi* OyunEkranı.YapbozkareSayisi];//Fotolar klasöründeki resimlerden rastgele seçmek için gereken random sayıların koyulacağı dizi.
        ImageList fotoListesi = new ImageList();//Fotolar klaasöründeki fotoğrafların sıralı bi şekilde koyulacağı image listesi.
        Random rnd = new Random();//Randaom sayı değişkeni.
        //FORM YÜKLENDİĞİNDE YAŞANACAK OLAYLAR Satır(24-61).
        private void YapbozOyunu_Load(object sender, EventArgs e)
        {
            fotoListesi.ColorDepth = ColorDepth.Depth32Bit;
            //Seçilen zorluğa bağlı olarak listeye eklenecek imagelerin boyutları ve hangi klasörden ekleneceği belirleme satır(29-35).
            if (OyunEkranı.YapbozkareSayisi == 3) { fotoListesi.ImageSize = new Size(133, 133); }
            if (OyunEkranı.YapbozkareSayisi == 4) { fotoListesi.ImageSize = new Size(100, 100);}
            for (int i = 0; i < OyunEkranı.YapbozkareSayisi* OyunEkranı.YapbozkareSayisi; i++)
            {
                if (OyunEkranı.YapbozkareSayisi==4){fotoListesi.Images.Add(Image.FromFile("C:\\Users\\aliag\\source\\repos\\SayıSıralama_YapbozOyunları\\fotolar4x4\\" + i + ".jpg"));}
                if (OyunEkranı.YapbozkareSayisi==3){fotoListesi.Images.Add(Image.FromFile("C:\\Users\\aliag\\source\\repos\\SayıSıralama_YapbozOyunları\\fotolar3x3\\" + i + ".jpg"));}     
            }
            //Seçilen zorluğa göre buton oluşturma boyutunu alma ve yerleştirme Satır(37-61).
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;//Butonların konum değişkenleri.
            for (int j = 1; j <= OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi; j++)
            {
                Button btn = new Button();
                btn.Name= j.ToString();
                btn.Tag = j;
                btn.Click += btn_click;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.White;
                btn.FlatAppearance.BorderSize = 1;
                if (OyunEkranı.YapbozkareSayisi == 3) { btn.Size = new Size(133, 133); btn.Location = new Point(x1, y1); }
                if (OyunEkranı.YapbozkareSayisi == 4) { btn.Size = new Size(100, 100); btn.Location = new Point(x2, y2); }
                btn.BackgroundImage = fotoListesi.Images[j-1];
                btn.Enabled = false;
                x1 += 133;
                x2 += 100;
                if (j% OyunEkranı.YapbozkareSayisi == 0)
                {
                    y1 += 133;
                    x1 = 0;
                    y2 += 100;
                    x2 = 0;
                }
                groupBox1.Controls.Add(btn);
            }
        }
        //BUTONLARA TIKLANILARAK ÜZERLERİNDEKİ RESİMLERİ DEĞİŞTİRME Satır(64-92)
        Image tikResim1, tikResim2, resimDegisimi;
        Button tikla1, tikla2;
        int tikSayisi = 0;
        int tag1, tag2, araSayi;
        private void btn_click(object sender, EventArgs e)
        {
            Button tiklananbtn =(Button)sender;
            tikSayisi++;//Tıklama sayısı.
            if (tikSayisi % 2==1) { tikResim1 = tiklananbtn.Image; tikla1 = tiklananbtn; tag1 = (int)tikla1.Tag; }//İlk tıklanılan butonu belirtme.
            else
            {
                tikResim2 = tiklananbtn.Image;
                tikla2 = tiklananbtn;
                tag2= (int)tikla2.Tag;
                resimDegisimi = tikResim1;
                araSayi = tag1;
                tikResim1 = tikResim2;
                tag1 = tag2;
                tikResim2 = resimDegisimi;
                tag2 = araSayi;
                tikla1.Image = tikResim1;
                tikla2.Image = tikResim2;
                tikla1.Tag = tag1;
                tikla2.Tag = tag2;

            }
            label1.Text = "Hareket Sayısı: " + tikSayisi /2;//Her hamleni label1 e yazdırma.
            oyunBitisi();//oyunBitisi metodunu çağırma.
        }
        //BAŞLA-KARIŞTIR BUTONUNA TIKLANILDIĞINDA YAŞANACAK OLAYLAR Satır(94-120).
        private void BaslaButonu_Click(object sender, EventArgs e)
        {
            tikSayisi = 0;//Tıklama sayısını sıfırlama.
            label1.Text = "Hareket Sayısı: 0";
            //Benzersiz sayılar dizisini sıralı sayılarla doldurma Satır(99-102).
            for (int k = 0; k < OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi; k++)
            {
                BenzersizSayilar[k] = OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi;
            }
            //BenzersizSAyılar dizisini random sayılarla değiştirme Satır(104-112).
            int randomSayi;
            for (int i = 0; i < OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi; i++)
            {
                do
                {
                    randomSayi = rnd.Next(0, OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi);
                } while (Array.IndexOf(BenzersizSayilar, randomSayi) > -1);
                BenzersizSayilar[i] = randomSayi;
            }
            //Fotolistesi list'indeli fotoları benzersizsayılar dizisindeki random sayılar ile butonlara atama ve butonların taglariini de aynı sayılarla random karıştırma Satır(114-119).
            for (int j = 1; j <= OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi; j++)
            {
                ((Button)this.groupBox1.Controls[j.ToString()]).Enabled = true;
                ((Button)this.groupBox1.Controls[j.ToString()]).Image = fotoListesi.Images[BenzersizSayilar[j - 1]];
                ((Button)this.groupBox1.Controls[j.ToString()]).Tag= BenzersizSayilar[j - 1]+1;
            }
        }
        //FORMU KAPATMA TUŞUNA BASILDIĞINDA YAŞANACAKLAR Satır(122-131).
        private void YapbozOyunu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!direktKapanis)
            {
                DialogResult cevap = new DialogResult();
                cevap = MessageBox.Show("İlerleme silinecek. Ayarlara dönmek istediğine emin misin?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes) { this.Dispose(); }
                else if (cevap == DialogResult.No) { e.Cancel = true; }
            }
        }
        //OYUNUN BİTİP BİTMEDİĞİNİ KONTROL EDEN FONKSİYON Satır(133-156).
        int bitisSayaci = 0;
        Boolean direktKapanis = false;//Oyun bittiğinde formu direkt kapatmaya yarayacak değişken.
        private void oyunBitisi()
        {
            var nesneler = groupBox1.Controls.OfType<Button>();//GroupBox1'in içindeki tüm itemleri nesneler değişkenine atma.
            //Bütün butonların isimlerinin taglariyle aynı olup olmadığını kontrol etme Satır(139-145).
            foreach (var nesne in nesneler)
            {
                if (nesne.Name == nesne.Tag.ToString())
                {
                    bitisSayaci++;
                }
            }
            //Bütün resimler doğru yerdeyse yaşanacak olaylar Satır(147-154).
            if (bitisSayaci == OyunEkranı.YapbozkareSayisi * OyunEkranı.YapbozkareSayisi) 
            {
                if (tikSayisi / 2 <= 20) { MessageBox.Show(tikSayisi / 2 + " Hamlede kazandındınız.", "ÜST SEVİYE BAŞARI!!!"); }
                if (tikSayisi / 2 >= 20 && tikSayisi / 2 <= 30) { MessageBox.Show(tikSayisi / 2 + " Hamlede kazandındınız.", "ORTA SEVİYE BAŞARI!!!"); }
                if (tikSayisi / 2 >= 30) { MessageBox.Show(tikSayisi / 2 + " Hamlede kazandındınız.", "DÜŞÜK SEVİYE BAŞARI!!!"); }
                direktKapanis = true;
                this.Dispose();
            }
            else{bitisSayaci = 0;}//Eğer tüm tagler aynı değilse sayaç sıfırlanır ki tekrar baştan sayabilsin.
        }  
    }
}