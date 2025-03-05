using dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class favoritoNegocio
    {
        public int insetarNuevo(favoritos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("INSERT INTO favoritos (IdUser, IdArticulo) " +
                       "VALUES (@IdUser, @IdArticulo); " +
                       "SELECT SCOPE_IDENTITY();");
                datos.SetearParametro("@IdUser", nuevo.idUser);
                datos.SetearParametro("@IdArticulo", nuevo.idArticulo);

                return datos.ejecutarAccionEscalar();


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
        public void actualizar(favoritos fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setConsulta("UPDATE FAVORITOS set IdUser=@IdUser,IdArticulo=@IdArticulo  where Id=@Id");
                datos.SetearParametro("@Id", fav.Id);
                datos.SetearParametro("@IdUser", fav.idUser);
                datos.SetearParametro("@IdArticulo", fav.idArticulo);
                datos.ejecutarAccion();
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

        public List<favoritos> listar()
        {
            List<favoritos> lista = new List<favoritos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select Id, IdUser, IdArticulo from FAVORITOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                     favoritos favoritos = new favoritos();
                    favoritos.Id= (int)datos.Lector["Id"];
                    favoritos.idUser = (int)datos.Lector["IdUser"];
                    favoritos.idArticulo = (int)datos.Lector["IdArticulo"];

                    lista.Add(favoritos);
                   
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
