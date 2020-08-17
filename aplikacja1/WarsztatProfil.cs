using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aplikacja1.encje;
using aplikacja1.modele;
using AutoMapper;

namespace aplikacja1
{
    public class WarsztatProfil : Profile
    {
        public WarsztatProfil()
        {
            CreateMap<Mechanik, WarsztatDetailsDto>()
            .ForMember(m => m.Telefon, map =>
            map.MapFrom(mechanik => mechanik.Klient.Imie))
            .ForMember(m => m.Telefon, map => map.MapFrom(mechanik
            => mechanik.Klient.Telefon));

        }
    }
}
