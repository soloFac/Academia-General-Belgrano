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

            CreateMap<Grupo, GrupoViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<EscuelaCurso, EscuelaCursoViewModel>().ReverseMap();
            CreateMap<EstablecimientoAcademico, EstablecimientoAcademicoViewModel>().ReverseMap();
        }

    }
}
