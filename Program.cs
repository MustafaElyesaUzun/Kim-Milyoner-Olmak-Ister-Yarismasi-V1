namespace kim_milyoner_olmak_ister_yarismasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kim Milyoner Olmak İster\n");
            Console.Write("İsim Giriniz: ");
            string isim = Console.ReadLine();
            Console.Write("Soyisim Giriniz: ");
            string soyisim = Console.ReadLine();

            Console.Write("\n1.Telefon Jokerinizi Giriniz: ");
            string telefonJoker1 = Console.ReadLine();
            Console.Write("2.Telefon Jokerinizi Giriniz: ");
            string telefonJoker2 = Console.ReadLine();
            Console.Write("3.Telefon Jokerinizi Giriniz: ");
            string telefonJoker3 = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Hoşgeldiniz " + isim + " " + soyisim);

            Console.Write("Kuralları Biliyor Musunuz? : ");
            char kuralCevap = char.Parse(Console.ReadLine().ToUpper());

            if (kuralCevap != 'E')
            {
                Console.WriteLine("Kurallar: Yarışmada toplam 12 soru yer almaktadır. " +
                    "2. soruda 2.000 TL, 7. soruda ise 30.000 TL'lik baraj soruları vardır. " +
                    "Yarışmayı kaybettiğiniz takdirde en son geçtiğiniz baraj sorusunun ödülü sizin olur. " +
                    "Çekildiğiniz takdirde en son doğru yanıtladığınız sorunun ödülünü alırsınız");
            }
            
            Console.Write("Hazır Mısınız? : ");
            char hazirCevap = char.Parse(Console.ReadLine().ToUpper());

            if (hazirCevap != 'E')
            {
                Console.WriteLine("Hazır olmananız bekleniyor.");
                Console.WriteLine("Hazır olduğunuzda Enter'a Basın");
                Console.ReadLine();
            }
            bool seyirciHak = true, yuzdeHak = true, telefonHak = true;
            int kasa = 0;

            int soruNo = 1, odul, baraj;
            int seyirciYuzdeA, seyirciYuzdeB, seyirciYuzdeC, seyirciYuzdeD;
            bool gizleA, gizleB, gizleC, gizleD;
            string soru, a, b, c, d;
            char cevap;

            #region Soru Bilgileri
            soruNo = 1;
            soru = "Türkiyenin Başkenti Neresidir?";
            a = "Ankara";
            b = "Bursa";
            c = "Van";
            d = "Denizli";
            cevap = 'A';
            odul = 1000;
            baraj = 0;

            
            seyirciYuzdeA = 80; seyirciYuzdeB = 10;
            seyirciYuzdeC = 5; seyirciYuzdeD = 5;

            
            gizleA = false; gizleB = false;
            gizleC = false; gizleD = false;
        #endregion

        #region Soru Kalıbı
        soruNoktasi:
            Console.Clear();
            Console.WriteLine(soruNo + "-)" + soru);
            Console.WriteLine("A) " + (!gizleA ? a : ""));
            Console.WriteLine("B) " + (!gizleB ? b : ""));
            Console.WriteLine("C) " + (!gizleC ? c : ""));
            Console.WriteLine("D) " + (!gizleD ? d : ""));

        yanitNoktasi:
            bool jokerHak = seyirciHak || yuzdeHak || telefonHak;

            Console.Write("Cevabınızı Giriniz veya");
            if (jokerHak) Console.Write(" Joker için J'ye,");
            Console.Write(" Çekilmek için R'ye Basınız: ");
            char secim = char.Parse(Console.ReadLine().ToUpper());

            if (secim == 'J')
            {
                if (!jokerHak)
                {
                    Console.WriteLine("Joker Hakkınız Bitmiştir..");
                    goto yanitNoktasi;
                }

                Console.WriteLine("1-) " + (seyirciHak ? "Seyirci" : ""));
                Console.WriteLine("2-) " + (yuzdeHak ? "%50" : ""));
                Console.WriteLine("3-) " + (telefonHak ? "Telefon" : ""));
                Console.Write("Seçiminizi Yapınız: ");
                int jokerCevap = int.Parse(Console.ReadLine());

                if (jokerCevap == 1 && seyirciHak)
                {
                    Console.WriteLine("A) %" + seyirciYuzdeA);
                    Console.WriteLine("B) %" + seyirciYuzdeB);
                    Console.WriteLine("C) %" + seyirciYuzdeC);
                    Console.WriteLine("D) %" + seyirciYuzdeD);
                    seyirciHak = false;
                }
                else if (jokerCevap == 2 && yuzdeHak)
                {
                    
                    gizleB = true;
                    gizleC = true;

                    yuzdeHak = false;
                    goto soruNoktasi;
                }
                else if (jokerCevap == 3 && telefonHak)
                {
                    Console.WriteLine("1-) " + telefonJoker1);
                    Console.WriteLine("2-) " + telefonJoker2);
                    Console.WriteLine("3-) " + telefonJoker3);
                    Console.Write("Kimi Aramak İstersiniz? : ");
                    int telefonCevap = int.Parse(Console.ReadLine());

                    if (soruNo <= 7 || telefonCevap == 3) Console.WriteLine("Cevap Kesinlikle " + cevap);
                    else if (telefonCevap == 1)
                        Console.WriteLine("Emin Değilim. Ancak A veya B olduğunu düşünüyorum");
                    else if (telefonCevap == 2)
                        Console.WriteLine("Bilemedim. Kusura bakma");
                    telefonHak = false;
                }
                else
                    Console.WriteLine("Bu Joker Daha Önce Kullanıldı..");

                goto yanitNoktasi;
            }
            else if (secim == 'R')
            {
                Console.WriteLine(kasa + " TL Kazanacaksınız.");
                Console.Write("Çekilmek İstediğinize Emin Misiniz? : ");
                char cekilCevap = char.Parse(Console.ReadLine());

                if (cekilCevap == 'E')
                {
                    Console.WriteLine("Tebrikler, " + kasa + " TL Kazandınız.");
                    Console.WriteLine("Oyun Bitti");
                    
                    Environment.Exit(0);
                }
                goto soruNoktasi;
            }
            else if (secim != cevap)
            {
                Console.WriteLine("Elendiniz, Kazandığınız Tutar: " + baraj + " TL");
                Console.WriteLine("Oyun Bitti");
                
                Environment.Exit(0);
            }

            kasa = odul;
            Console.WriteLine("Tebrikler, Kazandığınız Tutar: " + kasa + " TL");
            Console.WriteLine("\nSonraki Soruya Geçmek  İçin Enter'a Basın..");
            Console.ReadLine();
            #endregion
        }
    }
}