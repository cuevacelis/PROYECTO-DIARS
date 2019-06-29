using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class datReserva
    {
        #region singleton
        private static readonly datReserva UnicaInstancia = new datReserva();
        public static datReserva Instancia
        {
            get
            {
                return datReserva.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entReserva> ListarReservas()
        {
            SqlCommand cmd = null;
            List<entReserva> lista = new List<entReserva>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entReserva Reserva = new entReserva();
                    entPersona Persona = new entPersona();
                    entHabitacion Habitacion = new entHabitacion();
                    entTipoHabitacion th = new entTipoHabitacion();

                    Reserva.idReserva = Convert.ToInt16(dr["IdReserva"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    Persona.nombreyApellidoPersona = dr["Nombres"].ToString();
                    Persona.estPersona = Convert.ToBoolean(dr["EstPersona"]);
                    Reserva.idPersona = Persona;


                    th.desTipoHabitacion = dr["DesTipoHabitacion"].ToString();
                    Habitacion.idTipoHabitacion = th;

                    Habitacion.numeroHabitacion = Convert.ToInt32(dr["NumeroHabitacion"]);
                    Habitacion.descHabitacion = dr["DescHabitacion"].ToString();                    
                    //Habitacion.estHabitacion = Convert.ToBoolean(dr["EstHabitacion"]);
                    Reserva.idHabitacion = Habitacion;



                    Reserva.EstReserva = Convert.ToBoolean(dr["EstReserva"]);
                    Reserva.fechaIncioReserva = Convert.ToDateTime(dr["FechaInicioReserva"]);
                    Reserva.fechaFinReserva = Convert.ToDateTime(dr["FechaFinReserva"]);
                    lista.Add(Reserva);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarReserva(entReserva R)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmdateFechaInicio", R.fechaIncioReserva);
                cmd.Parameters.AddWithValue("@prmdateFechaFin", R.fechaFinReserva);
                cmd.Parameters.AddWithValue("@prmIdPersona", R.idPersona.idPersona);
                cmd.Parameters.AddWithValue("@prmIdHabitacion", R.idHabitacion.idHabitacion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                { insertar = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return insertar;
        }
        
        public Boolean EliminarReserva(int idReserva)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidReserva", idReserva);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                { elimina = true; }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return elimina;
        }
        #endregion metodos
    }
}
