using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugverleihTorysCars
{
    class Mitarbeiter
    {
        // Attribute
        public int ID { get; set; }
        public string Kürzel { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Geburtstag { get; set; }
        public string Anschrift { get; set; }
        public string Telefon { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }
        public string PersonalausweisNr { get; set; }
        public string KennzeichenPrivat { get; set; }
        public int ReservierungsID { get; set; }
        public DateTime AngelegtAm { get; set; }

        public Mitarbeiter(int id, string kürzel, string name, string vorname, string geburstag, string anschrift, string telefon, string mobil, string email, string personalausweisnr, string kennzeichenprivat, int reservierungsid)
        {
            ID = id;
            Kürzel = kürzel;
            Name = name;
            Vorname = vorname;
            Geburtstag = geburstag;
            Anschrift = anschrift;
            Telefon = telefon;
            Mobil = mobil;
            Email = email;
            PersonalausweisNr = personalausweisnr;
            KennzeichenPrivat = kennzeichenprivat;
            ReservierungsID = reservierungsid;
            AngelegtAm = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ID}, {Name}";
        }
    }
}
