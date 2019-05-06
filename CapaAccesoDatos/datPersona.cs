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
    public class datPersona
    {
        #region singleton
        private static readonly datPersona UnicaInstancia = new datPersona();
        public static datPersona Instancia
        {
            get
            {
                return datPersona.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<entPersona> ListarPersona()
        {
            SqlCommand cmd = null;
            List<entPersona> lista = new List<entPersona>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListaPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entPersona pers= new entPersona();
                    entCiudad  ciu = new entCiudad();
                    entTipoPersona tp = new entTipoPersona();

                    pers.idPersona = Convert.ToInt16(dr["idPersona"]);
                    pers.rucPersona = dr["rucPersona"].ToString();
                    pers.razPersona = dr["razPersona"].ToString();
                    pers.dirPersona = dr["dirPersona"].ToString();
                    //pers.ciuPersona = Convert.ToInt16(dr["ciuPersona"]);
                    ciu.idCiudad = Convert.ToInt16(dr["ciuPersona"]);
                    pers.ciuPersona = ciu;
                    ciu.desCiudad = dr["desCiudad"].ToString();
                    pers.estPersona = Convert.ToBoolean(dr["estPersona"]);
                    //pers.tipPersona = Convert.ToInt16(dr["TipPersona"]);

                    tp.idTipoPersona = Convert.ToInt16(dr["TipPersona"]);
                    pers.tipPersona = tp;
                    tp.desTipoPersona = dr["desTipoPersona"].ToString();
                    pers.finPersona = Convert.ToDateTime(dr["finPersona"]);
                    lista.Add(pers);

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarPersona(entPersona p)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertaPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrrucPersona", p.rucPersona);
                cmd.Parameters.AddWithValue("@prmstrrazPersona", p.razPersona);
                cmd.Parameters.AddWithValue("@prmstrdirPersona", p.dirPersona);
                cmd.Parameters.AddWithValue("@prmintciuPersona", p.ciuPersona);
                cmd.Parameters.AddWithValue("@prmbolestPersona", p.estPersona);
                cmd.Parameters.AddWithValue("@prminttipPersona", p.tipPersona);
                cmd.Parameters.AddWithValue("@prmdatfinPersona", p.finPersona);
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
        public entPersona BuscarPersona(int idPersona)
        {
            SqlCommand cmd = null;
            entPersona p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarPersonaid", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona", idPersona);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new entPersona();
                    entCiudad ciu = new entCiudad();
                    entTipoPersona tp = new entTipoPersona();
                    p.idPersona = Convert.ToInt16(dr["idPersona"]);
                    p.rucPersona = dr["rucPersona"].ToString();
                    p.razPersona = dr["razPersona"].ToString();
                    p.dirPersona = dr["dirPersona"].ToString();
                    ciu.idCiudad = Convert.ToInt16(dr["ciuPersona"]);
                    p.ciuPersona = ciu;
                    ciu.desCiudad = dr["desCiudad"].ToString();
                    p.estPersona = Convert.ToBoolean(dr["estPersona"]);
                    tp.idTipoPersona= Convert.ToInt16(dr["tipPersona"]);
                    p.tipPersona = tp;
                    tp.desTipoPersona = dr["desTipoPersona"].ToString();
                    p.finPersona = Convert.ToDateTime(dr["finPersona"]);
                }
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return p;

        }
        public Boolean EditarPersona(entPersona p)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona",  p.idPersona);
                cmd.Parameters.AddWithValue("@prmstrrucPersona", p.rucPersona);
                cmd.Parameters.AddWithValue("@prmstrrazPersona", p.razPersona);
                cmd.Parameters.AddWithValue("@prmstrdirPersona", p.dirPersona);
                cmd.Parameters.AddWithValue("@prmintciuPersona", p.ciuPersona);

                cmd.Parameters.AddWithValue("@prmbolestPersona", p.estPersona ? 1 : 0);
                cmd.Parameters.AddWithValue("@prminttipPersona", p.tipPersona);
                cmd.Parameters.AddWithValue("@prmdatfinPersona", p.finPersona);


                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }
        ///
        public Boolean EliminarPersona(entPersona p)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona", p.idPersona);
                cmd.Parameters.AddWithValue("@prmbolestPersona", p.estPersona ? 1 : 0);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    elimina = true;
                }
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
