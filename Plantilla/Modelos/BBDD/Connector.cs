using System;
using System.Data.SqlClient;

namespace Plantilla.Modelos.BBDD
{
    public class Connector
    {
        protected SqlConnection conexion;
        protected SqlCommand comando;
        protected SqlDataReader registros;
        private String cadenaConexion;

        public Connector()
        {
            cadenaConexion = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\data\\bbdd.mdf; Integrated Security = True; Connect Timeout = 30";
            conexion = new SqlConnection(cadenaConexion);
        }

        public Boolean Abrir()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public Boolean Cerrar()
        {
            try
            {
                conexion.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}