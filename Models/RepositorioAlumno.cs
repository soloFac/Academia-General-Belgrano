using Proyecto.Entidades;
using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class RepositorioAlumno
    {
        public List<Alumno> GetAll()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<Alumno> ListaAlumnos = new List<Alumno>();

            RepositorioFamiliar nRFamiliar = new RepositorioFamiliar();

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT *, " +
                    "p.apellido AS p_apellido, p.nombre AS p_nombre, " +
                    "esc.nombre AS esc_nombre, esc.departamento AS esc_departamento, esc.localidad AS esc_localidad, esc.mail AS esc_mail, " +
                    "esc.telefono AS esc_telefono, esc.domicilio AS esc_domicilio, esc.provincia AS esc_provincia, " +
                    "curs.nombre AS curs_nombre, " +
                    "est_acad.nombre AS est_acad_nombre " +
                                                            " FROM alumnos " +
                                            "INNER JOIN personas AS p USING(id_persona) " +
                                            "INNER JOIN escuelas AS esc USING(id_escuela) " +
                                            "INNER JOIN detalles_cursos AS det_curs ON id_alumno = id_persona " +
                                            "INNER JOIN cursos AS curs USING(id_curso) " +
                                            "INNER JOIN establecimientos_academicos AS est_acad USING(id_establecimiento_academico) ";
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string today = reader["fecha_nacimiento"].ToString();
                    
                    var nAlumno = new Alumno();
                    nAlumno.ID = Convert.ToInt32(reader["id_persona"]);
                    nAlumno.Apellido = reader["apellido"].ToString();
                    nAlumno.Nombre = reader["nombre"].ToString();
                    nAlumno.DNI = reader["dni"].ToString();
                    nAlumno.Mail = reader["mail"].ToString();
                    nAlumno.FechaNacimiento = Convert.ToDateTime(reader["fecha_nacimiento"].ToString());
                    nAlumno.Provincia = reader["provincia"].ToString();
                    nAlumno.Departamento = reader["departamento"].ToString();
                    nAlumno.Localidad = reader["localidad"].ToString();
                    nAlumno.Domicilio = reader["domicilio"].ToString();
                    nAlumno.Turno = (Turnos) Convert.ToInt32(reader["turno"]);
                    nAlumno.Estado = Convert.ToBoolean(reader["estado"]);
                    nAlumno.Becado = Convert.ToBoolean(reader["becado"]);

                    //ESCUELA
                    nAlumno.Instituto.ID = Convert.ToInt32(reader["id_escuela"]);
                    nAlumno.Instituto.Nombre = reader["esc_nombre"].ToString();
                    nAlumno.Instituto.Domicilio = reader["esc_domicilio"].ToString();
                    nAlumno.Instituto.Telefono = reader["esc_telefono"].ToString();
                    nAlumno.Instituto.Mail = reader["esc_mail"].ToString();
                    nAlumno.Instituto.Localidad = reader["esc_localidad"].ToString();
                    nAlumno.Instituto.Departamento = reader["esc_departamento"].ToString();
                    nAlumno.Instituto.Provincia = reader["esc_provincia"].ToString();

                    nAlumno.EstablecimientoAlumno.ID = Convert.ToInt32(reader["id_establecimiento_academico"]);


                    nAlumno.ListaFamiliares = nRFamiliar.GetFamiliares(nAlumno.ID);
                    nAlumno.ListaFechasInscripcion = GetFechasInscripcion(nAlumno.ID);
                    nAlumno.ListaFechasPago = GetFechasPago(nAlumno.ID);
                    //nAlumno.ListaTelefonos = RepositorioHelper.GetTelefonosPersona(nAlumno.ID);
                    nAlumno.ListaCursosAlumno = GetCursosAlumno(nAlumno.ID);
                    nAlumno.ListaGruposAlumno = GetGruposAlumno(nAlumno.ID);

                    nAlumno.ListaEscuelasCursosAlumno = GetEscuelasCursosAlumno(nAlumno.ID);
                    nAlumno.EstablecimientoAlumno = RepositorioHelper.GetEstablecimientoAcademico(nAlumno.EstablecimientoAlumno.ID);
                    
                    ListaAlumnos.Add(nAlumno);
                }
            }

            return ListaAlumnos;
        }

        public void AltaAlumno(Alumno nAlumno)
        {
            RepositorioFamiliar RFamiliar = new RepositorioFamiliar();
            RepositorioEscuela REscuela = new RepositorioEscuela();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                REscuela.AltaEscuela(nAlumno.Instituto);

                nAlumno.Instituto.ID = REscuela.GetLastIDEscuelas();

                command.CommandText = "INSERT INTO personas(apellido, nombre) " +
                                        "VALUES(@apellido, @nombre)";
                //command.Parameters.AddWithValue("@id_persona", nAlumno.ID);
                command.Parameters.AddWithValue("@apellido", nAlumno.Apellido);
                command.Parameters.AddWithValue("@nombre", nAlumno.Nombre);

                command.ExecuteNonQuery();

                nAlumno.ID = GetLastIDPersonas() + 1;

                command.CommandText = "INSERT INTO alumnos(id_persona, mail, dni, fecha_nacimiento, provincia, departamento, localidad, domicilio, " +
                                                            "turno, id_establecimiento_academico, estado, id_escuela, becado) " +
                                               "VALUES(@id_persona, @mail, @dni, @fecha_nacimiento, @provincia, @departamento, @localidad, " +
                                                            "@domicilio, @turno, @id_establecimiento_academico, @estado, @id_escuela, @becado)";
                command.Parameters.AddWithValue("@id_persona", nAlumno.ID);
                command.Parameters.AddWithValue("@mail", nAlumno.Mail);
                command.Parameters.AddWithValue("@dni", nAlumno.DNI);
                command.Parameters.AddWithValue("@fecha_nacimiento", nAlumno.FechaNacimiento);
                command.Parameters.AddWithValue("@provincia", nAlumno.Provincia);
                command.Parameters.AddWithValue("@departamento", nAlumno.Departamento);
                command.Parameters.AddWithValue("@localidad", nAlumno.Localidad);
                command.Parameters.AddWithValue("@domicilio", nAlumno.Domicilio);
                command.Parameters.AddWithValue("@id_establecimiento_academico", nAlumno.EstablecimientoAlumno.ID);
                command.Parameters.AddWithValue("@estado", false);
                command.Parameters.AddWithValue("@id_escuela", nAlumno.Instituto.ID);
                command.Parameters.AddWithValue("@becado", false);

                if (nAlumno.Turno == Turnos.Mañana)
                {
                    command.Parameters.AddWithValue("@turno", "Mañana");
                }
                else if (nAlumno.Turno == Turnos.Tarde)
                {
                    command.Parameters.AddWithValue("@turno", "Tarde");
                }


                command.ExecuteNonQuery();

                AltaFechaInscripcion(nAlumno.ID, DateTime.Now);

                RepositorioHelper.AltaDetallesCursos(nAlumno.ID, nAlumno.ListaCursosAlumno[0].ID);

                foreach (Familiar familiar in nAlumno.ListaFamiliares)
                {
                    familiar.IDAlumno = nAlumno.ID;
                    RFamiliar.AltaFamiliar(familiar);
                }
                foreach (string telefono in nAlumno.ListaTelefonos)
                {
                    RepositorioHelper.AltaTelefono(nAlumno.ID, telefono);
                }

                if (nAlumno.ListaEscuelasCursosAlumno[0].ID >= 1)
                {
                    RepositorioHelper.AltaEscuelasCursos(nAlumno.ID, nAlumno.ListaEscuelasCursosAlumno[0].ID);
                }


            }
        }

        public Alumno BusquedaAlumnoID(int ID)
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos = GetAll();
            foreach (Alumno alumno in ListaAlumnos)
            {
                if (alumno.ID == ID)
                {
                    return alumno;
                }
            }
            return null;
        }

        public Alumno BusquedaAlumnoDNI(string DNI)
        {
            List<Alumno> ListaAlumnos = new List<Alumno>();
            ListaAlumnos = GetAll();
            foreach (Alumno alumno in ListaAlumnos)
            {
                if (alumno.DNI == DNI)
                {
                    return alumno;
                }
            }
            return null;
        }

        public int GetLastIDPersonas()
        {
            int IDPersona = 0;
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM personas " +
                                             "WHERE id_persona = (SELECT MAX(id_persona) FROM personas)";
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IDPersona = Convert.ToInt32(reader["id_persona"]);
                }

                return IDPersona;
            }
        }

        /// <summary>
        /// Retorna la lista de fechas de inscripciones de alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public List<DateTime> GetFechasInscripcion(int IDAlumno)
        {
            List<DateTime> ListaFechasInscripciones = new List<DateTime>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM fechas_inscripciones " +
                                            "WHERE id_alumno = " + IDAlumno.ToString();

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime FechaInscripcion = new DateTime();
                    FechaInscripcion = Convert.ToDateTime(reader["fecha_inscripcion"]);

                    ListaFechasInscripciones.Add(FechaInscripcion);
                }

                return ListaFechasInscripciones;
            }
        }


        /// <summary>
        /// Registra la fecha de inscripcion del alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <param name="FechaInscripcion"></param>
        public static void AltaFechaInscripcion(int IDAlumno, DateTime FechaInscripcion)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO fechas_inscripciones(id_alumno, fecha_inscripcion) " +
                                        "VALUES(@id_alumno, @fecha_inscripcion)";
                //command.Parameters.AddWithValue("@id_persona", nAlumno.ID);
                command.Parameters.AddWithValue("@id_alumno", IDAlumno);
                command.Parameters.AddWithValue("@fecha_inscripcion", FechaInscripcion);

                command.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// retorna una lista de grupos a los que pertenece el alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public List<Grupo> GetGruposAlumno(int IDAlumno)
        {
            List<Grupo> ListaGrupos = new List<Grupo>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM cursos " +
                                            "INNER JOIN detalles_alumnos USING(id_curso) " +
                                            "INNER JOIN grupos USING(id_grupo) WHERE id_alumno = " + IDAlumno.ToString();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Grupo nGrupo = new Grupo();
                    nGrupo = RepositorioHelper.GetGrupo(Convert.ToInt32(reader["id_grupo"]));
                    ListaGrupos.Add(nGrupo);
                }
                return ListaGrupos;
            }
        }

        /// <summary>
        /// retorna una lista de cursos a los que pertenece el alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public static List<Curso> GetCursosAlumno(int IDAlumno)
        {
            List<Curso> ListaCursos = new List<Curso>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM detalles_cursos " +
                                            "INNER JOIN cursos USING(id_curso) " +
                                            "WHERE id_alumno = " + IDAlumno.ToString();
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Curso nCurso = new Curso();
                    nCurso = RepositorioHelper.GetCurso(Convert.ToInt32(reader["id_curso"]));
                    ListaCursos.Add(nCurso);
                }
                return ListaCursos;
            }
        }

        /// <summary>
        /// Retorna una lita de cursos a los que pertenece el alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public static List<EscuelaCurso> GetEscuelasCursosAlumno(int IDAlumno)
        {
            List<EscuelaCurso> ListaEscuelasCursos = new List<EscuelaCurso>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM detalles_escuelas_cursos " +
                                            "WHERE id_alumno = " + IDAlumno.ToString();
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EscuelaCurso nEscuelaCurso = new EscuelaCurso();
                    nEscuelaCurso = RepositorioHelper.GetEscuelaCurso(Convert.ToInt32(reader["id_escuela_curso"]));
                    ListaEscuelasCursos.Add(nEscuelaCurso);
                }
                return ListaEscuelasCursos;
            }
        }


        /// <summary>
        /// Retorna una lista de fechas de pago del alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        /*public List<DateTime> GetFechasPago(int IDAlumno)
        {
            List<DateTime> ListaFechasPago = new List<DateTime>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM fechas_pagos " +
                                            "WHERE id_alumno = " + IDAlumno.ToString();

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime FechaPago = new DateTime();
                    FechaPago = (DateTime)reader["fecha_inscripcion"];

                    ListaFechasPago.Add(FechaPago);
                }

                return ListaFechasPago;
            }
        }*/

        /*
        /// <summary>
        /// Registra la fecha de pago del alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <param name="FechaPago"></param>
        public static void AltaFechasPagos(int IDAlumno, DateTime FechaPago)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO fechas_pagos(id_alumno, fecha_pago) " +
                                        "VALUES(@id_alumno, @fecha_pago)";
                //command.Parameters.AddWithValue("@id_persona", nAlumno.ID);
                command.Parameters.AddWithValue("@id_alumno", IDAlumno);
                command.Parameters.AddWithValue("@fecha_pago", FechaPago);

                command.ExecuteNonQuery();
            }
        }*/
    }
}
