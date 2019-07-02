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
    public class datTipoHabitacion
    {
        #region singleton
        private static readonly datTipoHabitacion UnicaInstancia = new datTipoHabitacion();
        public static datTipoHabitacion Instancia
        {
            get
            {
                return datTipoHabitacion.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTipoHabitacion> ListarTipoHabitacion()
        {
            SqlCommand cmd = null;
            List<entTipoHabitacion> lista = new List<entTipoHabitacion>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTipoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entTipoHabitacion TipoHabitacion = new entTipoHabitacion();

                    TipoHabitacion.idTipoHabitacion = Convert.ToInt16(dr["IdTipoHabitacion"]);
                    TipoHabitacion.desTipoHabitacion = dr["DesTipoHabitacion"].ToString();
                    TipoHabitacion.estTipoHabitacion = Convert.ToBoolean(dr["EstTipoHabitacion"]);

                    lista.Add(TipoHabitacion);
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
