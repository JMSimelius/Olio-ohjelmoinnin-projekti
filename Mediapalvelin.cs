using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp3
{ 
    public class Mediapalvelin
    {
        protected string kayttojarjestelma;
        protected string iposoite;
        
        public Mediapalvelin (string kayttojarjestelma, string iposoite)
        {
            Kayttojarjestelma = kayttojarjestelma;
            IPOsoite = iposoite;
        }
        
        public string Kayttojarjestelma
        {
            get { return kayttojarjestelma; }
            set { kayttojarjestelma = value; }
        }
        public string IPOsoite
        {
            get { return iposoite; }
            set { iposoite = value; }
        }
        public string KayttojarjestelmaInfo()
        {
            return "Mediatoistimen käyttöjärjestelmä on " + kayttojarjestelma +".";
                

        }
        public virtual string IPOsoiteInfo()
        {
            return "Mediapalvelimen IP-osoite on " +iposoite + ".";
        }
    } 
}
