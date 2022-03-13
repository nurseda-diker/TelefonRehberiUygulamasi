using System;

namespace TelefonRehberi
{
    class Program:KisiIslemleri
    {
        static KisiIslemleri islemler = new();
        static void Main(string[] args)
        {

            islemler.telefonRehberi.Add("Ayşe Yilmaz", 05431475689);
            islemler.telefonRehberi.Add("Ahmet Yıldırım",05463218947);
            islemler.telefonRehberi.Add("Ezgi Karayel",05346512871);
            islemler.telefonRehberi.Add("Kaan Demir",05312347896);
            islemler.telefonRehberi.Add("Melisa Çelik",05412368452);

            Menu();





        }

        public static void Menu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz : \n" +
               "******************************************\n" +
               "(1) Yeni Numara Kaydetmek\n" +
               "(2) Varolan Numarayı Silmek\n" +
               "(3) Varolan Numarayı Güncelleme\n" +
               "(4) Rehberi Listeleme\n" +
               "(5) Rehberde Arama Yapmak");

            Console.WriteLine("Yapmak istediğiniz işlemin numarasını yazınız:");
            int islemNumarasi = Convert.ToInt32(Console.ReadLine());

            switch (islemNumarasi)
            {
                case 1:
                    Console.WriteLine("Yeni numara ekleme");
                    islemler.KayitEkle();
                    break;
                case 2:
                    islemler.NumaraSil();
                    break;
                case 3:
                    islemler.NumaraGuncelle();
                    break;
                case 4:
                    islemler.RehberiListele();
                    break;
                case 5:
                    islemler.Arama();
                    break;
                default:
                    Console.WriteLine("Yanlış sayı girişi");
                    break;
            }
        }

    }
}
