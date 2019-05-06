using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class datProducto
    {
        #region singleton
        private static readonly datProducto UnicaInstancia = new datProducto();
        public static datProducto Instancia
        {
            get
            {
                return datProducto.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<entProducto> ListarProducto()
        {
            SqlCommand cmd = null;
            List<entProducto> lista = new List<entProducto>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entTipoProducto tp = new entTipoProducto();
                    entProducto p = new entProducto();
                    entColor c = new entColor();
                    entMatPrima mp = new entMatPrima();

                    p.idProducto = Convert.ToInt16(dr["idProducto"]);
                    p.desProducto = dr["desProducto"].ToString();

                    //tp.idTipoProducto = Convert.ToInt16(dr["idTipoProducto"]);
                    tp.desTipoProducto = dr["desTipoProducto"].ToString();
                    p.idTipoProducto = tp;

                    //mp.idMaterial = Convert.ToInt16(dr["idMaterial"]);
                    mp.desMaterial = dr["desMaterial"].ToString();
                    p.idMaterial =mp;

                    p.preProducto = Convert.ToDouble(dr["preProducto"]);

                    //c.idColor = Convert.ToInt16(dr["idColor"]);
                    c.desColor = dr["desColor"].ToString();
                    p.idColor = c;

                    p.stkProducto = Convert.ToInt16(dr["stkPRoducto"]);
                    p.fcrProducto = Convert.ToDateTime(dr["fcrPRoducto"]);
                    p.estProducto = Convert.ToBoolean(dr["estProducto"]);
                    lista.Add(p);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }
        public Boolean InsertarProducto(entProducto a)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrdesProducto", a.desProducto);
                cmd.Parameters.AddWithValue("@prmdoupreProducto", a.preProducto);
                cmd.Parameters.AddWithValue("@prmstrimgProducto", a.imgProducto);
                cmd.Parameters.AddWithValue("@prmintstkProducto", a.stkProducto);
                cmd.Parameters.AddWithValue("@prmdatfcrProducto", a.fcrProducto);
                cmd.Parameters.AddWithValue("@prmbolestProducto", a.estProducto);
                cmd.Parameters.AddWithValue("@prmintidColor", a.idColor.idColor);
                cmd.Parameters.AddWithValue("@prmintMatPrima", a.idMaterial.idMaterial);
                cmd.Parameters.AddWithValue("@prmintTipoProducto", a.idTipoProducto.idTipoProducto);


                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Inserta;
        }
        #endregion metodos
    }
}
