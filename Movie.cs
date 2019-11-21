using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;





namespace ConsoleApp3
{
    [Serializable]
    public class Movie : Interface1
    {
        public List<string> top50leffat { get; set; }
        public List<string> suomitop50leffat { get; set; }
        public List<string> omatleffat { get; set; }
        public List<string> imdbtop250 { get; set; }

        public Movie()
        {
            string[] top50 = System.IO.File.ReadAllLines("Top50.txt");
            top50leffat = new List<string>(top50);
            string[] suomitop50 = System.IO.File.ReadAllLines("suomitop50.txt");
            suomitop50leffat = new List<string>(suomitop50);
            string[] omat = System.IO.File.ReadAllLines("omatleffat.txt");
            omatleffat = new List<string>(omat);
            string[] imdb250 = System.IO.File.ReadAllLines("imdbtop250.txt");
            imdbtop250 = new List<string>(imdb250);
        }
        public void valikko()
        {
            Console.WriteLine("Tämä on elokuvakirjasto-ohjelma. Tässä ohjelmassa voit pitää kirjaa omista elokuvistasi");
            Console.WriteLine("sekä nähdä IMDB:n (Internet Movie Database) Top 50 elokuvaa, sekä Top 50 listan ");
            Console.WriteLine("Suomalaisista elokuvista ja pyytää suosituksia elokuvista.");
            Console.WriteLine("Valitse seuraavista vaihtoehdoista:");
            Console.WriteLine("1. Näytä Top 50 elokuvat IMDB:ssä.");
            Console.WriteLine("2. Näytä Top 50 Suomalaiset elokuvat IMDB:ssä.");
            Console.WriteLine("3. Siirry omaan elokuvakirjastoon. ");
            Console.WriteLine("4. Lisää elokuvia omaan elokuvakirjastoon. ");
            Console.WriteLine("5. Pyydä elokuvasuosituksia. ");
            Console.WriteLine("6. Etsi elokuvakirjastostasi nimikkeitä. ");
            string ui = Console.ReadLine();
            if (ui == "1") { top50(); }
            else if (ui == "2") { suomitop50(); }
            else if (ui == "3") { omat(); }
            else if (ui == "4") { lisaa(); }
            else if (ui == "5") { randomi(); }
            else if (ui == "6") { etsi(); }
            else { valikko(); }
        }
        public void top50()
        {
            Console.WriteLine("Top 50 elokuvat IMDB:ssä paremmuusjärjestyksessä:");
            for (int i = 0; i < top50leffat.Count; i++)
            {
                Console.WriteLine("\t-" + top50leffat[i]);
            }
        }
        public void suomitop50()
        {
            Console.WriteLine("Top 50 suomalaista elokuvaa IMDB:ssä paremmuusjärjestyksessä:");
            for (int i = 0; i < suomitop50leffat.Count; i++)
            {
                Console.WriteLine("\t-" + suomitop50leffat[i]);
            }
        }
        public void omat()
        {
            omatleffat.Sort();
            for (int i = 0; i < omatleffat.Count; i++)
            {

                Console.WriteLine("\t-" + omatleffat[i]);
            }
            Console.WriteLine("Paina enteriä palataksesi päävalikkoon:");
            Console.ReadLine();
            { valikko(); }

        }
        private void lisaa()
        {
            Console.WriteLine("Kirjoita elokuvan nimi: ");
            string newTitle = Console.ReadLine();
            if (newTitle != "")
            {
                omatleffat.Add(newTitle);
                Console.WriteLine("Uusi elokuva lisätty kirjastoon!");
                System.IO.File.WriteAllLines("omatleffat.txt", omatleffat);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream fileStream = new FileStream("omatleffat.bin", FileMode.Create, FileAccess.Write, FileShare.None);

                try
                {
                    binaryFormatter.Serialize(fileStream, omatleffat);
                }
                catch
                {
                    Console.WriteLine("Virhe tallennuksessa!");
                }
                finally
                {
                    fileStream.Close();
                }
                Console.WriteLine("Elokuvakirjasto on tallennettu omatleffat.txt tiedostoon, sekä\n" +
                    "kirjasto on myös tallennettu binäärimuotoon, omatleffat.bin tiedostoksi. ");
                Console.WriteLine("Haluatko lisätä toisen elokuvan kirjastoon? K/E ");
                string vastaus = Console.ReadLine();
                string isolla = vastaus.ToUpper();
                if (isolla == "K") { lisaa(); }
                else { valikko(); }
            }
            else
            {
                Console.WriteLine("Ei voi lisätä tyhjää riviä. ");
            }
        }
        private void etsi()
        {
            Console.WriteLine("Kirjoita etsittävä nimike: ");
            string etsi = Console.ReadLine();
            if (omatleffat.Contains(etsi))
            {
                Console.WriteLine("Elokuva löytyy kirjastostasi.");
                Console.WriteLine("Paina entteriä palataksesi päävalikkoon.");
                Console.ReadLine();
                valikko();
            }

            else
            {
                Console.WriteLine("Etsittävää nimikettä ei löydy kirjastostasi.");
                Console.WriteLine("Paina entteriä palataksesi päävalikkoon.");
                Console.ReadLine();
            }
        }
    private void randomi()
        {
            Console.WriteLine("Mistä haluat suosituksia?");
            Console.WriteLine("1. Kaikkien aikojen Top 50 listalta.");
            Console.WriteLine("2. Suomalaiset Top 50 listalta.");
            Console.WriteLine("3. Omalta listalta.");
            Console.WriteLine("4. IMDB:n Top 250 listalta.");
            Console.WriteLine("5. Palaa takaisin päävalikkoon.");
            string vastaus2 = Console.ReadLine();
            Random r = new Random();
            if (vastaus2=="1")
            {
                int random = r.Next(0, top50leffat.Count - 1);
                Console.WriteLine("Suositus illan elokuvaksi IMDB:n Top 50 kaikkien aikojen parhaat elokuvat listalta on:");
                Console.WriteLine(top50leffat[random]);
            }
            else if (vastaus2 == "2")
            {
                int random = r.Next(0, suomitop50leffat.Count - 1);
                Console.WriteLine("Suositus illan elokuvaksi IMDB:n Top 50 kaikkien aikojen parhaista suomalaisista elokuvista on:");
                Console.WriteLine(suomitop50leffat[random]);
            }
            else if (vastaus2 == "3")
            {
                int random = r.Next(0, omatleffat.Count - 1);
                Console.WriteLine("Suositus illan elokuvaksi omistamistasi elokuvista on:");
                Console.WriteLine(omatleffat[random]);
            }
            else if (vastaus2 == "4")
            {
                int random = r.Next(0, imdbtop250.Count - 1);
                Console.WriteLine("Suositus illan elokuvaksi IMDB:n Top 250 kaikkien aikojen parhaat elokuvat listalta on:");
                Console.WriteLine("(Sija IMDB:ssä)                   (Arvosana)");
                Console.WriteLine(imdbtop250[random]);
            }
            else { valikko(); }

        }
        //public void LeffaOlohuone()
        //{
        //    var olohuone = new Olohuone();
        //    olohuone.LeffaOlohuoneeseen();
        //    Console.ReadLine();
        //}


        //public void LeffaTeatteri()
        //{
        //    var teatteri = new Teatteri();
        //    teatteri.LeffaTeatteriin();
        //    Console.ReadLine();
        //}
     }
}