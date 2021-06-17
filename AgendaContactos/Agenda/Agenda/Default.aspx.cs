using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.BBL;
using Agenda.Entity;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Agenda
{
    public partial class _Default : Page
    {
        //public String msjVal = "";
        public const String CREACION = "NEW";
        public const String MODIFICACION = "EDIT";
        public const String CONSULTA = "INFO";

        protected const String SUCCESS = "alert alert-success";
        protected const String DANGER = "alert alert-danger";

        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                
                //cargarFiltroBusqueda();

                if (!Page.IsPostBack)
                {

                    inicializarFiltro();
                    Cache["FiltroExiste"] = false;

                }
                
                   
                 



            }
            catch (Exception ex)
            {
                Response.Write(string.Concat("ERROR", ex.Message, ex.StackTrace));
            }
            
        }

       

        protected void Consultar(Object sender, EventArgs e)
        {
            
            
            Page.Validate();
            if (Page.IsValid)
            {
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";

                EjecutarConsulta();
                if (selCinterno.Value == "2")
                {
                    selArea.Attributes.Remove("disabled");
                }
            }
            else
            {
                GridContactos.DataSource = null;
                GridContactos.DataBind();
            }
        }
        
        public void EjecutarConsulta()
        {

            using (AgendaABM business = new AgendaABM())
            {
                
 
                var filter = new Filtro
                {
                    apellido_nombre = inputNombre.Value,
                    id_pais         = int.Parse(selPais.Value), 
                    localidad       = inputLocal.Value,
                    id_cont_int     = int.Parse(selCinterno.Value),
                    organizacion    = inputOrg.Value,
                    id_area         = int.Parse(selArea.Value),
                    id_activo       = int.Parse(selActivo.Value),
                    F_ingresoD      = Convert.ToDateTime(inputFingDesde.Value),
                    F_ingresoH      = Convert.ToDateTime(inputFingHasta.Value)
                };
                Cache["FiltroBusqueda"] = filter;
                Cache["FiltroExiste"] = true;

                List<Contacto> contactos =  business.EjecutarConsultaFiltro(filter);
                GridContactos.DataSource = contactos;
                GridContactos.DataBind();

                foreach (GridViewRow row in GridContactos.Rows)// Seteo Imagen Play/pause
                {
                    if (row.Cells[14].Text == "SI") {
                        ImageButton columnaImagen = (ImageButton)row.FindControl("BtnActivar");
                        columnaImagen.ImageUrl = "/Images/anular.png";
                    }
                    row.Cells[12].Text = row.Cells[12].Text.Substring(0, 10); //parseo fecha
                }
            }
        }
        protected void gdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridContactos.PageIndex = e.NewPageIndex;
            
            this.EjecutarConsulta();
        }
        protected void AltaContacto(Object sender, EventArgs e)
        {
            Application["Modo"] = CREACION;
            Response.Redirect("formCreateUpdate.aspx", false);
        }

        public void inicializarFiltro()
        {
            DateTime currentDate = DateTime.Now;
            currentDate = currentDate.AddDays(-30);
            String newDate = currentDate.ToString("yyyy-MM-dd");
            this.inputFingDesde.Value = newDate;

            this.inputFingHasta.Value = DateTime.Now.ToString("yyyy-MM-dd");

            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            Application["MsjError"] = "";

            //servicio area

            String[] Areas = (string[])Application["Areas"];
            for (int i = 0; i < Areas.Length; i++)
            {
                selArea.Items.Add(new ListItem(Areas[i], i.ToString())); // texto, value
            }

            selArea.Attributes.Add("disabled", "disabled");
        }

        
        public void ValidarFechas(object source, ServerValidateEventArgs Fechas)
        {
            DateTime fDesde = Convert.ToDateTime(inputFingDesde.Value);
            DateTime fHasta = Convert.ToDateTime(inputFingHasta.Value);
            int result = DateTime.Compare(fDesde, fHasta);
            if (result > 0)
            {
                //Application["MsjError"] = "La fecha de ingreso desde debe ser anterior a la fecha de ingreso hasta";
                //ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
                MostrarError("La fecha de ingreso desde debe ser anterior a la fecha de ingreso hasta", DANGER);
            }
            Fechas.IsValid = result <= 0;// ? true : false;
        }

        protected void ConsultarContacto(Object sender, EventArgs e)
        {

            try
            {

                ImageButton boton = (ImageButton)sender;
                GridViewRow row = (GridViewRow)boton.DataItemContainer;

                setContactoElegido(row);               

                Application["Modo"] = CONSULTA;
                Response.Redirect("formCreateUpdate.aspx", false);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR en ConsultarContacto", ex);
            }
        }

        protected void EditarContacto(Object sender, EventArgs e)
        {
            try
            {

                ImageButton boton = (ImageButton)sender;
                GridViewRow row = (GridViewRow)boton.DataItemContainer;

                setContactoElegido(row);

                Application["Modo"] = MODIFICACION;
                Response.Redirect("formCreateUpdate.aspx", false);
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR en EditarContacto", ex);
            }
        }

   

        


        //Guardo el contacto con el que voy a trabajar y cargo datos de la fila elegida
        protected void setContactoElegido(GridViewRow row)
        {
            Contacto ContDetalle = new Contacto
            {

                id_contacto = int.Parse(row.Cells[0].Text),  
                apellido_nombre = row.Cells[1].Text,
                id_genero = Convert.ToInt32(row.Cells[2].Text),
                id_pais = Convert.ToInt32(row.Cells[4].Text),
                localidad = row.Cells[6].Text,
                id_cont_int = Convert.ToInt32(row.Cells[7].Text),
                organizacion = row.Cells[9].Text,
                id_area = Convert.ToInt32(row.Cells[10].Text),
                id_activo = Convert.ToInt32(row.Cells[13].Text),
                direccion = row.Cells[15].Text,
                tel_fijo = row.Cells[16].Text,
                tel_cel = row.Cells[17].Text,
                e_mail = row.Cells[18].Text,
                skype = row.Cells[19].Text

            };
            Cache["ContactoElegido"] = ContDetalle;
        }

        //Eliminar contacto
        protected void eliminarContacto(Object sender, EventArgs e)
        {
            try
            {

                ImageButton boton = (ImageButton)sender;
                GridViewRow row = (GridViewRow)boton.DataItemContainer;

                //setContactoElegido(row);
                var id_contacto = int.Parse(row.Cells[0].Text);

                using (AgendaABM business = new AgendaABM())
                {
                    var regAfectados = business.eliminarCont(id_contacto);
                    if (regAfectados == null || regAfectados < 1)
                    {
                        MostrarError("No se pudo eliminar el Contacto", DANGER);
                    }
                    else
                    {
                        EjecutarConsulta();
                        MostrarError("Eliminacion coorrecta", SUCCESS);
                        

                    }
                }


                }
            catch (Exception ex)
            {
                throw new Exception("ERROR en ConsultarContacto", ex);
            }
        }

        //Activar contacto
        //protected void activarContacto(Object sender, EventArgs e)
        //{
        //    try
        //    {

        //        ImageButton boton = (ImageButton)sender;
        //        GridViewRow row = (GridViewRow)boton.DataItemContainer;

        //        //setContactoElegido(row);
        //        var id_contacto = int.Parse(row.Cells[0].Text);
        //        var id_activo = int.Parse(row.Cells[13].Text);
        //        var msj = id_activo == 2 ? "Inactivar" : 
        //        using (AgendaABM business = new AgendaABM())
        //        {
        //            var regAfectados = business.ActivarPausarContacto(id_contacto);
        //            if (regAfectados == null || regAfectados < 1)
        //            {
        //                MostrarError("No se pudo actualizar el Contacto", DANGER);
        //            }
        //            else
        //            {
        //                MostrarError("Eliminacion coorrecta", SUCCESS);

        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("ERROR en ConsultarContacto", ex);
        //    }

        //}

        protected void cargarFiltroBusqueda()
        {
            bool existeFiltro = (bool)Cache["FiltroExiste"];
            Filtro filter = new Filtro();
            Cache["FiltroBusqueda"] = filter;
            if (existeFiltro)
            {
                inputNombre.Value = filter.apellido_nombre;
                selPais.Items.FindByValue(filter.id_pais.ToString()).Selected = true;
                inputLocal.Value = filter.localidad;
                selCinterno.Items.FindByValue(filter.id_cont_int.ToString()).Selected = true;
                inputOrg.Value = filter.organizacion;
                selArea.Items.FindByValue(filter.id_area.ToString()).Selected = true;
                selActivo.Items.FindByValue(filter.id_activo.ToString()).Selected = true;
            }
        }

        protected void MostrarError(string msj, string classError)
        {
            Application["MsjError"] = msj;
            ErrorContainer.Attributes.Add("class", classError);
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
        }

        protected void GridEventClick(Object sender, GridViewCommandEventArgs e)
        {

        }

        
    }
}