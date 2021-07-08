using Proyecto.Entidades;
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
        public void AltaPago(Pago nPago)
        {
            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO pagos(nombre, mes, saldo, id_alumno) " +
                                                 "VALUES(@nombre, @mes, @saldo, @id_alumno) ";

                command.Parameters.AddWithValue("@mes", nPago.Mes);
                command.Parameters.AddWithValue("@saldo", nPago.Saldo);
                command.Parameters.AddWithValue("@id_alumno", nPago.IDAlumno);

                command.ExecuteNonQuery();

            }
        }

        public void RealizarPago(Pago nPago, decimal Monto)
        {
            //RepositorioHelper

            string cadena = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "DataBase\\DataBase.db");

            using (var connection = new SQLiteConnection(cadena))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO detalles_pagos(id_pago, fecha_pago, monto) " +
                                                 "VALUES(@id_pago, @fecha_pago, @monto)";
                command.Parameters.AddWithValue("@id_pago", nPago.ID);
                command.Parameters.AddWithValue("@fecha_pago", DateTime.Now);
                command.Parameters.AddWithValue("@monto", Monto);
                command.ExecuteNonQuery();


                command.CommandText = "UPDATE pagos SET saldo = (saldo - @monto)" +
                                                       "WHERE mes = @mes " +
                                                       "AND id_pago = @id_pago";
                command.Parameters.AddWithValue("@monto", Monto);
                command.Parameters.AddWithValue("@mes", nPago.Mes);
                command.Parameters.AddWithValue("@id_pago", nPago.ID);
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
