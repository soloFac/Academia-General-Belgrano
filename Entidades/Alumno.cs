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

    public enum EstablecimientoAcademico
    {
        Capital,
        VillaQuinteros,
        JuanBautistaAlberdi,
        Virtual
    }

    public enum Grupos
    {
        FuerzasArmadas,
        FuerzasSeguridad,
        Capacitacion
    }

    public enum Cursos
    {
        Ejercito,
        Armada,
        FuerzaAerea,
        Gendarmeria,
        PrefecturaNaval,
        PoliciaFederal,
        PoliciaFederalSeguridadAeropuertaria,
        PoliciaTucuman,
        PreparatoriaVocacional,
        CursoAdaptacionMilitar,
        AsistenteSeguridadyDefensa,
        EntrenamientoCompetenciasEmocionales,
        AdiestramientoFisicoIntegral
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

        private Turnos turno;
        private EstablecimientoAcademico establecimiento;
        private Grupos grupo;
        private Cursos curso;
        private bool estado;
        private Escuela instituto;
        private List<Familiar> listaFamiliares;
        private List<string> listaTelefonos;

        private List<DateTime> listaFechasInscripcion;
        private List<DateTime> listaFechasPago;

        //Resolver consideracion con grupo

        public string Mail { get => mail; set => mail = value; }
        public string DNI { get => dNI; set => dNI = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }


        public Turnos Turno { get => turno; set => turno = value; }
        public EstablecimientoAcademico Establecimiento { get => establecimiento; set => establecimiento = value; }
        //public Grupos Grupo { get => grupo; set => grupo = value; }
        public Cursos Curso { get => curso; set => curso = value; }
        public bool Estado { get => estado; set => estado = value; }
        public Escuela Instituto { get => instituto; set => instituto = value; }
        public List<Familiar> ListaFamiliares { get => listaFamiliares; set => listaFamiliares = value; }
        public List<DateTime> ListaFechasPago { get => listaFechasPago; set => listaFechasPago = value; }
        public List<DateTime> ListaFechasInscripcion { get => listaFechasInscripcion; set => listaFechasInscripcion = value; }
        public Grupos Grupo { get => grupo; set => grupo = value; }
        public List<string> ListaTelefonos { get => listaTelefonos; set => listaTelefonos = value; }

        public Alumno() : base ()
        {
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            ListaFamiliares = new List<Familiar>();
        }

        public Alumno(int ID, string Nombre, string Apellido, string Mail, string DNI,
                   DateTime FechaNacimiento, string Provincia, string Departamento, string Localidad, string Domicilio,
                   Turnos Turno, EstablecimientoAcademico Establecimiento, Grupos Grupo, Cursos Curso, DateTime FechaInscripcion, 
                   bool estado, Escuela Instituto, List<DateTime> ListaFechasInscripcion, List<DateTime> ListaFechasPago) : 
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
            this.Establecimiento = Establecimiento;
            this.Grupo = Grupo;
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = Instituto;
            this.ListaFamiliares = new List<Familiar>(3);
            this.ListaFechasInscripcion = new List<DateTime>();
            this.ListaFechasPago = new List<DateTime>();
        }
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
