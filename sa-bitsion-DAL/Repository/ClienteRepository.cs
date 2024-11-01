using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sa_bitsion_DAL.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace sa_bitsion_DAL.Repository
{
    public class ClienteRepository
    {
        private static string nombreConexion = "Server=localhost; Database=saseguros; Uid=root; Pwd=Karamello18$;";

        public static void AgregarCliente(Cliente cliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(nombreConexion))
            {
                conexion.Open();
                string query = "INSERT INTO cliente(dni, nombreCompleto, edad, genero, estado, estadoCivil, maneja, lentes, diabetes, otraEnfermedad) " +
                    "VALUES(@param_dni, @param_nombreCompleto, @param_edad, @param_genero, @param_estado, @param_estadoCivil, @param_maneja, @param_lentes, @param_diabetes, @param_otraEnfermedad)";

                MySqlCommand commandInsert = new MySqlCommand(query, conexion);

                commandInsert.Parameters.AddWithValue("@param_dni", cliente.DNI);
                commandInsert.Parameters.AddWithValue("@param_nombrecompleto", cliente.NombreCompleto);
                commandInsert.Parameters.AddWithValue("@param_edad", cliente.Edad);
                commandInsert.Parameters.AddWithValue("@param_genero", cliente.Genero);
                commandInsert.Parameters.AddWithValue("@param_estado", cliente.Estado);
                commandInsert.Parameters.AddWithValue("@param_estadocivil", cliente.EstadoCivil);
                commandInsert.Parameters.AddWithValue("@param_maneja", cliente.Maneja);
                commandInsert.Parameters.AddWithValue("@param_lentes", cliente.Lentes);
                commandInsert.Parameters.AddWithValue("@param_diabetes", cliente.Diabetes);
                commandInsert.Parameters.AddWithValue("@param_otraEnfermedad", cliente.OtraEnfermedad);

                commandInsert.ExecuteNonQuery();
            }
        }

        public static List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(nombreConexion))
                {
                    conexion.Open();
                    string query = "SELECT * FROM cliente";
                    MySqlCommand commandSelect = new MySqlCommand(query, conexion);

                    using (MySqlDataReader reader = commandSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente(); ;

                            cliente.DNI = reader.GetInt32("dni");
                            cliente.NombreCompleto = reader.GetString("nombreCompleto");
                            cliente.Edad = reader.GetInt32("edad");
                            cliente.Genero = reader.GetString("genero");
                            cliente.Estado = reader.GetBoolean("estado");
                            cliente.EstadoCivil = reader.GetBoolean("estadoCivil");
                            cliente.Maneja = reader.GetBoolean("maneja");
                            cliente.Lentes = reader.GetBoolean("lentes");
                            cliente.Diabetes = reader.GetBoolean("diabetes");
                            cliente.OtraEnfermedad = reader.IsDBNull(reader.GetOrdinal("otraEnfermedad")) ? null : reader.GetString("otraEnfermedad");

                            listaClientes.Add(cliente);
                            Console.WriteLine(cliente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                throw;
            }
            return listaClientes;
        }

        public static Cliente ObtenerClientePorDni(int dni)
        {

            using (MySqlConnection conexion = new MySqlConnection(nombreConexion))
            {
                conexion.Open();
                string query = "SELECT * FROM cliente WHERE dni = @param_dni";

                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@param_dni", dni);

                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        return new Cliente
                        {
                            DNI = reader.GetInt32("dni"),
                            NombreCompleto = reader.GetString("nombreCompleto"),
                            Edad = reader.GetInt32("edad"),
                            Genero = reader.GetString("genero"),
                            Estado = reader.GetBoolean("estado"),
                            EstadoCivil = reader.GetBoolean("estadoCivil"),
                            Maneja = reader.GetBoolean("maneja"),
                            Lentes = reader.GetBoolean("lentes"),
                            Diabetes = reader.GetBoolean("diabetes"),
                            OtraEnfermedad = reader.IsDBNull(reader.GetOrdinal("otraEnfermedad")) ? null : reader.GetString("otraEnfermedad")
                        };
                    }
                }
            }
            return null;
        }

        public static bool DniExistente (int dni)
        {
            using (MySqlConnection conexion = new MySqlConnection(nombreConexion))
            {
                conexion.Open();
                string query = "SELECT COUNT(*) FROM cliente WHERE dni = @param_dni";

                MySqlCommand command = new MySqlCommand(query, conexion);
                command.Parameters.AddWithValue("@param_dni", dni);

                int count = Convert.ToInt32(command.ExecuteScalar()); ;
                return count > 0;
            }
        }

        public static void EliminarCliente(int dniCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(nombreConexion))
            {
                conexion.Open();
                string query = "DELETE FROM cliente WHERE dni = @dniCliente";

                MySqlCommand commandDelete = new MySqlCommand(query, conexion);

                commandDelete.Parameters.AddWithValue("@dniCliente", dniCliente);

                commandDelete.ExecuteNonQuery();
                return;
            }
        }

        public static void EditarCliente(int dniOriginal, Cliente cliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(nombreConexion))
            {
                conexion.Open();
                string query = "UPDATE cliente SET " +
                                "dni = @param_dni," +
                                "nombreCompleto = @param_nombrecompleto, " +
                                "edad = @param_edad, " +
                                "genero = @param_genero, " +
                                "estado = @param_estado, " +
                                "estadoCivil = @param_estadocivil, " +
                                "maneja = @param_manejo, " +
                                "lentes = @param_lentes, " +
                                "diabetes = @param_diabetes, " +
                                "otraEnfermedad = @param_otraenfermedad " +
                                "WHERE dni = @dniOriginal";

                MySqlCommand commandUpdate = new MySqlCommand(query, conexion);

                commandUpdate.Parameters.AddWithValue("@param_dni", cliente.DNI);
                commandUpdate.Parameters.AddWithValue("@param_nombrecompleto", cliente.NombreCompleto);
                commandUpdate.Parameters.AddWithValue("@param_edad", cliente.Edad);
                commandUpdate.Parameters.AddWithValue("@param_genero", cliente.Genero);
                commandUpdate.Parameters.AddWithValue("@param_estado", cliente.Estado);
                commandUpdate.Parameters.AddWithValue("@param_estadocivil", cliente.EstadoCivil);
                commandUpdate.Parameters.AddWithValue("@param_manejo", cliente.Maneja);
                commandUpdate.Parameters.AddWithValue("@param_lentes", cliente.Lentes);
                commandUpdate.Parameters.AddWithValue("@param_diabetes", cliente.Diabetes);
                commandUpdate.Parameters.AddWithValue("@param_otraenfermedad", cliente.OtraEnfermedad);

                commandUpdate.Parameters.AddWithValue("@dniOriginal", dniOriginal);

                commandUpdate.ExecuteNonQuery();
                return;
            }
        }
    }
}