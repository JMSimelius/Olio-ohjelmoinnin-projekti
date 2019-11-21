using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/* Tämä on ohjelma mikä lataa tiedostoista seuraavat listat:
-IMDB:n top 50 listan
-IMDB:n top 50 suomalaiset elokuvat 
-IMDB:n top 250 listan
-Oman elokuvalistan.
Ohjelmassa voi ylläpitää omaa elokuvalistaa, eli siihen voi lisätä ja hakea nimikkeitä.
Ohjelma tallentaa samaan tiedostoon omaa listaa, eli listaa pystyy kasvattamaan. Ohjelma tallentaa
oman kirjaston txt-tiedostoksi, sekä myös binäärimuodossa. 
Samalla ohjelmalta voi pyytää suosituksia eri listoilta.

Suositusten jälkeen ohjelma kysyy löytyikö sopiva elokuva, jonka jälkeen kysyy lähetetäänkö elokuva 
olohuoneeseen vai teatterihuoneeseen. Molemmat perivät mediapalvelin-luokan. 
Ohjelma toimii kuten pitääkin, mutta osaamismatriisin mukaan yritin vielä lisätä ominaisuuksia,
esim. binääritallennuksen ja sarjallistamisen. Kaikkea kohtia osaamismatriisista en saanut.
 */
namespace ConsoleApp3
{
    class Program : Interface1
    {

        static void Main(string[] args)
        {


            Interface1 movie = new Movie();
            int x = 0;
            while (x < 1)
            {
                movie.valikko(); Console.Write("Löysitkö illan elokuvan? K/E ");
                string vastaus = Console.ReadLine();
                string isolla = vastaus.ToUpper();
                if (isolla == "K") { x = 1; }
            }
            // Luodaan Valinta-olio
            Console.WriteLine("Minkä elokuvan haluat katsoa?");
            var valinta = Console.ReadLine();
            var chosenmovie = new Chosenmovie();
            chosenmovie.Chosen = valinta;
            // Console.WriteLine(valinta);

            Mediapalvelin mediapalvelin = new Mediapalvelin("Android", "192.168.1.2");
            Console.Clear();
            Console.WriteLine("{0}", mediapalvelin.KayttojarjestelmaInfo());
            Console.WriteLine("{0}", mediapalvelin.IPOsoiteInfo());
            Console.WriteLine("Haluatko katsoa elokuvan olohuoneessa vai teatterihuoneessa?");
            Console.WriteLine("1. Olohuoneessa.");
            Console.WriteLine("2. Teatterihuoneessa.");
            string vastaus3 = Console.ReadLine();
            if (vastaus3 == "1")
            {
                // Luodaan Olohuone-olio
                var olohuone = new Olohuone();
                Console.Clear();
                Console.WriteLine("Valitsit elokuvan {0}.\n{1}", valinta, olohuone.LeffaOlohuoneeseen());
                Console.WriteLine("{0}", olohuone.KayttojarjestelmaInfo());
                Console.WriteLine("{0}", olohuone.IPOsoiteInfo());
            }
            else if (vastaus3 == "2")
            {
                // Luodaan teatteri-olio
                var teatteri = new Teatteri();
                Console.Clear();
                Console.WriteLine("Valitsit elokuvan {0}.\n{1}", valinta, teatteri.LeffaTeatteriin());
                Console.WriteLine("{0}", teatteri.KayttojarjestelmaInfo());
                Console.WriteLine("{0}", teatteri.IPOsoiteInfo());
            }
            Console.ReadLine();
        }

        public void valikko()
        {
            throw new NotImplementedException();
        }
    }
}