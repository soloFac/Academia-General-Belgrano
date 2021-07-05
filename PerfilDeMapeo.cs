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
            CreateMap<Familiar, FamiliarViewModel>().ReverseMap();
            CreateMap<EstablecimientoAcademico, EstablecimientoAcademicoViewModel>().ReverseMap();
            CreateMap<Escuela, EscuelaViewModel>().ReverseMap();

            CreateMap<PreinscripcionViewModel, Alumno>().ForMember(
                dest => dest.Nombre, origen => origen.MapFrom(src => src.Nombre)
            ).ForMember(
                dest => dest.Apellido, origen => origen.MapFrom(src => src.Apellido)
            ).ForMember(
                dest => dest.DNI, origen => origen.MapFrom(src => src.DNI)
            ).ForMember(
                dest => dest.Mail, origen => origen.MapFrom(src => src.Mail)
            ).ForMember(
                dest => dest.FechaNacimiento, origen => origen.MapFrom(src => src.FechaNacimiento)
            ).ForMember(
                dest => dest.Provincia, origen => origen.MapFrom(src => src.Provincia)
            ).ForMember(
                dest => dest.Departamento, origen => origen.MapFrom(src => src.Departamento)
            ).ForMember(
                dest => dest.Localidad, origen => origen.MapFrom(src => src.Localidad)
            ).ForMember(
                dest => dest.Domicilio, origen => origen.MapFrom(src => src.Domicilio)
            ).ForMember(
                dest => dest.Turno, origen => origen.MapFrom(src => src.Turno)
            ).ForMember(
                dest => dest.Instituto, origen => origen.MapFrom(src => src.Instituto)
            ).ForPath(
                dest => dest.EstablecimientoAlumno.ID, origen => origen.MapFrom(src => src.IDEstablecimiento)
            ).ForPath(
                dest => dest.CursoAlumno.ID, origen => origen.MapFrom(src => src.IDCurso)
            ).ForPath(
                dest => dest.EscuelaCursoAlumno.ID, origen => origen.MapFrom(src => src.IDEscuelaCurso)
            ).ForMember(
                dest => dest.ListaFamiliares, origen => origen.MapFrom(src => src.ListaFamiliares)
            ).ForMember(
                dest => dest.ListaTelefonos, origen => origen.MapFrom(src => src.ListaTelefonos)
            ).ForMember(
                dest => dest.ListaFechasInscripcion, origen => origen.MapFrom(src => src.ListaFechasInscripcion)
            );

            //CreateMap<PreinscripcionViewModel, Grupo>(){ }

            CreateMap<Grupo, GrupoViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<EscuelaCurso, EscuelaCursoViewModel>().ReverseMap();
            CreateMap<EstablecimientoAcademico, EstablecimientoAcademicoViewModel>().ReverseMap();
        }

    }
}
