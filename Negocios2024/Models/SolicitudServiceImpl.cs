using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Negocios2024.Models
{
    public class SolicitudServiceImpl : ISolicitudService
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public List<Solicitud> ConsultarPorEmpleado(int idempleado)
        {
            List<Solicitud> lista = new List<Solicitud>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("usp_consultar_sol", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idempleado", idempleado);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new Solicitud
                        {
                            nsol = dr.GetString(0),
                            fsol = dr.GetDateTime(1),
                            cliente = dr.GetString(2),
                            dircliente = dr.GetString(3),
                            idempleado = dr.GetInt32(4),
                            monto = dr.GetDecimal(5)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lista;
        }

        public bool InsertarSolicitud(Solicitud sol)
        {
            SqlCommand cmd = new SqlCommand("usp_insertar_soli", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nsol", sol.nsol);
            cmd.Parameters.AddWithValue("@fsol", sol.fsol);
            cmd.Parameters.AddWithValue("@cliente", sol.cliente);
            cmd.Parameters.AddWithValue("@dircliente", sol.dircliente);
            cmd.Parameters.AddWithValue("@idempleado", sol.idempleado);
            cmd.Parameters.AddWithValue("@monto", sol.monto);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            SqlCommand cmd = new SqlCommand("usp_listar_emp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Empleado(
                dr.GetInt32(0), dr.GetString(1)));
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();
            return lista;

        }

        public List<Solicitud> ListarSolicitudes()
        {
            List<Solicitud> lista = new List<Solicitud>();
            SqlCommand cmd = new SqlCommand("usp_listar_sol", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new Solicitud(dr.GetString(0),
               dr.GetDateTime(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetDecimal(5)
               ));
            }
            dr.Close();
            cmd.Dispose();
            conn.Close();
            return lista;
        }
    }
}