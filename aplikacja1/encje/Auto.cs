using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplikacja1.encje
{
    public class Auto
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Cena { get; set; }
        public string OpisUsterki { get; set; }
        public virtual Mechanik Mechanik { get; set; }
        public virtual int MechanikId { get; set; }
    }
}
