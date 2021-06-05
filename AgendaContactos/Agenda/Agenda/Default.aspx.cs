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
            List<Contacto> lista = (List<Contacto>)Application["ContactList"];
            
            GridContactos.DataSource = lista;
            GridContactos.DataBind();
        }
        
        protected void redirigir(Object sender, EventArgs e)
        {
            Response.Redirect("formCreateUpdate.aspx");
        }

    }
}