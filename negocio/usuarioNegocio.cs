using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class usuarioNegocio
    {
        public void actualizar(usuario User)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setConsulta("UPDATE USERS SET urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido WHERE Id = @id");
                datos.SetearParametro("@imagen", User.imagen!= null? User.imagen:(object)DBNull.Value);
                datos.SetearParametro("@id", User.id);
                datos.SetearParametro("@nombre", User.nombre);
                datos.SetearParametro("@apellido", User.apellido);
               
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

        public int insetarNuevo(usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("INSERT INTO USERS (email, pass) VALUES (@email, @pass); " +
                           "SELECT SCOPE_IDENTITY();");
                datos.SetearParametro("@email",nuevo.user);
                datos.SetearParametro("@pass", nuevo.pass);

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


        public bool Login(usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Select id, email, pass,urlImagenPerfil, nombre,apellido,admin from USERS where email=@email and pass=@pass");

                datos.SetearParametro("@email", nuevo.user);
                datos.SetearParametro("@pass", nuevo.pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    nuevo.id = (int )datos.Lector["id"];
                    nuevo.esAdmin = (bool)datos.Lector["admin"];
                    if(!(datos.Lector["urlImagenPerfil"]is DBNull))
                    nuevo.imagen = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        nuevo.nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        nuevo.apellido = (string)datos.Lector["apellido"];
                    

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion();}
        }

    }
}
