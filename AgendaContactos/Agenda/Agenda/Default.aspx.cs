using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.BBL;
using Agenda.Entity;

namespace Agenda
{
    public partial class _Default : Page
    {
        //public String msjVal = "";
        public const String CREACION = "NEW";
        public const String MODIFICACION = "EDIT";
        public const String CONSULTA = "INFO";

        //private void print(List<Contacto> ContactList)
        //{
        //    foreach (Contacto c in ContactList)
        //    {
        //        Response.Write(string.Concat("Id: ", c.ID_contacto, ", Apellido y Nombre:", c.ApellidoNombre, ", Genero:", c.Genero, ", Pais:", c.Pais));
        //        Response.Write("<BR/>");
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                
                
                 if (!Page.IsPostBack)
                {
                    inicializarFiltro();


                }



            }
            catch (Exception ex)
            {
                Response.Write(string.Concat("ERROR", ex.Message, ex.StackTrace));
            }
            
        }

        protected void GridEventClick(Object sender, GridViewCommandEventArgs e)
        {

        }
        protected void Consultar(Object sender, EventArgs e)
        {
            

            Page.Validate();
            if (Page.IsValid)
            {
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
                List<Contacto> lista = (List<Contacto>)Application["ContactList"];

                GridContactos.DataSource = lista;
                GridContactos.DataBind();

            }
            else
            {
                GridContactos.DataSource = null;
                GridContactos.DataBind();
            }
        }
        
        protected void AltaContacto(Object sender, EventArgs e)
        {
            Application["Modo"] = CREACION;
            Response.Redirect("formCreateUpdate.aspx");
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
        }

        
        public void ValidarFechas(object source, ServerValidateEventArgs Fechas)
        {
            DateTime fDesde = Convert.ToDateTime(inputFingDesde.Value);
            DateTime fHasta = Convert.ToDateTime(inputFingHasta.Value);
            int result = DateTime.Compare(fDesde, fHasta);
            if (result > 0)
            {
                Application["MsjError"] = "La fecha de ingreso desde debe ser anterior a la fecha de ingreso hasta";
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
            }
            Fechas.IsValid = result <= 0;// ? true : false;
        }

        

    }
}