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
    public class datCliente
    {
        
        #region singleton
        private static readonly datCliente UnicaInstancia = new datCliente();
        public static datCliente Instancia
        {
            get
            {
                return datCliente.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entCliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entCliente Cliente = new entCliente();
                    entTipoCliente TipoCliente = new entTipoCliente();

                    Cliente.idCliente = Convert.ToInt16(dr["idCliente"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    TipoCliente.desTipoCliente = dr["desTipoCliente"].ToString();
                    Cliente.idTipoCliente = TipoCliente;

                    Cliente.nombreCliente = dr["nombreCliente"].ToString();
                    Cliente.apellidoCliente = dr["apellidoCliente"].ToString();
                    Cliente.DNI = dr["dni"].ToString();
                    Cliente.telefono = Convert.ToInt16(dr["telefono"]);
                    Cliente.estCliente = Convert.ToBoolean(dr["estCliente"]);

                    lista.Add(Cliente);
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

