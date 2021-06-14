using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;

namespace ConectBD.DAL
{
    public class DataAccessLayer : IDisposable
     
    {
        public SqlConnection connection;

        public DataAccessLayer()
        {
            connection = new SqlConnection
            {
                ConnectionString = ConecDB.GetConnectionString()
            };
        }

        public SqlConnection AbrirConexion()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Se creo la conexión exitosamente");
                return connection;
            }
            catch (Exception e)
            {
                ExceptionPrinter.Print(e);
                return null;
            }
        }

        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }


    }
}
