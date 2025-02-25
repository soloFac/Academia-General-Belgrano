﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public EstablecimientoAcademico Establecimiento { get; set; }
        //public Grupos Grupo;
        public Cursos Curso { get; set; }
        public Grupos Grupo { get; set; }
        public bool Estado { get; set; }
        public Escuela Instituto { get; set; }
        public List<Familiar> ListaFamiliares { get; set; }
        public List<string> ListaTelefonos { get; set; }

        //public List<DateTime> ListaFechasInscripcion { get; set; }
        //public List<DateTime> ListaFechasPago { get; set; }

        public AlumnoViewModel() : base()
        {
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            ListaFamiliares = new List<Familiar>();
            //this.ListaFechasInscripcion = new List<DateTime>();
            //this.ListaFechasPago = new List<DateTime>();
        }

        public AlumnoViewModel(int ID, string Nombre, string Apellido, string Telefono, string Mail, string DNI,
                   DateTime FechaNacimiento, string Provincia, string Departamento, string Localidad, string Domicilio,
                   Turnos Turno, EstablecimientoAcademico Establecimiento, Grupos Grupo, Cursos Curso, DateTime FechaInscripcion,
                   bool estado, Escuela Instituto) :
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
            //AGREGAR 
            //FechaInscripcion = DateTime.Now;
            this.Estado = false;
            this.Instituto = Instituto;
            this.ListaFamiliares = new List<Familiar>();
            //this.ListaFechasInscripcion = new List<DateTime>();
            //this.ListaFechasPago = new List<DateTime>();
        }
    }
}
