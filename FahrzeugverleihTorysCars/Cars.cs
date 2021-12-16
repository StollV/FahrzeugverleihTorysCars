using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugverleihTorysCars
{
    class Cars
    {
        // Attribute
        public int ID { get; set; }
        public string Marke { get; set; }
        public string Modell { get; set; }
        public string Baujahr { get; set; }
        public string Kraftstoffart { get; set; }
        public string Kennzeichen { get; set; }
        public DateTime VermietetAm { get; set; }

        public Cars(int id, string marke, string modell, string baujahr, string kraftstoffart, string kennzeichen)
        {
            ID = id;
            Marke = marke;
            Modell = modell;
            Baujahr = baujahr;
            Kraftstoffart = kraftstoffart;
            Kennzeichen = kennzeichen;
            VermietetAm = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{ID}, {Marke}, {Modell}, {Baujahr}, {Kraftstoffart}, {Kennzeichen}, {VermietetAm}";
        }
    }
}
