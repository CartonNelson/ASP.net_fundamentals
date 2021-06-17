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
        //Creacion de contacto 
        public int EjecutarCrearContacto(SqlTransaction transaction, SqlConnection connection, Contacto cont)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PR_INSERTAR_CONTACTO"
            };

            cmd = ConfigParametersUpdateInsert(cmd, cont); //agrego demas parametros


            int registrosAfectados = cmd.ExecuteNonQuery();

            return registrosAfectados;
        }
        //Activar pausar
        
        public int ActivarPausarContacto(SqlTransaction transaction, SqlConnection connection, int id_contacto, int id_act)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PR_ACTIVAR_PAUSAR_CONTACTO"
            };

            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id_contacto", Value = id_contacto, SqlDbType = SqlDbType.Int });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id_activo", Value = id_act, SqlDbType = SqlDbType.Int });

            int registrosAfectados = cmd.ExecuteNonQuery();

            return registrosAfectados;
        }



        //Eliminar contacto
        public int EjecutarEliminacion (SqlTransaction transaction, SqlConnection connection, int id_contacto)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PR_ELIMINAR_CONTACTO"
            };

            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id_contacto", Value = id_contacto, SqlDbType = SqlDbType.Int });

            int registrosAfectados = cmd.ExecuteNonQuery();

            return registrosAfectados;
        }



        //Actualizacion de contacto/////////////////////////////////////////////////////////////////////
        public int EjecutarActualizacionContacto(SqlTransaction transaction, SqlConnection connection, Contacto cont)
        {
            SqlCommand cmd = new SqlCommand 
             {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.StoredProcedure,
                CommandText = "PR_ACTUALIZAR_CONTACTO"
            };
            
            
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@id_contacto", Value = cont.id_contacto, SqlDbType = SqlDbType.Int }); //para update agrego id de contacto
            cmd = ConfigParametersUpdateInsert(cmd, cont); //agrego demas parametros


            int registrosAfectados = cmd.ExecuteNonQuery();

            return registrosAfectados;
        }

        private SqlCommand ConfigParametersUpdateInsert(SqlCommand cmd, Contacto cont)
        {
            try
            {
                cmd.Parameters.AddRange(new SqlParameter[]
            {    
                new SqlParameter() { ParameterName = "@apellidoNombre", Value = cont.apellido_nombre,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@id_genero",      Value = cont.id_genero,    SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@idPais",         Value = cont.id_pais,    SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@localidad",      Value = cont.localidad,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@idContInterno",  Value = cont.id_cont_int,    SqlDbType = SqlDbType.Int},
                new SqlParameter() { ParameterName = "@organizacion",   Value = cont.organizacion,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@idArea",         Value = cont.id_area,    SqlDbType = SqlDbType.Int},
                new SqlParameter() { ParameterName = "@idActicvo",      Value = cont.id_activo,    SqlDbType = SqlDbType.Int },
                new SqlParameter() { ParameterName = "@direccion",      Value = cont.direccion,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@tel_fijo",       Value = cont.tel_fijo,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@tel_cel",        Value = cont.tel_cel,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@email",          Value = cont.e_mail,    SqlDbType = SqlDbType.VarChar },
                new SqlParameter() { ParameterName = "@skype",          Value = cont.skype,    SqlDbType = SqlDbType.VarChar }
            });

                return cmd;
            }
            catch (Exception e)
            {
                ExceptionPrinter.Print(e);
                return null;
            }

        }

        //Consulta por filtro///////////////////////////////////////////////////////////
        public DataSet ConsultarContactosFilter(SqlConnection connection, Filtro filter)
        {
            try
            { 
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.SelectCommand = ConfigSqlCommandSearch(connection, filter);

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

        private SqlCommand ConfigSqlCommandSearch(SqlConnection connection, Filtro filter)
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
