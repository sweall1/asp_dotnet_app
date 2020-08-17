using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplikacja1.encje
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Telefon { get; set; }
        public virtual Mechanik Mechanik { get; set; }
        public virtual int MechanikId { get; set; }
    }
}
