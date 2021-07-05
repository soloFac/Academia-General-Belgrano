using Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public static class RepositorioHelper
    {
        public static List<Grupo> GetAllGrupos()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<Grupo> ListaGrupos = new List<Grupo>();

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM grupos";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nGrupo = new Grupo();
                    nGrupo.ID = Convert.ToInt32(reader["id_grupo"]);
                    nGrupo.Nombre = reader["nombre"].ToString();

                    ListaGrupos.Add(nGrupo);
                }
            }

            return ListaGrupos;
        }

        public static List<Curso> GetAllCursos()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<Curso> ListaCursos = new List<Curso>();

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM cursos";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nCurso = new Curso();
                    nCurso.ID = Convert.ToInt32(reader["id_curso"]);
                    nCurso.Nombre = reader["nombre"].ToString();
                    nCurso.IDGrupo = Convert.ToInt32(reader["id_grupo"]);

                    ListaCursos.Add(nCurso);
                }
            }

            return ListaCursos;
        }

        public static List<EscuelaCurso> GetAllEscuelasCursos()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<EscuelaCurso> ListaEscuelasCursos = new List<EscuelaCurso>();

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM escuelas_cursos";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nEscuelaCurso = new EscuelaCurso();
                    nEscuelaCurso.ID = Convert.ToInt32(reader["id_escuela_curso"]);
                    nEscuelaCurso.Nombre = reader["nombre"].ToString();
                    nEscuelaCurso.IDCurso = Convert.ToInt32(reader["id_curso"]);

                    ListaEscuelasCursos.Add(nEscuelaCurso);
                }
            }

            return ListaEscuelasCursos;
        }

        public static List<EstablecimientoAcademico> GetAllEstablecimientosAcademicos()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<EstablecimientoAcademico> ListaEstablecimientos = new List<EstablecimientoAcademico>();

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM establecimientos_academicos";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nEstablecimiento = new EstablecimientoAcademico();
                    nEstablecimiento.ID = Convert.ToInt32(reader["id_establecimiento_academico"]);
                    nEstablecimiento.Nombre = reader["nombre"].ToString();

                    ListaEstablecimientos.Add(nEstablecimiento);
                }
            }

            return ListaEstablecimientos;
        }

        /// <summary>
        /// Agrega el alumno a el curso
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <param name="IDCurso"></param>
        public static void AltaDetallesCursos(int IDAlumno, int IDCurso)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO detalles_cursos(id_curso, id_alumno) " +
                            "VALUES(@id_curso, @id_alumno)";
                command.Parameters.AddWithValue("@id_curso", IDCurso);
                command.Parameters.AddWithValue("@id_alumno", IDAlumno);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Agrega un telefono para el alumno en la db
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <param name="Telefono"></param>
        public static void AltaTelefono(int IDAlumno, string Telefono)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO telefonos(id_persona, telefono) " +
                            "VALUES(@id_persona, @telefono)";
                command.Parameters.AddWithValue("@id_persona", IDAlumno);
                command.Parameters.AddWithValue("@telefono", Telefono);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Agrega al alumno a la escuela del curso
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <param name="Telefono"></param>
        public static void AltaEscuelasCursos(int IDAlumno, int IDEscuelaCurso)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO detalles_escuelas_cursos(id_alumno, id_escuela_curso) " +
                                        "VALUES(@id_alumno, @id_escuela_curso)";
                command.Parameters.AddWithValue("@id_alumno", IDAlumno);
                command.Parameters.AddWithValue("@id_escuela_curso", IDEscuelaCurso);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Agrega la fecha de inscripcion del alumno
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
                command.Parameters.AddWithValue("@id_alumno", IDAlumno);
                command.Parameters.AddWithValue("@fecha_inscripcion", FechaInscripcion);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Agrega la fecha de pago del alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <param name="FechaPago"></param>
        public static void AltaFechaPago(int IDAlumno, DateTime FechaPago)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO fechas_pago(id_alumno, fecha_pago) " +
                                        "VALUES(@id_alumno, @fecha_pago)";
                command.Parameters.AddWithValue("@id_alumno", IDAlumno);
                command.Parameters.AddWithValue("@fecha_pago", FechaPago);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retorna el Curso al que pertenece el alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public static Curso GetCursoAlumno(int IDAlumno)
        {
            Curso nCurso = new Curso();
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
                    nCurso.ID = Convert.ToInt32(reader["id_curso"]);
                    nCurso.IDGrupo = Convert.ToInt32(reader["id_grupo"]);
                    nCurso.Nombre = reader["nombre"].ToString();
                }

                return nCurso;
            }
        }

        /// <summary>
        /// Retorna el grupo al que pertence el curso
        /// </summary>
        /// <param name="IDCurso"></param>
        /// <returns></returns>
        public static Grupo GetGrupoAlumno(int IDGrupo)
        {
            Grupo nGrupo = new Grupo();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM grupos " +
                                            "WHERE id_grupo = " + IDGrupo.ToString();

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nGrupo.ID = Convert.ToInt32(reader["id_grupo"]);
                    nGrupo.Nombre = reader["nombre"].ToString();
                }

                return nGrupo;
            }
        }

        /// <summary>
        /// Retorna una Escuela del Curso elegido por el alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public static EscuelaCurso GetEscuelaCursoAlumno(int IDEscuelaCurso)
        {
            EscuelaCurso nEscuelaCurso = new EscuelaCurso();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM escuelas_cursos " +
                                            "WHERE id_escuela_curso = " + IDEscuelaCurso.ToString();

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nEscuelaCurso.ID = Convert.ToInt32(reader["id_escuela_curso"]);
                    nEscuelaCurso.Nombre = reader["nombre"].ToString();
                    nEscuelaCurso.IDCurso = Convert.ToInt32(reader["id_curso"]);
                }

                return nEscuelaCurso;
            }
        }

        /// <summary>
        /// Retorna el establecimiento academico del alumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns></returns>
        public static EstablecimientoAcademico GetEstablecimientoAcademico(int IDEstablecimiento)
        {
            EstablecimientoAcademico nEstablecimiento = new EstablecimientoAcademico();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM establecimientos_academicos " +
                                            "WHERE id_establecimiento_academico = " + IDEstablecimiento.ToString();

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nEstablecimiento.ID = Convert.ToInt32(reader["id_establecimiento_academico"]);
                    nEstablecimiento.Nombre = reader["nombre"].ToString();
                }

                return nEstablecimiento;
            }
        }

        /// <summary>
        /// Retorna la lista de telefonos de la persona
        /// </summary>
        /// <param name="IDCurso"></param>
        /// <returns></returns>
        public static List<string> GetTelefonosPersona(int IDPersona)
        {
            List<string> ListaTelefonos = new List<string>();
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM telefonos " +
                                            "WHERE id_persona = " + IDPersona.ToString();

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Telefono;
                    Telefono = reader["telefono"].ToString();
                    ListaTelefonos.Add(Telefono);
                }

                return ListaTelefonos;
            }
        }

        
    }
}
