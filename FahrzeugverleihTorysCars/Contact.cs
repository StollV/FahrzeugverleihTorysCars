using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugverleihTorysCars
{
    class Contact
    {
        // Attribute
        public int ID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Geburtstag { get; set; }
        public string Anschrift { get; set; }
        public string Telefon { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }
        public string PersonalausweisNr { get; set; }
        public int FahrzeugID { get; set; }        
        public DateTime AngelegtAm { get; set; }

        public Contact (int id, string name, string vorname, string geburstag, string anschrift, string telefon, string mobil, string email, string personalausweisnr, int fahrzeugid)
        {
            ID = id;
            Name = name;
            Vorname = vorname;
            Geburtstag = geburstag;
            Anschrift = anschrift;
            Telefon = telefon;
            Mobil = mobil;
            Email = email;
            PersonalausweisNr = personalausweisnr;
            FahrzeugID = fahrzeugid;
            AngelegtAm = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Vorname}, {Anschrift}, {Email}, {FahrzeugID}, {AngelegtAm}";
        }
    }

}