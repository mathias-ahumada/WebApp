using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class marcaNegocio
    {
        public List<Marca> listar()
		{
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
			{
                datos.setConsulta("SELECT Id,Descripcion from MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                  Marca aux = new Marca();
                    aux._idMarca = (int)datos.Lector["Id"];
                    aux._nombreMarca = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;

            }
			catch (Exception ex)
			{

				throw ex;
			}
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
