using Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.ViewModels
{
    public class PreinscripcionViewModel : PersonaViewModel
    {
        public string Mail { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Provincia { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Domicilio { get; set; }

        public Turnos Turno { get; set; }
        public List<EstablecimientoAcademicoViewModel> ListaEstablecimientos { get; set; }
        //public Grupos Grupo;
        public List<GrupoViewModel> ListaGrupos { get; set; }
        public List<CursoViewModel> ListaCursos { get; set; }
        public bool Estado { get; set; }
        public EscuelaViewModel Instituto { get; set; }
        public List<FamiliarViewModel> ListaFamiliares { get; set; }
        public List<string> ListaTelefonos { get; set; }

        public int IDEstablecimiento { get; set; }
        public int IDGrupo { get; set; }
        public int IDCurso { get; set; }

        //public List<DateTime> ListaFechasInscripcion { get; set; }
        //public List<DateTime> ListaFechasPago { get; set; }

        public PreinscripcionViewModel() : base()
        {
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.ListaFamiliares = new List<FamiliarViewModel>();
            this.Instituto = new EscuelaViewModel();
            this.ListaTelefonos = new List<string>(3);
            //this.ListaFechasInscripcion = new List<DateTime>();
            //this.ListaFechasPago = new List<DateTime>();
        }

        public PreinscripcionViewModel(int ID, string Nombre, string Apellido, string Mail, string DNI,
                   DateTime FechaNacimiento, string Provincia, string Departamento, string Localidad, string Domicilio,
                   Turnos Turno, int IDEstablecimiento, int IDGrupo, int IDCurso,
                   EscuelaViewModel Instituto) :
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
            this.IDEstablecimiento = IDEstablecimiento;
            this.IDGrupo = IDGrupo;
            this.IDCurso = IDCurso;
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = Instituto;
            this.ListaFamiliares = new List<FamiliarViewModel>(3);
            this.ListaTelefonos = new List<string>(3);

            //this.ListaFechasInscripcion = new List<DateTime>();
            //this.ListaFechasPago = new List<DateTime>();
        }
    }
}
