using Proyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class RepositorioFamiliar
    {
        public List<Familiar> GetAll()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            List<Familiar> ListaFamiliares = new List<Familiar>();
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM familiares " +
                                                "INNER JOIN personas USING(id_persona)";
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nFamiliar = new Familiar();
                    nFamiliar.ID = Convert.ToInt32(reader["id_persona"]);
                    nFamiliar.Nombre = reader["nombre"].ToString();
                    nFamiliar.Apellido= reader["apellido"].ToString();
                    nFamiliar.Nombre = reader["nombre"].ToString();

                    nFamiliar.IDAlumno = Convert.ToInt32(reader["id_alumno"]);
                    nFamiliar.Telefono = reader["telefono"].ToString();
                    nFamiliar.Ocupacion = reader["ocupacion"].ToString();
                    nFamiliar.Empresa = reader["empresa"].ToString();
                    nFamiliar.Gremio = reader["gremio"].ToString();

                    ListaFamiliares.Add(nFamiliar);
                }
            }

            return ListaFamiliares;
        }

        public void AltaFamiliar(Familiar nFamiliar)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                //Recuperacion del ultimo ID para la insercion
                int IDTelefono = GetLastIDTelefonos() + 1;

                nFamiliar.ID = GetLastIDPersonas() + 1;

                //INSERCION DE DATOS
                command.CommandText = "INSERT INTO personas(id_persona, apellido, nombre) " +
                                        "VALUES(@id_persona, @apellido, @nombre)";
                command.Parameters.AddWithValue("@id_persona", nFamiliar.ID);
                command.Parameters.AddWithValue("@apellido", nFamiliar.Apellido);
                command.Parameters.AddWithValue("@nombre", nFamiliar.Nombre);

                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO telefonos(id_telefono, telefono, id_persona) " +
                                        "VALUES(@id_telefono, @telefono, @id_persona)";
                command.Parameters.AddWithValue("@id_telefono", IDTelefono);
                command.Parameters.AddWithValue("@telefono", nFamiliar.Telefono);
                command.Parameters.AddWithValue("@id_persona", nFamiliar.ID);

                command.CommandText = "INSERT INTO familiares(id_persona, id_alumno, ocupacion, empresa, gremio) " +
                                                            "VALUES(@id_persona, @id_alumno, @ocupacion, @empresa, @gremio)";
                command.Parameters.AddWithValue("@id_persona", nFamiliar.ID);
                command.Parameters.AddWithValue("@id_alumno", nFamiliar.IDAlumno);
                command.Parameters.AddWithValue("@ocupacion", nFamiliar.Ocupacion);
                command.Parameters.AddWithValue("@empresa", nFamiliar.Empresa);
                command.Parameters.AddWithValue("@gremio", nFamiliar.Gremio);

                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Recibe un id y retorna el familiar de tipo Familiar
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Familiar</returns>
        public Familiar BusquedaFamiliarID(int ID)
        {
            List<Familiar> ListaFamiliares = new List<Familiar>();
            ListaFamiliares = GetAll();
            foreach (Familiar familiar in ListaFamiliares)
            {
                if (familiar.ID == ID)
                {
                    return familiar;
                }
            }
            return null;
        }

        /// <summary>
        /// Recibe el id de un alumno y retorna una lista de familiares coincidentes con ese IDAlumno
        /// </summary>
        /// <param name="IDAlumno"></param>
        /// <returns>List<Familiar></returns>
        public List<Familiar> BusquedaFamiliarIDAlumno(int IDAlumno)
        {
            List<Familiar> ListaFamiliares = new List<Familiar>();
            ListaFamiliares = GetAll();
            List<Familiar> ListaFamiliaresIDAlumno = new List<Familiar>();
            foreach (Familiar familiar in ListaFamiliares)
            {
                if (familiar.IDAlumno == IDAlumno)
                {
                    ListaFamiliaresIDAlumno.Add(familiar);
                }
            }
            return ListaFamiliaresIDAlumno;
        }


        /// <summary>
        /// Retorna una lista de familiares que coincida con el apellido enviado como parametro
        /// </summary>
        /// <param name="Apellido"></param>
        /// <returns>List<Familiar></returns>
        public List<Familiar> BusquedaFamiliarApellido(string Apellido)
        {
            List<Familiar> ListaFamiliares = new List<Familiar>();
            List<Familiar> ListaFamiliaresApellido = new List<Familiar>();
            ListaFamiliares = GetAll();
            foreach (Familiar familiar in ListaFamiliares)
            {
                if (familiar.Apellido == Apellido)
                {
                    ListaFamiliaresApellido.Add(familiar);
                }
            }
            return ListaFamiliaresApellido;
        }


        /// <summary>
        /// Retorna una lista de familiares que coincida con el nombre enviado como parametro
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public List<Familiar> BusquedaFamiliarNombre(string Nombre)
        {
            List<Familiar> ListaFamiliares = new List<Familiar>();
            ListaFamiliares = GetAll();
            List<Familiar> ListaFamiliaresNombre = new List<Familiar>();
            foreach (Familiar familiar in ListaFamiliares)
            {
                if (familiar.Nombre == Nombre)
                {
                    ListaFamiliaresNombre.Add(familiar);
                }
            }
            return ListaFamiliaresNombre;
        }


        /// <summary>
        /// Retorna el primer familiar que coincida con el nombre y apellido enviado como parametro
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellido"></param>
        /// <returns></returns>
        public Familiar BusquedaFamiliarApellidoyNombre(string Apellido, string Nombre)
        {
            List<Familiar> ListaFamiliares = new List<Familiar>();
            ListaFamiliares = GetAll();
            foreach (Familiar familiar in ListaFamiliares)
            {
                if (familiar.Apellido == Apellido && familiar.Nombre == Nombre)
                {
                    return familiar;
                }
            }
            return null;
        }

        /// <summary>
        /// Obtiene el ultimo id de la lista de familiares, debe sumarle 1 para insertarlo en la base de datos
        /// </summary>
        /// <returns></returns>
        public int GetLastIDFamiliares()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT id_familiar FROM familiares" +
                                            "ORDER BY id_familiar ASC " +
                                            "LIMIT 1";
                SQLiteDataReader reader = command.ExecuteReader();

                int IDFamiliar = Convert.ToInt32(reader["id_familiar"]);

                return IDFamiliar;
            }
        }

        /// <summary>
        /// Obtiene el ultimo id del telefono registrado en la db, debe sumarle 1 si desea insertar
        /// </summary>
        /// <returns>IDTelefono</returns>
        public int GetLastIDTelefonos()
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");
            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT id_telefono FROM telefonos" +
                                            "ORDER BY id_telefono ASC " +
                                            "LIMIT 1";
                SQLiteDataReader reader = command.ExecuteReader();

                int IDTelefono = Convert.ToInt32(reader["id_telefono"]);

                return IDTelefono;
            }
        }

        /// <summary>
        /// Obtiene el ultimo id de la lista de personas, debe sumarle 1 para insertarlo en la base de datos
        /// </summary>
        /// <returns>IDFamiliar</returns>
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
