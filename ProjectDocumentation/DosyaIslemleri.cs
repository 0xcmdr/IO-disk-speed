using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDocumentation
{
    /* Dosya okuma, yazma işlemleri burada fonksiyonlar içerisinde, bir nesne üzerinden daha iyi kullanbilir format haline getirilmiştir.*/
    class DosyaIslemleri
    {
        StreamReader sr; //Dosya okuma nesnesi
        StreamWriter swrite; // Dosya Yazma Nesnesi
        //geçen süreleri hesaplamak içni kullanılacak
        Stopwatch watch = new Stopwatch();
        //fonksiyonun çalışma süresini tutacak
        public double calismaSuresi; 

        /*İlk isim ve soy isim Dosyalarını oku ve string listesi olarak dönder*/
        public List<string> dosyaToList(string dosyaYolu)
        {
            watch.Restart(); // süreyi başlat

            //Verileri tutacak listeyi oluştur
            List<string> gecici = new List<string>();
            //StreamReader nesnesi ile dosyayı aç
            try
            {
                sr = new StreamReader(dosyaYolu);
            //Dosyayı satır satır oku
            while(!sr.EndOfStream){
                    // her bir satırı al, bir eleman olarak ekle
                    gecici.Add(sr.ReadLine());
                }
           
            }catch(IOException ex)
            {
                //hata mesajını ekle ve dönder
                gecici.Add(ex.Message.ToString());
            }
            finally
            {
                sr.Close();
            }

            watch.Stop();//süreyi durdur
            calismaSuresi = watch.Elapsed.TotalMilliseconds;
            return  gecici;

        } 


        /*Gönderilen öğrenci dizisini, metin dosyasına yazar.*/
        public bool dosyayaYaz(Ogrenci[] ogrenciler,string dosyaYolu)
        {
            watch.Restart(); // süreyi başlat

            string ayır = "-"; //Field'ları ayıracak ayraç
            try
            {
                //Gelen öğrencileri dosyaya yaz
                 swrite= new StreamWriter(dosyaYolu); 
                foreach (Ogrenci o in ogrenciler)
                {
                    //bilgileri tek satırda birleştir.
                    
                    //ogrenci bilgilerini satır satır yaz
                    swrite.WriteLine(o.Ad + ayır + o.Soyad + ayır + o.OgrNo + ayır + o.Gano + ayır + o.BolumSira + ayır + o.SinifSira + ayır + o.Sinif + ayır + o.Cinsiyet); 
                }
                

                watch.Stop(); //süreyi durdur
                calismaSuresi = watch.Elapsed.TotalMilliseconds;//süreyi değişkene ata
            }catch(IOException )
            {
                
                return false; //başarısız ise false dönder
            }
            finally
            {
                swrite.Close(); // Dosyayı kapat
            }

            return true; // işlem başarılı ise true dönder


        }
        
        /*Oluşturulmuş öğrenci listesini oku ve listede tut*/
        public List<Ogrenci> ogrenciOku(string dosyaYolu)
        {
            watch.Restart(); // süreyi başlat
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            try
            {
                //dosyayı okumak için aç
                sr = new StreamReader(dosyaYolu);
                string[] satir;

                while (!sr.EndOfStream) //Dosya sonuna kadar oku
                {
                    satir = sr.ReadLine().Split('-');
                    ogrenciler.Add(new Ogrenci(satir[0], satir[1], long.Parse(satir[2]), float.Parse(satir[3]), int.Parse(satir[6]), char.Parse(satir[7]), int.Parse(satir[4]), int.Parse(satir[5])));
                    
                }


            }
            catch (IOException)
            {
                //hata göster
            }
            finally
            {
                sr.Close();
                watch.Stop();
                calismaSuresi = watch.Elapsed.TotalMilliseconds;
            }
            return ogrenciler;
        }

        
    }
}
