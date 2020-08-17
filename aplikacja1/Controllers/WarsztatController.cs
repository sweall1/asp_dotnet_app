using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aplikacja1.encje;
using aplikacja1.modele;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aplikacja.Controllers
{
    [Route("api/mechanik")]
    public class WakacjeController : ControllerBase
    {
        private WarsztatContext warsztat;
        private IMapper mapper;
        public WakacjeController(WarsztatContext warsztat, IMapper mapper)
        {
            this.warsztat = warsztat;
            this.mapper = mapper;
        }
        public ActionResult<List<WarsztatDetailsDto>> Get()
        {
            var warsztaty = warsztat.Mechanicy.Include(m => m.Klient).ToList();
            var warsztatyDto = mapper.Map<List<WarsztatDetailsDto>>(warsztaty);
            return Ok(warsztatyDto);
        }

        [HttpGet("{name}")]
        public ActionResult<List<WarsztatDetailsDto>> Get(string name)
        {
            var mechanik = warsztat.Mechanicy
            .Include(m => m.Klient)
            .FirstOrDefault(mechanik => mechanik.Imie.Replace(" ", "-          ").ToLower() == name.ToLower());
            if (mechanik == null)
            {
                return NotFound();
            }
            else
            {
                var wyjazdDto = mapper.Map<WarsztatDetailsDto>(mechanik);
                return Ok(wyjazdDto);
            }
        }

    }



}