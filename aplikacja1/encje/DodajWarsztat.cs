using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplikacja1.encje
{
    public class DodajWarsztat
    {
        private WarsztatContext warsztatContext;
        public DodajWarsztat(WarsztatContext warsztatContext)
        {
            this.warsztatContext = warsztatContext;
        }
        public void DodajDane()
        {
            if (warsztatContext.Database.CanConnect())
            {
                if (!warsztatContext.Mechanicy.Any())
                {
                    WstawRekordy();
                }
            }
        }
        private void WstawRekordy()
        {
            var mechanicy = new List<Mechanik>
{
new Mechanik {
Imie = "Tomek",
Specjalizacja = "Elektryk",

Klient = new Klient
{
Imie = "Kuba",
Telefon = "123123123",
},
Auta = new List<Auto>
{
new Auto {
Marka = "BMW",
Model = "E87",
Cena = 400,
OpisUsterki = "Auto się nie uruchamia"
}
}
},
new Mechanik
{
Imie = "Marcin",
Specjalizacja = "Mechanika",

Klient = new Klient
{
Imie = "Kamil",
Telefon = "32132123",
},
Auta = new List<Auto>
{
new Auto {
Marka = "Mercedes",
Model = "w203",
Cena = 600,
OpisUsterki = "Nierówna praca silnika"
},
new Auto {
Marka = "Audi",
Model = "a6",
Cena = 800,
OpisUsterki = "Automatyczna skrzynia nie działa"
}
}
}
};
            warsztatContext.AddRange(mechanicy);
            warsztatContext.SaveChanges();
        }
    }
}
