using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades
{
    public enum Turnos
    {
        Mañana,
        Tarde
    }

    public class Alumno : Persona
    {
        private string mail;
        private string dNI;
        private DateTime fechaNacimiento;
        private string provincia;
        private string departamento;
        private string localidad;
        private string domicilio;

        private bool becado;
        private Turnos turno;
        private EstablecimientoAcademico establecimientoAlumno;
        private List<Grupo> listaGruposAlumno;
        private List<Curso> listaCursosAlumno;
        private List<EscuelaCurso> listaEscuelasCursosAlumno;
        private bool estado;
        private Escuela instituto;
        private List<Familiar> listaFamiliares;
        private List<string> listaTelefonos;

        private List<DateTime> listaFechasInscripcion;
        private List<DateTime> listaFechasPago;

        //Resolver consideracion con grupo

        public string Mail { get => mail; set => mail = value; }
        public string DNI { get => dNI; set => dNI = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }


        public Turnos Turno { get => turno; set => turno = value; }
        public EstablecimientoAcademico EstablecimientoAlumno { get => establecimientoAlumno; set => establecimientoAlumno = value; }
        public Escuela Instituto { get => instituto; set => instituto = value; }
        public List<Familiar> ListaFamiliares { get => listaFamiliares; set => listaFamiliares = value; }
        public List<DateTime> ListaFechasPago { get => listaFechasPago; set => listaFechasPago = value; }
        public List<DateTime> ListaFechasInscripcion { get => listaFechasInscripcion; set => listaFechasInscripcion = value; }
        public List<string> ListaTelefonos { get => listaTelefonos; set => listaTelefonos = value; }
        public bool Becado { get => becado; set => becado = value; }
        public List<Grupo> ListaGruposAlumno { get => listaGruposAlumno; set => listaGruposAlumno = value; }
        public List<Curso> ListaCursosAlumno { get => listaCursosAlumno; set => listaCursosAlumno = value; }
        public List<EscuelaCurso> ListaEscuelasCursosAlumno { get => listaEscuelasCursosAlumno; set => listaEscuelasCursosAlumno = value; }

        public Alumno() : base ()
        {
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = new Escuela();
            this.EstablecimientoAlumno = new EstablecimientoAcademico();
            this.ListaGruposAlumno = new List<Grupo>();
            this.ListaCursosAlumno = new List<Curso>();
            this.ListaEscuelasCursosAlumno = new List<EscuelaCurso>();
            
            this.ListaFamiliares = new List<Familiar>();
            this.ListaTelefonos = new List<string>();
            this.ListaFechasInscripcion = new List<DateTime>();
            this.ListaFechasPago = new List<DateTime>();
        }

        /*public Alumno(int ID, string Nombre, string Apellido, string Mail, string DNI,
                   DateTime FechaNacimiento, string Provincia, string Departamento, string Localidad, string Domicilio,
                   Turnos Turno, EstablecimientoAcademico EstablecimientoAlumno, Grupo GrupoAlumno, Curso CursoAlumno, EscuelaCurso EscuelaCursoAlumno,
                   DateTime FechaInscripcion, Escuela Instituto, List<DateTime> ListaFechasInscripcion, List<DateTime> ListaFechasPago, List<string> ListaTelefonos) : 
            base (ID, Nombre, Apellido)
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
            this.EstablecimientoAlumno = EstablecimientoAlumno;
            this.GrupoAlumno = GrupoAlumno;
            this.CursoAlumno = CursoAlumno;
            this.EscuelaCursoAlumno = EscuelaCursoAlumno;
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = Instituto;
            this.ListaFamiliares = new List<Familiar>(3);
            this.ListaTelefonos = new List<string>(3);
            this.ListaFechasInscripcion = ListaFechasInscripcion;
            this.ListaFechasPago = ListaFechasPago;
        }*/
        public void AgregarFamiliar(Familiar nFamiliar)
        {
            this.ListaFamiliares.Add(nFamiliar);
        }

        public void AgregarTelefono(string telefono)
        {
            this.ListaTelefonos.Add(telefono);
        }

    }
}
