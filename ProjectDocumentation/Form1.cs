using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDocumentation
{
    public partial class Form1 : Form
    {
        Ogrenci[] ogrenciler;
        SınıfListe liste1;
        public Form1()
        {
            InitializeComponent();
            liste1 = new SınıfListe();
            ogrenciler =liste1.genelListeOlustur();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tumOgrenciler.DataSource = ogrenciler;
            /*Dosya içeriklerinin sayısını ata*/
            as1OgrSay.Text = ogrenciler.Length.ToString();
            as1KizSayi.Text = liste1.kızAd.Count.ToString();
            as1ErkekSayı.Text = liste1.erkekAd.Count.ToString();
            as1SoyadSay.Text = liste1.soyadlar.Count.ToString();

            /*Okuma yazma sürelerini ata*/
            as1ErkekOkuma.Text = liste1.erkekSure.ToString() +" ms";
            as1KizOkuma.Text = liste1.kızsure.ToString() + " ms";
            as1YazmaSur.Text = liste1.yazmaSure.ToString() + " ms";
            as1SoyadSure.Text = liste1.soyadsure.ToString() + " ms";
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void as2Button_Click(object sender, EventArgs e)
        {
            //data gride veri ata
            List<Ogrenci> hesaplanmis = liste1.bolumSinifSira(); //ögrencileri oku ve hesapla
            as2DataGrid.DataSource =hesaplanmis; //hesaplanmis verileri bağla
            as2DosyaOku1.Text = liste1.ogrenciOkuSure +" ms";
            as2OgrSay.Text = hesaplanmis.Count.ToString(); //Toplam öğrenci sayısı
            as2HesaplaSur.Text = liste1.siraHesapSure.ToString() + " ms"; //bölüm gano hesaplama süresi
            //verileri dosyaya aktar ve süreyi dönder
            as2TekYazmaSur.Text = liste1.asama2Ciktisi(hesaplanmis).ToString()+" ms";
            

        }

        private void as3Sinif1Button_Click(object sender, EventArgs e)
        {
            /*sınıf sırasına göre sırala ve tabloya aktar*/
            List<Ogrenci> sinifsira=liste1.sinifaGoreSirala(1);
            as3SinifSiraData.DataSource = sinifsira;
            as3OgrenciSay.Text = sinifsira.Count.ToString();

            as3Sure();



        }

        private void as3Sure()
        {
            /*süreleri al*/
            as3SiralamaIslem.Text = liste1.islemSure.ToString() + " ms";
            as3OkumaSur.Text = liste1.ogrenciOkuSure.ToString() + " ms";
            as3YazmaSur.Text = liste1.yazmaSure.ToString() + " ms";
        }

        private void as3Sinif2Button_Click(object sender, EventArgs e)
        {
            /*sınıf sırasına göre sırala ve tabloya aktar*/
            List<Ogrenci> sinifsira = liste1.sinifaGoreSirala(2);
            as3SinifSiraData.DataSource = sinifsira;
            as3OgrenciSay.Text = sinifsira.Count.ToString();

            as3Sure();
        }

        private void as3Sinif3Button_Click(object sender, EventArgs e)
        {
            /*sınıf sırasına göre sırala ve tabloya aktar*/
            List<Ogrenci> sinifsira = liste1.sinifaGoreSirala(3);
            as3SinifSiraData.DataSource = sinifsira;
            as3OgrenciSay.Text = sinifsira.Count.ToString();

            as3Sure();
        }

        private void as3Sinif4Button_Click(object sender, EventArgs e)
        {
            /*sınıf sırasına göre sırala ve tabloya aktar*/
            List<Ogrenci> sinifsira = liste1.sinifaGoreSirala(4);
            as3SinifSiraData.DataSource = sinifsira;
            as3OgrenciSay.Text = sinifsira.Count.ToString();

            as3Sure();
        }

        private void as3bolumSiralaButton_Click(object sender, EventArgs e)
        {
            //bölüme göre sıralama işlemlerini yap ve verileri tabloya aktar
            List<Ogrenci> bolumSirali = liste1.bolumeGoreSirala();
            as3BolumSiraData.DataSource = bolumSirali;
            as3OgrenciSay.Text = bolumSirali.Count.ToString();
            as3Sure();
        }

        private void as3ErkekButton_Click(object sender, EventArgs e)
        {
            //Erkek Öğrencileri ayır, diske yaz ve diskten oku
            List<Ogrenci> erkekOgrenciler = liste1.cinsiyetListesi('E');
            as3CinsiyetData.DataSource = erkekOgrenciler;
            as3OgrenciSay.Text = erkekOgrenciler.Count.ToString();
            as3Sure();
        }

        private void as3KizButton_Click(object sender, EventArgs e)
        {
            //Kız Öğrencileri ayır, diske yaz ve diskten oku
            List<Ogrenci> kizOgrenciler = liste1.cinsiyetListesi('K');
            as3CinsiyetData.DataSource = kizOgrenciler;
            as3OgrenciSay.Text = kizOgrenciler.Count.ToString();
            as3Sure();
        }

        private void as3OgrNoArtan_Click(object sender, EventArgs e)
        {
            //Öğrenci Noya göre artan sıralama 
            List<Ogrenci> artanSiralama = liste1.ogrenciNoSirala("asc");//ascending sıralama
            as3OgrNoData.DataSource = artanSiralama;
            as3OgrenciSay.Text = artanSiralama.Count.ToString();
            as3Sure();
        }

        private void as3OgrNoAzalan_Click(object sender, EventArgs e)
        {
            //Öğrenci Noya göre artan sıralama 
            List<Ogrenci> azalanSiralama = liste1.ogrenciNoSirala("desc");//ascending sıralama
            as3OgrNoData.DataSource = azalanSiralama;
            as3OgrenciSay.Text = azalanSiralama.Count.ToString();
            as3Sure();
        }
    }
}
