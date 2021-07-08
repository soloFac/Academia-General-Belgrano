using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class RepositorioPago
    {
        public void RealizarPago(int IDAlumno, string mes)
        {
            //RepositorioHelper

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
    }
}
