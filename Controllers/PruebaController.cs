using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Proyecto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IMapper mapper;    //readonly: a un atributo, ese atributo solo puede ser inicializado en el constructor

        private readonly ILogger<PruebaController> _logger;

        public PruebaController(ILogger<PruebaController> logger, IMapper mapper)
        {
            _logger = logger;
            this.mapper = mapper;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearPrueba(PruebaViewModel nPrueba)
        {
            if (ModelState.IsValid)
            {
                RepositorioAlumno RAlumno = new RepositorioAlumno();

                return Content("El modelo es valido");
            }
            return Content("El modelo no es valido");
        }
    }
}
