using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi
{
    class KisiIslemleri
    {

       public Dictionary<string, long> telefonRehberi = new();

       public void KayitEkle()
        {
            Console.WriteLine("Kaydetmek istediğiniz kisinin isim ve soyismini giriniz:");
            string adSoyad = Console.ReadLine();
            Console.WriteLine("Telefon numarasını giriniz:");
            long telefonNo = long.Parse(Console.ReadLine());

            if (telefonRehberi.ContainsKey(adSoyad))
            {
                Console.WriteLine("Bu kisi rehberde kayitli\n.Menuye donmek icin bir tusa basin.");
            }
            else
            {
                telefonRehberi.Add(adSoyad, telefonNo);
                Console.WriteLine("Kayıt işlemi başarılı.\nMenuye donmek için bir tuşa basın.");
            }
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }


        public void NumaraSil()
        {
            Console.WriteLine(" Lütfen numarasını silmek istediğiniz kişinin adını ve soyadını giriniz:");
            string input = Console.ReadLine();
            if (telefonRehberi.ContainsKey(input))
            {
                Console.WriteLine("{0} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)",input);
                string cevap = Console.ReadLine();
                if (cevap == "y")
                {
                    telefonRehberi.Remove(input);
                    Console.WriteLine("Silme işlemi başarılı.\nMenuye dönmek için bir tuşa basın.");
                }
                else if (cevap == "n")
                {
                    Console.WriteLine("Silme işlemi iptal edildi.\nMenuye donmek için bir tuşa basın.");
                    MenuyeDon();
                }
                MenuyeDon();

            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n" +
                            "* Silmeyi sonlandırmak için : (1)\n" +
                            "* Yeniden denemek için      : (2)");
                int cevap = int.Parse(Console.ReadLine());
                switch (cevap)
                {
                    case 1:
                        Console.Clear();
                        Program.Menu();
                        break;
                    case 2:
                        NumaraSil();
                        break;
                    default:
                        Console.WriteLine("Yanlış sayı girişi.");
                        MenuyeDon();
                        break;
                }
               
            }
        }

        public void NumaraGuncelle()
        {
            Console.WriteLine("Numarasını güncellemek istediğiniz kişinin adını ve soyadını giriniz:");
            string input = Console.ReadLine();
            if (telefonRehberi.ContainsKey(input))
            {
                Console.WriteLine("Yeni numarayı giriniz:");
                long newNumber = long.Parse(Console.ReadLine());
                long degistir = telefonRehberi[input];
                telefonRehberi[input] = newNumber;
                Console.WriteLine("{0} numarası {1} ile değiştirildi.\nMenuye donmek için bir tuşa basın.",degistir,newNumber);
                MenuyeDon();

            }
            else
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.\n" +
                        "* Güncellemeyi sonlandırmak için    : (1)\n" +
                        "* Yeniden denemek için              : (2)");
                int cevap = int.Parse(Console.ReadLine());
                switch (cevap)
                {
                    case 1:
                        Console.Clear();
                        Program.Menu();
                        break;
                    case 2:
                        NumaraGuncelle();
                        break;
                    default:
                        Console.WriteLine("Yanlış sayı girişi");
                        MenuyeDon();
                        break;
                }
            }
        }

        public void Arama()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.\n" +
                "**********************************************\n" +
                "İsim veya soyisime göre arama yapmak için: (1)\n" +
                "Telefon numarasına göre arama yapmak için: (2)");

            int cevap = int.Parse(Console.ReadLine());
            switch (cevap)
            {
                case 1:
                    Console.WriteLine("Aramak istediğiniz kişinin isim veya soyismini giriniz:");
                    IsmeGöreArama(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Aramak istediğiniz kişinin numarasını giriniz:");
                    NumarayaGöreArama(long.Parse(Console.ReadLine()));
                    break;
                default:
                    Console.WriteLine("Yanlış sayı girişi");
                    Console.ReadKey();
                    Console.Clear();
                    Program.Menu();
                    break;
            }
        }

        public void IsmeGöreArama(string input)
        {
            if (telefonRehberi.ContainsKey(input))
            {
                Console.WriteLine("*****Arama Sonuçları*****");
                Console.WriteLine("İsim-soyisim: {0}",input);
                Console.WriteLine("Telefon numarası: {0}",telefonRehberi[input]);
                Console.WriteLine("-------");
                Console.WriteLine("Menuye donmek için bir tuşa basın.");
                MenuyeDon();
            }
            else
            {
                Console.WriteLine("Girdiğiniz bilgilerde biri rehberde bulunamadı.\nMenuye dönmek için bir tuşa basın.");
                MenuyeDon();
            }
        }

        public void NumarayaGöreArama(long input)
        {
            if (telefonRehberi.ContainsValue(input))
            {
                Console.WriteLine("*****Arama Sonuçlarınız*****");
                string key = "";
                foreach(var user in telefonRehberi)
                {
                    if (user.Value == input)
                    {
                        key = user.Key;
                    }
                }
                Console.WriteLine("İsim-soyisim: {0}", key);
                Console.WriteLine("Telefon numarası: {0}",input);
                Console.WriteLine("Menuye donmek için bir tuşa basın.");
                MenuyeDon();
            }
            else
            {
                Console.WriteLine("Girdiğiniz bilgilerde biri rehberde bulunamadı.\nMenuye dönmek için bir tuşa basın.");
                MenuyeDon();
            }

        }



        public void RehberiListele()
        {
            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("*********************************");
            foreach(var user in telefonRehberi)
            {
                Console.WriteLine("İsim-Soyisim: {0}",user.Key);
                Console.WriteLine("Telefon numarası: {0}",user.Value);
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Menuye donmek için bir tuşa basın.");
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }


        private void MenuyeDon()
        {
            Console.ReadKey();
            Console.Clear();
            Program.Menu();
        }



    }
}
