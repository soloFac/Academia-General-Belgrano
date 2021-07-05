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
                command.CommandText = "SELECT * FROM alumnos " +
                                            "INNER JOIN personas USING(id_persona) " +
                                            "INNER JOIN escuelas USING(id_escuela) " +
                                            "INNER JOIN cursos USING(id_curso) ";
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string today = reader["fecha_nacimiento"].ToString();
                    
                    var nAlumno = new Alumno();
                    nAlumno.ID = Convert.ToInt32(reader["id_persona"]);
                    nAlumno.Apellido = reader["alumnos.apellido"].ToString();
                    nAlumno.Nombre = reader["alumnos.nombre"].ToString();
                    nAlumno.DNI = reader["alumnos.dni"].ToString();
                    nAlumno.Mail = reader["alumnos.mail"].ToString();
                    nAlumno.FechaNacimiento = Convert.ToDateTime(reader["alumnos.fecha_nacimiento"].ToString());
                    nAlumno.Provincia = reader["alumnos.provincia"].ToString();
                    nAlumno.Departamento = reader["alumnos.departamento"].ToString();
                    nAlumno.Localidad = reader["alumnos.localidad"].ToString();
                    nAlumno.Domicilio = reader["alumnos.domicilio"].ToString();
                    nAlumno.Turno = (Turnos) Convert.ToInt32(reader["alumnos.turno"]);
                    nAlumno.Estado = (Boolean) reader["alumnos.estado"];
                    nAlumno.IDEstablecimiento = Convert.ToInt32(reader["id_establecimiento_academico"]);

                    //ESCUELA
                    nAlumno.Instituto.ID = Convert.ToInt32(reader["id_escuela"]);
                    nAlumno.Instituto.Nombre = reader["escuelas.nombre"].ToString();
                    nAlumno.Instituto.Domicilio = reader["escuelas.domicilio"].ToString();
                    nAlumno.Instituto.Telefono = reader["escuelas.telefono"].ToString();
                    nAlumno.Instituto.Mail = reader["escuelas.mail"].ToString();
                    nAlumno.Instituto.Localidad = reader["escuelas.localidad"].ToString();
                    nAlumno.Instituto.Departamento = reader["escuelas.departamento"].ToString();
                    nAlumno.Instituto.Provincia = reader["escuelas.provincia"].ToString();



                    //Consultar a Repositorio Familiares
                    //nAlumno.ListaFamiliares = new List<Familiar>();

                    //Consultar a repositorio fechas_inscripcion
                    //nAlumno.ListaFechasInscripcion = new List<DateTime>();

                    //Consultar a repositorio fechas_pago
                    //nAlumno.ListaFechasPago = new List<DateTime>();

                    //nAlumno.FechaInscripcion = Convert.ToDateTime(reader["fecha_inscripcion"]);
                    //nAlumno.ListaFamiliares = GetFamiliares(nAlumno.ID);


                    ListaAlumnos.Add(nAlumno);
                }
            }

            return ListaAlumnos;
        }

        public void AltaAlumno(Alumno nAlumno)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                nAlumno.ID = GetLastIDPersonas() + 1;

                command.CommandText = "INSERT INTO personas(id_persona, apellido, nombre) " +
                                        "VALUES(@id_persona, @apellido, @nombre)";
                command.Parameters.AddWithValue("@id_persona", nAlumno.ID);
                command.Parameters.AddWithValue("@apellido", nAlumno.Apellido);
                command.Parameters.AddWithValue("@nombre", nAlumno.Nombre);

                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO alumnos(id_persona , mail, dni, fecha_nacimiento, provincia, departamento, localidad, domicilio, " +
                                                            "turno, id_establecimiento_academico, estado) " +
                                                            "VALUES(@id_persona, @mail, @dni, @fecha_nacimiento, @provincia, @departamento, @localidad, " +
                                                            "@domicilio, @turno, @id_establecimiento_academico, @estado)";
                command.Parameters.AddWithValue("@id_persona", nAlumno.ID);
                command.Parameters.AddWithValue("@mail", nAlumno.Mail);
                command.Parameters.AddWithValue("@dni", nAlumno.DNI);
                command.Parameters.AddWithValue("@fecha_nacimiento", nAlumno.FechaNacimiento);
                command.Parameters.AddWithValue("@provincia", nAlumno.Provincia);
                command.Parameters.AddWithValue("@departamento", nAlumno.Departamento);
                command.Parameters.AddWithValue("@localidad", nAlumno.Localidad);
                command.Parameters.AddWithValue("@domicilio", nAlumno.Domicilio);
                command.Parameters.AddWithValue("@turno", nAlumno.Turno);
                command.Parameters.AddWithValue("@estado", nAlumno.Estado);

                command.ExecuteNonQuery();
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
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT id_persona FROM personas" +
                                            "ORDER BY id_persona ASC " +
                                            "LIMIT 1";
                SQLiteDataReader reader = command.ExecuteReader();

                int IDPersona = Convert.ToInt32(reader["id_persona"]);

                return IDPersona;
            }
        }
    }
}
