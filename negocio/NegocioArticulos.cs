using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using dominio;


namespace negocio
{
    public class NegocioArticulos
    {
        public List<articulos> listar(string id="")
        {
            List<articulos> lista = new List<articulos>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "Data Source=DESKTOP-LPCCPED\\SQLEXPRESS;Initial Catalog=CATALOGO_DB;Integrated Security=True";
                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "SELECT A.Id, Codigo, Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, ImagenUrl, Precio,M.Id,C.Id FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria ";
                if(id!="")
                    comando.CommandText += "and A.Id= "+id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    articulos aux = new articulos();

                    aux._idArticulo = (int)lector["Id"];
                    aux._CodigoArticulo = (string)lector["Codigo"];
                    aux._nombre = (string)lector["Nombre"];
                    aux._descripArticulo = (string)lector["Descripcion"];
                    aux._precio = (decimal)lector["Precio"];




                    aux.DescripcionMarca = new Marca();
                    aux.DescripcionCategoria = new Categoria();

                    aux.DescripcionCategoria._nombreCategoria = (string)lector["Categoria"];
                    aux.DescripcionCategoria._idCategoria = (int)lector["Id"];
                    aux.DescripcionMarca._nombreMarca = (string)lector["Marca"];
                    aux.DescripcionMarca._idMarca = (int)lector["Id"];

                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)lector["ImagenUrl"];

                    lista.Add(aux); }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificar(articulos ar)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("update ARTICULOS SET Codigo=@codigo,Nombre=@nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,ImagenUrl=@Imagen,Precio=@Precio Where Id=@id");
                datos.SetearParametro("@codigo", ar._CodigoArticulo);
                datos.SetearParametro("@nombre", ar._nombre);
                datos.SetearParametro("@descripcion", ar._descripArticulo);
                datos.SetearParametro("@IdMarca", ar.DescripcionMarca._idMarca);
                datos.SetearParametro("@IdCategoria", ar.DescripcionCategoria._idCategoria);
                datos.SetearParametro("@Imagen", ar.UrlImagen);
                datos.SetearParametro("@Precio", ar._precio);
                datos.SetearParametro(@"Id", ar._idArticulo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<articulos> listarConSp()
        {
            List<articulos> lista = new List<articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, ImagenUrl, Precio,M.Id,C.Id FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria";




                //datos.setConsulta(consulta);

                datos.setStoreProcedure("consultaLista");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulos aux = new articulos();

                    aux._idArticulo = (int)datos.Lector["Id"];
                    aux._CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux._nombre = (string)datos.Lector["Nombre"];
                    aux._descripArticulo = (string)datos.Lector["Descripcion"];
                    aux._precio = (decimal)datos.Lector["Precio"];



                    aux.DescripcionMarca = new Marca();
                    aux.DescripcionCategoria = new Categoria();

                    aux.DescripcionCategoria._nombreCategoria = (string)datos.Lector["Categoria"];
                    aux.DescripcionCategoria._idCategoria = (int)datos.Lector["Id"];
                    aux.DescripcionMarca._nombreMarca = (string)datos.Lector["Marca"];
                    aux.DescripcionMarca._idMarca = (int)datos.Lector["Id"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

       public void agregarArt(articulos nuevo)

        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio,IdMarca,IdCategoria,ImagenUrl)values('" + nuevo._CodigoArticulo + "', '" + nuevo._nombre + "', '" + nuevo._descripArticulo + "', "+nuevo._precio+",@IdMarca,@IdCategoria,@ImagenUrl)");


                datos.SetearParametro("@IdMarca", nuevo.DescripcionMarca._idMarca);
                datos.SetearParametro("@idCategoria", nuevo.DescripcionCategoria._idCategoria);
                datos.SetearParametro("@ImagenUrl",nuevo.UrlImagen);

                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public  List<articulos> filtro(string campo, string criterio,string filtroo)
        {
            List<articulos> lista = new List<articulos>();
            AccesoDatos datos= new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, ImagenUrl, Precio,M.Id,C.Id FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtroo;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtroo;
                            break;
                        default:
                            consulta += "Precio = " + filtroo;
                            break;
                    }
                }
                else if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Codigo like '" + filtroo + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Codigo like '%" + filtroo + "'";
                            break;
                        default:
                            consulta += "Codigo like '%" + filtroo + "%'";
                            break;
                    }
                }else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtroo + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtroo + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtroo + "%'";
                            break;
                    }
                }
               

                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    articulos aux = new articulos();

                    aux._idArticulo = (int)datos.Lector["Id"];
                    aux._CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux._nombre = (string)datos.Lector["Nombre"];
                    aux._descripArticulo = (string)datos.Lector["Descripcion"];
                    aux._precio = (decimal)datos.Lector["Precio"];



                    aux.DescripcionMarca = new Marca();
                    aux.DescripcionCategoria = new Categoria();

                    aux.DescripcionCategoria._nombreCategoria = (string)datos.Lector["Categoria"];
                    aux.DescripcionCategoria._idCategoria = (int)datos.Lector["Id"];
                    aux.DescripcionMarca._nombreMarca = (string)datos.Lector["Marca"];
                    aux.DescripcionMarca._idMarca = (int)datos.Lector["Id"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminar(int id)
        {
            
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("delete from ARTICULOS where Id=@Id");
                datos.SetearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        

    }
}

