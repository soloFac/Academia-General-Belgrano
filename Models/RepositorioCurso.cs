using Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class RepositorioCurso
    {
        /// <summary>
        /// Obtiene todos los datos de los cursos registrados
        /// </summary>
        /// <returns></returns>
        public List<Curso> GetAllCursos()
        {
            List<Curso> ListaCursos = new List<Curso>();

            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

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
                    nCurso.IDGrupo = Convert.ToInt32(reader["id_grupo"]);
                    nCurso.Nombre = reader["nombre"].ToString();
                    nCurso.Precio = Convert.ToDecimal(reader["precio"]);
                    nCurso.Precio_Inscripcion = Convert.ToInt32(reader["precio_inscripcion"]);
                    nCurso.Tiene_Escuela = Convert.ToBoolean(reader["tiene_escuela"]);

                    ListaCursos.Add(nCurso);
                }
            }
            return ListaCursos;
        }

        /// <summary>
        /// Obtiene todos los datos de las Escuelas de los Cursos de los registrados
        /// </summary>
        /// <returns></returns>
        public List<EscuelaCurso> GetAllEscuelasCursos()
        {
            List<EscuelaCurso> ListaEscuelasCursos = new List<EscuelaCurso>();

            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM escuelas_cursos";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var EscuelaCurso = new EscuelaCurso();

                    EscuelaCurso.ID = Convert.ToInt32(reader["id_escuela_curso"]);
                    EscuelaCurso.IDCurso = Convert.ToInt32(reader["id_curso"]);
                    EscuelaCurso.Nombre = reader["nombre"].ToString();
                    EscuelaCurso.Precio = Convert.ToDecimal(reader["precio"]);
                    EscuelaCurso.Precio_Inscripcion = Convert.ToInt32(reader["precio_inscripcion"]);
                    EscuelaCurso.Oficial = Convert.ToBoolean(reader["oficial"]);

                    ListaEscuelasCursos.Add(EscuelaCurso);
                }
            }
            return ListaEscuelasCursos;
        }


        public void AltaCurso(Curso nCurso)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO cursos(nombre, precio, precio_inscripcion, tiene_escuela, id_grupo) " +
                                                 "VALUES(@nombre, @precio, @precio_inscripcion, @tiene_escuela, @id_grupo)";

                command.Parameters.AddWithValue("@nombre", nCurso.Nombre);
                command.Parameters.AddWithValue("@precio", nCurso.Precio);
                command.Parameters.AddWithValue("@precio_inscripcion", nCurso.Precio_Inscripcion);
                command.Parameters.AddWithValue("@tiene_escuela", nCurso.Tiene_Escuela);
                command.Parameters.AddWithValue("@id_grupo", nCurso.IDGrupo);

                command.ExecuteNonQuery();
            }
        }

        public void AltaEscuelaCurso(EscuelaCurso nCurso)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO cursos(nombre, precio, precio_inscripcion, oficial, id_curso) " +
                                                 "VALUES(@nombre, @precio, @precio_inscripcion, @oficial, @id_curso)";

                command.Parameters.AddWithValue("@nombre", nCurso.Nombre);
                command.Parameters.AddWithValue("@precio", nCurso.Precio);
                command.Parameters.AddWithValue("@precio_inscripcion", nCurso.Precio_Inscripcion);
                command.Parameters.AddWithValue("@tiene_escuela", nCurso.Oficial);
                command.Parameters.AddWithValue("@id_grupo", nCurso.IDCurso);

                command.ExecuteNonQuery();
            }
        }

    }
}
