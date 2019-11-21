using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConsoleApp3
{
    public class Olohuone : Mediapalvelin, Interface1
    {
        private string kuva = "Samsung 4k 65-tuumainen";
        private string aani = "Samsung LJ3 Soundbar";
        public Olohuone() : base("Microsoft Windows 10", "192.168.1.5")
        {

        }
        public string LeffaOlohuoneeseen()
        {
            return "Valitsemasi elokuva lähtee pyörimään olohuoneessa.\n"
                + "Speksit olohuoneessa:\nNäyttölaitteena: " + kuva + "\nÄänilaitteena: " + aani + ".\n";
        }
        public new string KayttojarjestelmaInfo()  // Metodin ylikirjoittamista
        {
            return "Olohuoneen mediapalvelimen käyttöjärjestelmä on " + kayttojarjestelma + ".";
        }
        public override string IPOsoiteInfo()  // Metodin ylikirjoittamista
        {
            return "Mediapalvelimen IP-osoite on " + iposoite + ".";
        }

        void Interface1.valikko()
        {
            throw new NotImplementedException();
        }

    }
}
