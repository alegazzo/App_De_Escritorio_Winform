using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;



namespace Negocio
{
   public class MarcaNegocio
    {
        public List<Marca> listar()
        {

            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select Id, Descripcion from Marcas");
                datos.LeerConsulta();

                while (datos.Lector.Read())
                {
                    lista.Add(new Marca((int)datos.Lector["Id"], (string)datos.Lector["Descripcion"]));
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

        public void Agregar(Marca aux)
        {


            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into MARCAS(Descripcion) values ('" + aux.Nombre + "')");

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

    }
}
