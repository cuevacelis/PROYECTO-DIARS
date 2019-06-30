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
    public class datHospedaje
    {
        #region singleton
        private static readonly datHospedaje UnicaInstancia = new datHospedaje();
        public static datHospedaje Instancia
        {
            get
            {
                return datHospedaje.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entHospedaje> ListarHospedaje()
        {
            SqlCommand cmd = null;
            List<entHospedaje> lista = new List<entHospedaje>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarHospedaje", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entHospedaje Hospedaje = new entHospedaje();
                    entReserva Reserva = new entReserva();
                    entPersona Persona = new entPersona();
                    entHabitacion Habitacion = new entHabitacion();

                    Hospedaje.idHospedaje = Convert.ToInt16(dr["IdHospedaje"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    Persona.nombreyApellidoPersona = dr["NombreCliente"].ToString();
                    Persona.estPersona = Convert.ToBoolean(dr["EstCliente"]);
                    Hospedaje.idPersona = Persona;

                    Reserva.fechaIncioReserva = Convert.ToDateTime(dr["FechaInicioReserva"]);
                    Reserva.fechaFinReserva = Convert.ToDateTime(dr["FechaFinReserva"]);
                    Reserva.EstReserva = Convert.ToBoolean(dr["EstReserva"]);
                    Hospedaje.idReserva = Reserva;

                    Habitacion.numeroHabitacion = Convert.ToInt32(dr["NumeroHabitacion"]);
                    Habitacion.descHabitacion = dr["DescHabitacion"].ToString();
                    Habitacion.estHabitacion = Convert.ToBoolean(dr["EstHabitacion"]);
                    Hospedaje.idHabitacion = Habitacion;

                    Hospedaje.fechaLlegada = Convert.ToDateTime(dr["FechaLlegada"]);
                    Hospedaje.fechaSalida = Convert.ToDateTime(dr["FechaSalida"]);
                    Hospedaje.estHospedaje = Convert.ToBoolean(dr["EstHospedaje"]);
                    lista.Add(Hospedaje);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarHospedaje(entHospedaje H)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarHospedaje", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmdateFechaInicio", H.fechaLlegada);
                cmd.Parameters.AddWithValue("@prmdateFechaFin", H.fechaSalida);
                cmd.Parameters.AddWithValue("@prmIdPersona", H.idPersona.idPersona);
                cmd.Parameters.AddWithValue("@prmIdReserva", H.idReserva.idReserva);
                cmd.Parameters.AddWithValue("@prmIdHabitacion", H.idHabitacion.idHabitacion);
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

        public Boolean EliminarHospedaje(int idHospedaje)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarHospedaje", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidHospedaje", idHospedaje);
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
        #endregion
    }
}