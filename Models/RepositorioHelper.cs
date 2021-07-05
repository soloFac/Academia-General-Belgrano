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
    }
}
