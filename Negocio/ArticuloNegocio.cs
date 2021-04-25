using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace TP_Winform
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar ()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando= new SqlCommand();
            SqlDataReader lector;
            

            try
            {
                conexion.ConnectionString = "data source=DESKTOP-041OPAQ\\SQLEXPRESS01; initial catalog= CATALOGO_DB; integrated security=SSPI";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl, A.Precio from ARTICULOS as A inner join MARCAS as M on A.IdMarca=M.Id inner join CATEGORIAS as C on A.IdCategoria=C.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ImagenUrl = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.Marca = new Marca((string)lector["Marca"]);
                    aux.Categoria = new Categoria((string)lector["Categoria"]);
                   

                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
