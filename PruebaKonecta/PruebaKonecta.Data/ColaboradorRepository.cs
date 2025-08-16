using System;
using System.Data.SqlClient;
using PruebaKonecta.Core;
using System.Configuration;

namespace PruebaKonecta.Data
{
    public class ColaboradorRepository
    {
        private string cadena = ConfigurationManager.ConnectionStrings["CadenaSQL"].ConnectionString;

        public string RegistrarColaborador(Colaborador colaborador)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    con.Open();
                    string query = @"INSERT INTO Colaborador
                        (NumeroIdentificacion, Nombres, Apellidos, Direccion, Email, Telefono, Salario, IdArea, IdSexo, FechaIngreso)
                        VALUES
                        (@NumeroIdentificacion, @Nombres, @Apellidos, @Direccion, @Email, @Telefono, @Salario, @IdArea, @IdSexo, @FechaIngreso)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NumeroIdentificacion", colaborador.NumeroIdentificacion);
                        cmd.Parameters.AddWithValue("@Nombres", colaborador.Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", colaborador.Apellidos);
                        cmd.Parameters.AddWithValue("@Direccion", colaborador.Direccion);
                        cmd.Parameters.AddWithValue("@Email", colaborador.Email);
                        cmd.Parameters.AddWithValue("@Telefono", colaborador.Telefono);
                        cmd.Parameters.AddWithValue("@Salario", colaborador.Salario);
                        cmd.Parameters.AddWithValue("@IdArea", colaborador.IdArea);
                        cmd.Parameters.AddWithValue("@IdSexo", colaborador.IdSexo);
                        cmd.Parameters.AddWithValue("@FechaIngreso", colaborador.FechaIngreso);

                        cmd.ExecuteNonQuery();
                    }
                }

                return "Colaborador registrado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public Colaborador ConsultarColaboradorPorIdentificacion(string numeroIdentificacion)
        {
            Colaborador colaborador = null;
            try
            {
                using (SqlConnection con = new SqlConnection(cadena))
                {
                    con.Open();
                    string query = @"SELECT c.NumeroIdentificacion, c.Nombres, c.Apellidos, c.Salario, c.IdArea, c.IdSexo
                                     FROM Colaborador c
                                     WHERE c.NumeroIdentificacion = @NumeroIdentificacion";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NumeroIdentificacion", numeroIdentificacion);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                colaborador = new Colaborador
                                {
                                    NumeroIdentificacion = reader["NumeroIdentificacion"].ToString(),
                                    Nombres = reader["Nombres"].ToString(),
                                    Apellidos = reader["Apellidos"].ToString(),
                                    Salario = Convert.ToDecimal(reader["Salario"]),
                                    IdArea = Convert.ToInt32(reader["IdArea"]),
                                    IdSexo = Convert.ToInt32(reader["IdSexo"])
                                };
                            }
                        }
                    }
                }
            }
            catch
            {
                colaborador = null;
            }

            return colaborador;
        }
    }
}
