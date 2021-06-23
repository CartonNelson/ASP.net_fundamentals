using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Agenda.Entity;
using Modelo;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayerDB;
using Agenda;
namespace Agenda.BBL
{
    public class AgendaABM : IDisposable
    {
        public SqlConnection connection;
        private List<Contacto> ListaContactos;
        public AgendaABM()
        {
           
        }
        //Creacion de contacto 
        public int? CrearContacto (Contacto cont)
        {
            int? regAfec;
            using (DataAccessLayer dal = new DataAccessLayer())
            {
                var connection = dal.AbrirConexion();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {


                    regAfec = dal.EjecutarCrearContacto(transaction, connection, cont);
                    transaction.Commit();

                    return regAfec;

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return null;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }
        //activar pausar 
        public int? ActivarPausarContacto(int id_contacto, int id_activo)
        {
            int? regAfec;
            using (DataAccessLayer dal = new DataAccessLayer())
            {
                var connection = dal.AbrirConexion();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {

                    regAfec = dal.ActivarPausarContacto(transaction, connection, id_contacto, id_activo);
                    transaction.Commit();

                    return regAfec;

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return null;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }    
        //Eliminar contacto
        public int? eliminarCont(int id_contacto)
        {
            int? regAfec;
            using (DataAccessLayer dal = new DataAccessLayer())
            {
                var connection = dal.AbrirConexion();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {

                    regAfec = dal.EjecutarEliminacion(transaction, connection, id_contacto);
                    transaction.Commit();

                    return regAfec;

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return null;
                }
                finally
                {
                    transaction.Dispose();
                }
            }
        }
        //Actualizacion de contacto 
        public int? ActualizarContacto(Contacto cont)
        {
          int? regAfec;
                using (DataAccessLayer dal = new DataAccessLayer())
                {
                var connection = dal.AbrirConexion();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                    {


                        regAfec = dal.EjecutarActualizacionContacto(transaction, connection, cont);
                        transaction.Commit();

                        return regAfec;
                    
                    }catch(Exception e)
                    {
                        transaction.Rollback();
                        return null;
                     }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
           
        }
        
        
        
        //Busqueda de contactos segun filtro
        public List<Contacto> EjecutarConsultaFiltro(Filtro filter)
        {

            try
            {
                using (DataAccessLayer dal = new DataAccessLayer())
                {
                    var connection = dal.AbrirConexion();
                    //DataSet ds = dal.EjecutarQueryConPaginado(connection, filter);
                    
                    DataSet ds = dal.ConsultarContactosFilter(connection, filter);
                    return SetDsContactos(ds);
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.EjecutarConsultaFiltro", e);
            }
            
        }

        //Setear DS con contactos
        private List<Contacto> SetDsContactos(DataSet ds)
        {
            try
            {
                List<Contacto> list = new List<Contacto>();

                if (DataSetHelper.HasRecords(ds))
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        list.Add(MapContacto(row));
                    }
                    return list;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.SetDsContactos", e);
            }

        }

        private static Contacto MapContacto(DataRow row)
        {
            try
            {
                //obtengo cuil por servicio
                ServiceCUIL.ServiceClient CUILsrv = new ServiceCUIL.ServiceClient();
                string paramApeNomb = Convert.ToString(row["apellido_nombre"]);
                int paramIdGenero = Convert.ToInt32(row["id_genero"]);
                
                String obtCUIL = CUILsrv.getCuil(paramApeNomb, paramIdGenero);

                return new Contacto
                {
                    id_contacto = Convert.ToInt32(row["id_contacto"]),
                    apellido_nombre = Convert.ToString(row["apellido_nombre"]),
                    d_genero = Convert.ToString(row["d_genero"]),
                    id_genero = Convert.ToInt32(row["id_genero"]),
                    d_pais = Convert.ToString(row["d_pais"]),
                    id_pais = Convert.ToInt32(row["id_pais"]),
                    localidad = Convert.ToString(row["localidad"]),
                    d_con_int = Convert.ToString(row["d_con_int"]),
                    id_cont_int = Convert.ToInt32(row["id_cont_int"]),
                    organizacion = Convert.ToString(row["organizacion"]),
                    d_area = Convert.ToString(row["d_area"]),
                    id_area = Convert.ToInt32(row["id_area"]),
                    d_activo = Convert.ToString(row["d_activo"]),
                    id_activo = Convert.ToInt32(row["id_activo"]),

                    direccion = Convert.ToString(row["direccion"]),
                    tel_fijo = Convert.ToString(row["tel_fijo"]),
                    tel_cel = Convert.ToString(row["tel_cel"]),
                    e_mail = Convert.ToString(row["e_mail"]),
                    skype = Convert.ToString(row["skype"]),
                    fecha_ingreso = Convert.ToDateTime(row["fecha_ingreso"]),

                    //id_area = Convert.ToInt32(row["EmpresaId"]) ? null : (int?)Convert.ToInt32(row["EmpresaId"])
                    CUIL = obtCUIL

                };
            }
            catch (Exception e)
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.MapContacto", e);
            }

        }


        //cerrar conexion
        public void Dispose()
        {
           
        }
        ///////////////////////////////////////////////////////////////////////////////////////////

        

    }
}
