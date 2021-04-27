using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Datos;



namespace TP_Winform
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar ()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                
                datos.SetearConsulta("select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS as A inner join MARCAS as M on A.IdMarca=M.Id inner join CATEGORIAS as C on A.IdCategoria=C.Id");
                datos.LeerConsulta();

                
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca((string)datos.Lector["Marca"]);
                    aux.Categoria = new Categoria((string)datos.Lector["Categoria"]);
                   

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

        public void Agregar()
        {

        }
        public void Modificar() 
        {

        }
        public void Eliminar()
        {

        }
    }
}
