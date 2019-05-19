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
                cmd = new SqlCommand("spListaReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entReserva Reserva = new entReserva();
                    entCliente Cliente = new entCliente();

                    Reserva.idReserva = Convert.ToInt16(dr["IdReserva"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    Cliente.nombreCliente = dr["NombreCliente"].ToString();
                    Cliente.apellidoCliente = dr["ApellidoCliente"].ToString();
                    Cliente.estCliente = Convert.ToBoolean(dr["EstCliente"]);
                    Reserva.idCliente = Cliente;

                    entHabitacion Habitacion = new entHabitacion();

                    Habitacion.numeroHabitacion = Convert.ToInt16(dr["NumeroHabitacion"]);
                    Habitacion.descHabitacion = dr["DescHabitacion"].ToString();
                    //Habitacion.estHabitacion = Convert.ToBoolean(dr["EstHabitacion"]);
                    Reserva.idHabitacion = Habitacion;

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
        #endregion metodos
    }
}
