using Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class RepositorioEscuela
    {
        public List<Escuela> GetAll()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<Escuela> ListaEscuelas = new List<Escuela>();
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM escuelas";
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nEscuela = new Escuela();
                    nEscuela.ID = Convert.ToInt32(reader["id_persona"]);
                    nEscuela.Nombre = reader["nombre"].ToString();
                    nEscuela.Domicilio = reader["domicilio"].ToString();
                    nEscuela.Telefono = reader["telefono"].ToString();
                    nEscuela.Mail = reader["mail"].ToString();
                    nEscuela.Localidad = reader["localidad"].ToString();
                    nEscuela.Departamento = reader["departamento"].ToString();
                    nEscuela.Provincia = reader["provincia"].ToString();
                    ListaEscuelas.Add(nEscuela);
                }
            }

            return ListaEscuelas;
        }

        public void AltaEscuela(Escuela nEscuela)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO escuelas(nombre, domicilio, telefono, mail, localidad, departamento, provincia) " +
                                                    "VALUES(@nombre, @domicilio, @telefono, @mail, @localidad, @departamento, @provincia)";
                command.Parameters.AddWithValue("@nombre", nEscuela.Nombre);
                command.Parameters.AddWithValue("@domicilio", nEscuela.Domicilio);
                command.Parameters.AddWithValue("@telefono", nEscuela.Telefono);
                command.Parameters.AddWithValue("@mail", nEscuela.Mail);
                command.Parameters.AddWithValue("@localidad", nEscuela.Localidad);
                command.Parameters.AddWithValue("@departamento", nEscuela.Departamento);
                command.Parameters.AddWithValue("@provincia", nEscuela.Provincia);

                command.ExecuteNonQuery();
            }
        }

        public Escuela BusquedaEscuelaID(int ID)
        {
            List<Escuela> ListaEscuelas = new List<Escuela>();
            ListaEscuelas = GetAll();
            foreach (Escuela escuela in ListaEscuelas)
            {
                if (escuela.ID == ID)
                {
                    return escuela;
                }
            }
            return null;
        }

        public Escuela BusquedaEscuelaDepartamento(string Departamento)
        {
            List<Escuela> ListaEscuelas = new List<Escuela>();
            ListaEscuelas = GetAll();
            foreach (Escuela escuela in ListaEscuelas)
            {
                if (escuela.Departamento == Departamento)
                {
                    return escuela;
                }
            }
            return null;
        }

        public Escuela BusquedaEscuelaNombre(string Nombre)
        {
            List<Escuela> ListaEscuelas = new List<Escuela>();
            ListaEscuelas = GetAll();
            foreach (Escuela escuela in ListaEscuelas)
            {
                if (escuela.Nombre == Nombre)
                {
                    return escuela;
                }
            }
            return null;
        }

        /// <summary>
        /// Obtiene el ultimo ID de la Escuela registrada, si desea insertar debe sumarle 1
        /// </summary>
        /// <returns></returns>
        public int GetLastIDEscuelas()
        {
            int IDEscuela = 0;
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM escuelas " +
                                             "WHERE id_escuela = (SELECT MAX(id_escuela) FROM escuelas)";

                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IDEscuela = Convert.ToInt32(reader["id_escuela"]);
                }

                return IDEscuela;
            }
        }
    }
}
