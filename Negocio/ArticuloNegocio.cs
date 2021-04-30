using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;
using Dominio;



namespace Negocio

{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar ()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
          

            try
            {
                
                datos.SetearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl, A.Precio, M.Id as IdMarca, C.Id as IdCategoria from ARTICULOS as A inner join MARCAS as M on A.IdMarca=M.Id inner join CATEGORIAS as C on A.IdCategoria=C.Id");
                datos.LeerConsulta();

                
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca((string)datos.Lector["Marca"]);
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria((string)datos.Lector["Categoria"]);
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];


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
                datos.CerrarConexion();
            }
        }

        public void Agregar(Articulo aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                  
                datos.SetearConsulta("insert into Articulos(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values ( @codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");
                datos.AgregarParametro("@codigo", aux.Codigo);
                datos.AgregarParametro("@nombre", aux.Nombre);
                datos.AgregarParametro("@descripcion", aux.Descripcion);
                datos.AgregarParametro("@idMarca", aux.Marca.Id);
                datos.AgregarParametro("@idCategoria", aux.Categoria.Id);
                datos.AgregarParametro("@imagenUrl", aux.ImagenUrl);
                datos.AgregarParametro("@precio", aux.Precio);
     

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void Modificar(Articulo aux) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update Articulos set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio Where Id = @id");
                datos.AgregarParametro("@codigo", aux.Codigo);
                datos.AgregarParametro("@nombre", aux.Nombre);
                datos.AgregarParametro("@descripcion", aux.Descripcion);
                datos.AgregarParametro("@idMarca", aux.Marca.Id);
                datos.AgregarParametro("@idCategoria", aux.Categoria.Id);
                datos.AgregarParametro("@imagenUrl", aux.ImagenUrl);
                datos.AgregarParametro("@precio", aux.Precio);
                datos.AgregarParametro("@id", aux.Id);

                datos.EjecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        public void Eliminar(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                
                datos.SetearConsulta(" delete from ARTICULOS where Codigo = '"+ codigo +"'");
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
         

        }
    }
}
