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
        public String msjVal = "";
        private void print(List<Contacto> ContactList)
        {
            foreach (Contacto c in ContactList)
            {
                Response.Write(string.Concat("Id: ", c.ID_contacto, ", Apellido y Nombre:", c.ApellidoNombre, ", Genero:", c.Genero, ", Pais:", c.Pais));
                Response.Write("<BR/>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try {

                if (!Page.IsPostBack)
                {
                    inicializarFiltro();
                }
                



                //string text = "SI";
                //var item = selCinterno.Items.FindByText(text);
                //if (item != null)
                //    item.Selected = true;

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
        
        protected void redirigir(Object sender, EventArgs e)
        {
            Response.Redirect("formCreateUpdate.aspx");
        }

        protected void inicializarFiltro()
        {
            DateTime currentDate = DateTime.Now;
            currentDate = currentDate.AddDays(-30);
            String newDate = currentDate.ToString("yyyy-MM-dd");
            inputFingDesde.Value = newDate;
             
            inputFingHasta.Value = DateTime.Now.ToString("yyyy-MM-dd");

            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
        }

        
        public void ValidarFechas(object source, ServerValidateEventArgs Direccion)
        {
            DateTime fDesde = Convert.ToDateTime(inputFingDesde.Value);
            DateTime fHasta = Convert.ToDateTime(inputFingHasta.Value);
            int result = DateTime.Compare(fDesde, fHasta);
            if (result > 0)
            {
                msjVal = "La fecha de ingreso desde debe ser anterior a la fecha de ingreso hasta";
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
            }
            Direccion.IsValid = result <= 0;// ? true : false;
        }

        public void ConInternoAction(Object sender, EventArgs e)
        {
            //String s = "HOLA";
            msjVal = "La fecha de ingreso desde debe ser anterior a la fecha de ingreso hasta";
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
        }
    }
}