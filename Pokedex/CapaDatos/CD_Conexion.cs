using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=(local);DataBase=Proyect_Pokemon;Integrated Security=true");
        //private SqlConnection Conexion = new SqlConnection("Server=tcp:(local);DataBase=Proyect_Pokemon;Integrated Security=true");


        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        } 

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}


/*using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conexion : IDisposable
    {
        private SqlConnection Conexion;

        public CD_Conexion()
        {
            Conexion = new SqlConnection("Server=(local);DataBase=Proyect_Pokemon;Integrated Security=true");
        }

        public SqlConnection AbrirConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Closed)
                    Conexion.Open();
                return Conexion;
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (Conexion.State == ConnectionState.Open)
                    Conexion.Close();
            }
            catch (Exception ex)
            {
                // Manejar la excepción o propagarla
                throw ex;
            }
        }

        public void Dispose()
        {
            CerrarConexion();
            Conexion.Dispose();
        }
    }
}*/
