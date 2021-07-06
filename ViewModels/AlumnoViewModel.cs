using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.Entidades;

namespace Proyecto.ViewModels
{
    public class AlumnoViewModel : PersonaViewModel
    {
        public string Mail { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Domicilio { get; set; }

        public Turnos Turno { get; set; }
        public EstablecimientoAcademicoViewModel Establecimiento { get; set; }
        //public Grupos Grupo;
        public GrupoViewModel Grupo { get; set; }
        public CursoViewModel Curso { get; set; }
        public EscuelaCursoViewModel EscuelaCurso { get; set; }
        public bool Estado { get; set; }
        public EscuelaViewModel Instituto { get; set; }
        public List<FamiliarViewModel> ListaFamiliares { get; set; }
        public List<string> ListaTelefonos { get; set; }
        public List<DateTime> ListaFechasInscripcion { get; set; }
        public List<DateTime> ListaFechasPago { get; set; }

        public AlumnoViewModel() : base()
        {
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = new EscuelaViewModel();

            this.Curso = new CursoViewModel();
            this.Grupo = new GrupoViewModel();
            this.EscuelaCurso = new EscuelaCursoViewModel();
            this.Establecimiento = new EstablecimientoAcademicoViewModel();

            this.ListaFamiliares = new List<FamiliarViewModel>();
            this.ListaTelefonos = new List<string>(3);
            this.ListaFechasInscripcion = new List<DateTime>();
            this.ListaFechasPago = new List<DateTime>();
        }

        public AlumnoViewModel(int ID, string Nombre, string Apellido, string Mail, string DNI,
                   DateTime FechaNacimiento, string Provincia, string Departamento, string Localidad, string Domicilio,
                   Turnos Turno, EstablecimientoAcademicoViewModel Establecimiento, GrupoViewModel Grupo, CursoViewModel Curso, 
                   EscuelaCursoViewModel EscuelaCurso, EscuelaViewModel Instituto) :
            base(ID, Nombre, Apellido) //, List<DateTime> ListaFechasInscripcion, List<DateTime> ListaFechasPago)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Apellido = Apellido;

            this.Mail = Mail;
            this.DNI = DNI;
            this.FechaNacimiento = FechaNacimiento;
            this.Provincia = Provincia;
            this.Departamento = Departamento;
            this.Localidad = Localidad;
            this.Domicilio = Domicilio;
            this.Turno = Turno;
            this.Establecimiento = Establecimiento;
            this.Grupo = Grupo;
            this.Curso = Curso;
            this.EscuelaCurso = EscuelaCurso;
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = Instituto;


            this.ListaFamiliares = new List<FamiliarViewModel>(3);
            this.ListaTelefonos = new List<string>(3);
            this.ListaFechasInscripcion = new List<DateTime>();
            this.ListaFechasPago = new List<DateTime>();
        }

    }
}
