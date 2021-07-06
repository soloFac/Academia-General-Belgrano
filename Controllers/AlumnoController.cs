using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Proyecto.Entidades;
using Proyecto.ViewModels;

namespace Proyecto.Controllers
{
    public class AlumnoController : Controller
    {
        private readonly IMapper mapper;    //readonly: a un atributo, ese atributo solo puede ser inicializado en el constructor

        private readonly ILogger<AlumnoController> _logger;

        public AlumnoController(ILogger<AlumnoController> logger, IMapper mapper)
        {
            _logger = logger;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            RepositorioAlumno RAlumno = new RepositorioAlumno();

            List<Alumno> ListaAlumnos = RAlumno.GetAll();
            List<AlumnoViewModel> ListaAlumnosVM = mapper.Map<List<AlumnoViewModel>>(ListaAlumnos);

            return View(ListaAlumnosVM);
        }

        public IActionResult Preinscripcion()
        {
            RepositorioAlumno RAlumno = new RepositorioAlumno();

            List<Alumno> ListaAlumnos = RAlumno.GetAll();

            PreinscripcionViewModel PreinscripcionVM = new PreinscripcionViewModel();
            PreinscripcionVM.ListaGrupos = mapper.Map<List<GrupoViewModel>>(RepositorioHelper.GetAllGrupos());
            PreinscripcionVM.ListaCursos = mapper.Map<List<CursoViewModel>>(RepositorioHelper.GetAllCursos());
            PreinscripcionVM.ListaEscuelasCursos = mapper.Map<List<EscuelaCursoViewModel>>(RepositorioHelper.GetAllEscuelasCursos());
            PreinscripcionVM.ListaEstablecimientos = mapper.Map<List<EstablecimientoAcademicoViewModel>>(RepositorioHelper.GetAllEstablecimientosAcademicos());

            return View(PreinscripcionVM);
        }

        public IActionResult CrearAlumno(PreinscripcionViewModel nPreinscripcionVM)
        {
            if (ModelState.IsValid)
            {
                RepositorioAlumno RAlumno = new RepositorioAlumno();

                List<Alumno> ListaAlumnos = RAlumno.GetAll();

                Alumno nAlumno = mapper.Map<Alumno>(nPreinscripcionVM);
                RAlumno.AltaAlumno(nAlumno);

                return Content(ListaAlumnos.ToString());
            }

            return Content("El modelo no es valido");
        }

        //public IActionResult AltaAlumno()
        //{
        //    return View(new AlumnoViewModel());
        //}


    }
}

