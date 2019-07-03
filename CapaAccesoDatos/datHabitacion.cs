using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class datHabitacion
    {
        #region singleton
        private static readonly datHabitacion UnicaInstancia = new datHabitacion();
        public static datHabitacion Instancia
        {
            get
            {
                return datHabitacion.UnicaInstancia;
            }

        }
        #endregion singleton


        #region metodos
        public List<entHabitacion> ListarHabitacion()
        {
            SqlCommand cmd = null;
            List<entHabitacion> lista = new List<entHabitacion>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entHabitacion Habitacion = new entHabitacion();

                    Habitacion.idHabitacion = Convert.ToInt16(dr["IdHabitacion"]);
                    Habitacion.numeroHabitacion = Convert.ToInt16(dr["NumeroHabitacion"]);
                    Habitacion.descHabitacion = dr["DescHabitacion"].ToString();

                    entTipoHabitacion TipoHabitacion = new entTipoHabitacion();
                    TipoHabitacion.desTipoHabitacion = dr["DesTipoHabitacion"].ToString();
                    Habitacion.idTipoHabitacion = TipoHabitacion;

                    lista.Add(Habitacion);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entHabitacion> ListarHabitacionPorTipo(int IdTipoHabitacion,DateTime fechaIncioReserva, DateTime fechaFinReserva)
        {
            SqlCommand cmd = null;
            List<entHabitacion> lista = new List<entHabitacion>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarHabitacionPorTipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdTipoHabitacion", IdTipoHabitacion);
                cmd.Parameters.AddWithValue("@prmdateFechaInicio", fechaIncioReserva);
                cmd.Parameters.AddWithValue("@prmdateFechaFin", fechaFinReserva);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entHabitacion Habitacion = new entHabitacion();

                    Habitacion.idHabitacion = Convert.ToInt16(dr["IdHabitacion"]);
                    Habitacion.numeroHabitacion = Convert.ToInt32(dr["NumeroHabitacion"]);
                    Habitacion.descHabitacion = dr["DescHabitacion"].ToString();

                    entTipoHabitacion TipoHabitacion = new entTipoHabitacion();
                    TipoHabitacion.desTipoHabitacion = dr["DesTipoHabitacion"].ToString();
                    TipoHabitacion.idTipoHabitacion = Convert.ToInt16(dr["IdTipoHabitacion"]);
                    Habitacion.idTipoHabitacion = TipoHabitacion;

                    lista.Add(Habitacion);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        #endregion metodos
    }
}
