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
                conexion.ConnectionString = "data source= ALE-DSK\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=SSPI";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Codigo,Nombre,Descripcion,Precio,ImagenUrl from ARTICULOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    Articulo aux = new Articulo();
                   
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ImagenUrl = (string)lector["ImagenUrl"];
                    aux.Precio = (decimal)lector["Precio"];
                   

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
