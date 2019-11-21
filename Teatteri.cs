using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace ConsoleApp3
{
    public class Teatteri : Mediapalvelin, Interface1
    {
        private string kuva = "Benq 2000 videotykki";
        private string aani = "5.1 Tannoy sarja";

        public Teatteri():base("Linux","192.168.1.3")
        {

        }
        public string LeffaTeatteriin()
        {
            return "Leffa lähtee pyörimään teatterihuoneessa. Näyttölaitteena on "
                + kuva + " ja äänentoistona toimii " + aani + ".\n";
               
            
        }
        public new string KayttojarjestelmaInfo()  // Metodin ylikirjoittamista
        {
            return "Teatterihuoneen mediapalvelimen käyttöjärjestelmä on " + kayttojarjestelma +".";
        }
        public override string IPOsoiteInfo()  // Metodin ylikirjoittamista
        {
            return "Mediapalvelimen IP-osoite on " + iposoite + ".";
        }

        public void valikko()
        {
            throw new NotImplementedException();
        }

    }
}