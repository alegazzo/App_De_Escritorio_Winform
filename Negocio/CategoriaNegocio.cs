using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;
using System.Data.SqlClient;

namespace Negocio
{
    public class CategoriaNegocio
    {
       
        public List<Categoria> listar()
        {

            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select Id, Descripcion from Categorias");
                datos.LeerConsulta();

                while (datos.Lector.Read())
                {
                    lista.Add(new Categoria((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
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




    }
}
