using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;

        private SqlCommand comando;

        private SqlDataReader lector;

        public AccesoDatos()
        {
            conexion = new SqlConnection("data source=(local)\\SQLEXPRESS; initial catalog= CATALOGO_DB; integrated security=SSPI");
            comando = new SqlCommand();
        }

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;

        }

        public void LeerConsulta()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
            

        }

        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
           
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }




    }
}
