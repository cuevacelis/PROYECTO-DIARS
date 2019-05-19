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
    public class datTipoCliente
    {
        #region singleton
        private static readonly datTipoCliente UnicaInstancia = new datTipoCliente();
        public static datTipoCliente Instancia
        {
            get
            {
                return datTipoCliente.UnicaInstancia;
            }

        }
        #endregion singleton


        #region metodos
        public List<entTipoCliente> ListarTipoCliente()
        {
            SqlCommand cmd = null;
            List<entTipoCliente> lista = new List<entTipoCliente>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTipoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entTipoCliente TipoCliente = new entTipoCliente();
                    TipoCliente.idTipoCliente = Convert.ToInt16(dr["IdTipoCliente"]);
                    TipoCliente.desTipoCliente = dr["DesTipoCliente"].ToString();
                    TipoCliente.estTipoCliente = Convert.ToBoolean(dr["EstTipoCliente"]);

                    lista.Add(TipoCliente);
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
