using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Modelo;
using Agenda.Entity;

namespace DataAccessLayerDB
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

        public DataSet EjecutarQueryConPaginado(SqlConnection connection, Filtro filter)
        {
            try
            { 
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = ConfigSelectCommand(connection, filter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    //if (DataSetHelper.HasRecords(ds))
                    //{

                    //    String a = "";
                    //}

                    return ds;
                }
            }
            catch (Exception e)
            {
                ExceptionPrinter.Print(e);
                return null;
            }
        }

        private SqlCommand ConfigSelectCommand(SqlConnection connection, Filtro filter)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = "PR_OBTENER_CONTACTOS",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                new SqlParameter() { ParameterName = "@apellidoNombre", Value = filter.apellido_nombre, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@idPais", Value = filter.id_pais, SqlDbType = SqlDbType.Int },
                //new SqlParameter() { ParameterName = "@idPais", Value = null ?? DBNull.Value, SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@localidad", Value = filter.localidad, SqlDbType = SqlDbType.VarChar},
                new SqlParameter() { ParameterName = "@fechaIngDesde", Value = filter.F_ingresoD, SqlDbType = SqlDbType.DateTime},
                new SqlParameter() { ParameterName = "@fechaIngHasta", Value = filter.F_ingresoH, SqlDbType = SqlDbType.DateTime},
                new SqlParameter() { ParameterName = "@idContInterno", Value = filter.id_cont_int, SqlDbType = SqlDbType.Int},
                new SqlParameter() { ParameterName = "@organizacion", Value = filter.organizacion, SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@idArea", Value = filter.id_area, SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@idActicvo", Value = filter.id_activo, SqlDbType = SqlDbType.Int },

                    //Parametros del Paginado
                    //new SqlParameter(){ ParameterName = "@PageSize", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties?.PageSize },
                    //new SqlParameter(){ ParameterName = "@PageIndex", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties?.PageIndex },
                    //new SqlParameter(){ ParameterName = "@SortBy", SqlDbType = SqlDbType.VarChar, Value = filter.PaginateProperties?.SortBy },
                    //new SqlParameter(){ ParameterName = "@Order", SqlDbType = SqlDbType.Int, Value = filter.PaginateProperties?.Order }
                });
                return cmd;
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
