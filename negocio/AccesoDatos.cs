using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("Data Source=DESKTOP-LPCCPED\\SQLEXPRESS;Initial Catalog=CATALOGO_DB;Integrated Security=True"); 
            comando = new SqlCommand();
        }

        public void setConsulta (string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText= consulta;
        }

        public void setStoreProcedure( string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText= sp;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
                conexion.Close();
            }
        }
        public void SetearParametro(string nombre, object obj)
        {
            comando.Parameters.AddWithValue(nombre, obj);
        }

        public void ejecutarAccion()
        {
            comando.Connection= conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
