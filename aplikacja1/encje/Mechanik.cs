using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplikacja1.encje
{
    public class Mechanik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Specjalizacja { get; set; }
        public virtual Klient Klient { get; set; }
        public virtual List<Auto> Auta { get; set; }
    }
}
