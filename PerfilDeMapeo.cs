using Proyecto.Entidades;
using Proyecto.ViewModels;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo()
        {
            CreateMap<Persona, PersonaViewModel>().ReverseMap();
            CreateMap<Alumno, AlumnoViewModel>().ReverseMap();

        }

    }
}
