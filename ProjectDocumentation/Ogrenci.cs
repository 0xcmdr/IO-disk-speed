using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDocumentation
{
    class Ogrenci
    {
        /*Öğrenciler içinAlanları(Fields) Tanımla*/
        char[] ad=new char[20];
        char[] soyad= new char[15];
        long ogrNo;
        float gano;
        int bolumSira;
        int sinifSira;
        int sinif;
        char cinsiyet;


        /*Constructor*/

        public Ogrenci(String ad, String soyad, long ogrNo,float gano,int sinif,char cinsiyet,int bolumSira=0,int sinifSira=0)
        {
            /* Öğrencileri dışardan alınan verilere göre oluştur*/
            this.ad = ad.ToCharArray();
            this.soyad = soyad.ToCharArray();
            this.ogrNo = ogrNo;
            this.gano = gano;
            this.sinif = sinif;
            this.cinsiyet = cinsiyet;
            this.bolumSira = bolumSira;
            this.sinifSira = sinifSira;
          
        }

        /*Alanların getter setterları*/

        public string Ad { get => new string(ad); set => ad = value.ToCharArray(); }
        public string Soyad { get => new string(soyad); set => soyad = value.ToCharArray(); }
        public long OgrNo { get => ogrNo; set => ogrNo = value; }
        public float  Gano { get => gano; set => gano = value; }
        public int BolumSira { get => bolumSira; set => bolumSira = value; }
        public int SinifSira { get => sinifSira; set => sinifSira = value; }
        public char Cinsiyet { get => cinsiyet; set => cinsiyet = value; }
        public int Sinif { get => sinif; set => sinif = value; }

       
    }
}
