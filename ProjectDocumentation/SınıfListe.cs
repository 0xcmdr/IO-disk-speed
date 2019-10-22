using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDocumentation
{
    /* Öğrenci listeleri bu sınıfta oluşturulup düzenlenir.Okuma veya yazma işlemleri buradan çağırılarak yönlendirilir.*/
    class SınıfListe
    {
        /*Dosya İşlemleri için nesne üret.*/
        public DosyaIslemleri dosya = new DosyaIslemleri();
        Stopwatch watch = new Stopwatch();
        /*Dosyadaki veri sayıları bilinmediği için dinamik olması açısından liste kullanılmıştır*/
        public List<string> erkekAd;
        public List<string> kızAd;
        public List<string> soyadlar;
        public double kızsure, soyadsure, yazmaSure, erkekSure,ogrenciOkuSure,siraHesapSure;
        public double islemSure;

        public SınıfListe()
        {
            /*Önceden ayarlanmış isimleri, dosyadan oku ve listelere doldur*/
            erkekAd = new List<string>(dosya.dosyaToList(@"..\..\Sources\erkekAdlar.txt"));
            erkekSure = dosya.calismaSuresi; //erkek listesini okumak için geçen süre

            /*Kız listesini oku ve doldur*/
            kızAd = new List<string>(dosya.dosyaToList(@"..\..\Sources\kızAdlar.txt"));
            kızsure = dosya.calismaSuresi; // kız süresini hesapla

            /*Soyad dosyasını okuma süresini hesapla */
            soyadlar = new List<string>(dosya.dosyaToList(@"..\..\Sources\soyadlar.txt"));
            soyadsure = dosya.calismaSuresi;


        }

        /*10 bin kişilik sınıf listesini oluşturur*/
        public Ogrenci[] genelListeOlustur()
        {

            Random r = new Random(); // random sayı üretmek için nesne
            int cRan, adRan; // random sayıları tutacak değişken
            string ad, soyad; //ad ve soyad
            char cinsiyet; //cinsiyet belirle
            long ogrno = 1030520000; //öğrenciye atanacak numara
            int sinif = 4; // sınıf değeri
            float gano; // rastgele gano

            //10 bin kişilik dizi oluştur
            Ogrenci[] ogrenciler = new Ogrenci[10000];

            //Öğrencileri oluştur
            for (int i = 0; i < ogrenciler.Length; i++)
            {
                //erkek mi kız mı olacağını random belirle(1->erkek, 2 ->kız)
                cRan = r.Next(1, 3);

                /* crab = 1 ise Erkek listesinden isim seç*/
                if (cRan == 1)
                {
                    //liste içerisinde random bir index üret
                    adRan = r.Next(0, erkekAd.Count);
                    //bu indexteki elemanı isim olarak seç
                    ad = erkekAd.ElementAt(adRan);
                    //cinsiyeti erkek olarak belirle
                    cinsiyet = 'E';

                }

                //Değilse kız listesinden isim seç
                else
                {
                    //liste içerisinde random bir index üret
                    adRan = r.Next(0, kızAd.Count);
                    //bu indexteki elemanı isim olarak seç
                    ad = kızAd.ElementAt(adRan);
                    //cinsiyeti kız olarak belirle
                    cinsiyet = 'K';
                }

                //rastgele ganoyu ve soyadı belirle ve öğrenciyi oluştur
                soyad = soyadlar.ElementAt(r.Next(0, soyadlar.Count)); //rastgele soyad seç
                gano = (float)Math.Round(r.NextDouble() * (4 - 0) + 0, 3); //rastgele gano
                //öğrenciyi oluştur
                ogrenciler[i] = new Ogrenci(ad, soyad, (ogrno + i), gano, sinif, cinsiyet);

                //i değerine göre sınıf sayısını değiştir
                if (i == 2499 || i == 4999 || i == 7499)
                {
                    sinif--;
                }


            }

            //Oluşturulan öğrencileri dosyaya yaz ve dosyaya yazma süresini hesapla
            dosya.dosyayaYaz(ogrenciler, @"..\..\Outputs\TumOgrenciler.txt"); // dosyaları yaz
            yazmaSure = dosya.calismaSuresi; //süreyi değişkene ata

            return ogrenciler;
        }

        public List<Ogrenci> dosyadanOgrenciOlustur(string dosyaYolu)
        {
            List<Ogrenci> ogrenciler=dosya.ogrenciOku(dosyaYolu);
            ogrenciOkuSure = dosya.calismaSuresi;
            return ogrenciler;
        }
        

        public List<Ogrenci> bolumSinifSira()
        {
            watch.Restart();
            List<Ogrenci> ogrenciler = dosyadanOgrenciOlustur(@"..\..\Outputs\TumOgrenciler.txt");
            List<Ogrenci> bolumSira = ogrenciler.OrderByDescending(ogrenci => ogrenci.Gano).ToList<Ogrenci>();
            List<Ogrenci> sinif1Sira = ogrenciler.OrderByDescending(ogrenci => ogrenci.Gano).Where(o => o.Sinif == 1).ToList<Ogrenci>();
            List<Ogrenci> sinif2Sira = ogrenciler.OrderByDescending(ogrenci => ogrenci.Gano).Where(o => o.Sinif == 2).ToList<Ogrenci>();
            List<Ogrenci> sinif3Sira = ogrenciler.OrderByDescending(ogrenci => ogrenci.Gano).Where(o => o.Sinif == 3).ToList<Ogrenci>();
            List<Ogrenci> sinif4Sira = ogrenciler.OrderByDescending(ogrenci => ogrenci.Gano).Where(o => o.Sinif == 4).ToList<Ogrenci>();

            foreach(Ogrenci ogr in ogrenciler)
            {
                ogr.BolumSira= bolumSira.FindIndex(ogrenci => ogrenci.OgrNo == ogr.OgrNo)+1;

                if (ogr.Sinif == 1)
                {
                    ogr.SinifSira = sinif1Sira.FindIndex(ogrenci => ogrenci.OgrNo == ogr.OgrNo)+1;
                }
                else if (ogr.Sinif == 2)
                {
                    ogr.SinifSira = sinif2Sira.FindIndex(ogrenci => ogrenci.OgrNo == ogr.OgrNo)+1;

                }
                else if (ogr.Sinif == 3)
                {
                    ogr.SinifSira = sinif3Sira.FindIndex(ogrenci => ogrenci.OgrNo == ogr.OgrNo)+1;

                }
                else
                {
                    ogr.SinifSira = sinif4Sira.FindIndex(ogrenci => ogrenci.OgrNo == ogr.OgrNo)+1;

                }

            }
            watch.Stop();
            siraHesapSure = watch.Elapsed.TotalMilliseconds;
            return ogrenciler;
        }

        public double asama2Ciktisi(List<Ogrenci> ogr)
        {
            dosya.dosyayaYaz(ogr.ToArray(), @"..\..\Outputs\Asama2\BolumSinifSirali.txt");
            return dosya.calismaSuresi;
        }

        public List<Ogrenci> sinifaGoreSirala(int sinif)
        {
            watch.Restart();//süreyi başlat
            List<Ogrenci> ogrenciler = dosyadanOgrenciOlustur(@"..\..\Outputs\Asama2\BolumSinifSirali.txt");
            List<Ogrenci> sinifSirali= ogrenciler.OrderBy(o => o.SinifSira).Where(o => o.Sinif == sinif).ToList<Ogrenci>();
            watch.Stop();
            islemSure= watch.Elapsed.TotalMilliseconds; //işlemlerin süresini hesapla

            //Sırali Listeyi Dosyaya Yaz 
            dosya.dosyayaYaz(sinifSirali.ToArray(), @"..\..\Outputs\Asama3\Sınıf" + sinif + "Sıralı.txt");
            yazmaSure = dosya.calismaSuresi; //(dosyanın calisma süresini kullan)
            //Sıralı listeyi dosyadan Oku ve Dönder
            return dosyadanOgrenciOlustur(@"..\..\Outputs\Asama3\Sınıf" + sinif + "Sıralı.txt"); //ogrenciokusure kullan

        }

        public List<Ogrenci> bolumeGoreSirala()
        {
            watch.Restart();//süreyi başlat
            List<Ogrenci> ogrenciler = dosyadanOgrenciOlustur(@"..\..\Outputs\Asama2\BolumSinifSirali.txt");
            List<Ogrenci> bolumSirali = ogrenciler.OrderBy(o => o.BolumSira).ToList<Ogrenci>();
            watch.Stop();
            islemSure = watch.Elapsed.TotalMilliseconds; //işlemlerin süresini hesapla

            //Bölüme Göre Sıralı dosyayı diske yaz
            dosya.dosyayaYaz(bolumSirali.ToArray(), @"..\..\Outputs\Asama3\BolumSırasınaGore.txt");
            yazmaSure = dosya.calismaSuresi;
            //Sıralı listeyi diskten oku
            return dosyadanOgrenciOlustur(@"..\..\Outputs\Asama3\BolumSırasınaGore.txt");

        }
        
        public List<Ogrenci> cinsiyetListesi(char cinsiyet)
        {
            watch.Restart();//süreyi başlat
            List<Ogrenci> ogrenciler = dosyadanOgrenciOlustur(@"..\..\Outputs\Asama2\BolumSinifSirali.txt");
            List<Ogrenci> cinsiyetSirali = ogrenciler.OrderBy(o => o.BolumSira).Where(o => o.Cinsiyet==cinsiyet).ToList<Ogrenci>();
            watch.Stop();
            islemSure = watch.Elapsed.TotalMilliseconds; //işlemlerin süresini hesapla

            //Bölüme Göre Sıralı dosyayı diske yaz
            string dosyaisim;
            if (cinsiyet == 'E')
            {
                dosyaisim = "ErkekOgrenciListesi.txt";
            }
            else
            {
                dosyaisim = "KızOgrenciListesi.txt";

            }
            dosya.dosyayaYaz(cinsiyetSirali.ToArray(), @"..\..\Outputs\Asama3\"+dosyaisim);
            yazmaSure = dosya.calismaSuresi; //dosyaya yazma süresini hesapla
            //Sıralı listeyi diskten oku
            return dosyadanOgrenciOlustur(@"..\..\Outputs\Asama3\"+dosyaisim);

        }
        
        public List<Ogrenci> ogrenciNoSirala(string mode)
        {
            watch.Restart();//süreyi başlat
            List<Ogrenci> ogrenciler = dosyadanOgrenciOlustur(@"..\..\Outputs\Asama2\BolumSinifSirali.txt");
            List<Ogrenci> cinsiyetSirali;
            string dosyaisim;
            if (mode == "desc")
            {
                cinsiyetSirali = ogrenciler.OrderByDescending(o => o.OgrNo).ToList<Ogrenci>();
                dosyaisim = "OgrenciNoAzalan.txt";
            }
            else
            {
                cinsiyetSirali = ogrenciler.OrderBy(o => o.OgrNo).ToList<Ogrenci>();
                dosyaisim = "OgrenciNoArtan.txt";
            }
            watch.Stop();
            islemSure = watch.Elapsed.TotalMilliseconds; //işlem süresini hesapla
            dosya.dosyayaYaz(cinsiyetSirali.ToArray(), @"..\..\Outputs\Asama3\"+dosyaisim);
            yazmaSure = dosya.calismaSuresi; //dosyaya yazma süresini hesapla
            //Sıralı listeyi diskten oku
            return dosyadanOgrenciOlustur(@"..\..\Outputs\Asama3\" + dosyaisim);
        }

    }
}
