using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda
{
    public partial class FormCreateUpdate : Page
    {
        private String Modo = "";
        protected String Titulo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Modo = (String)Application["Modo"];
            if (Modo == "EDIT"){
                Titulo = "Editar Contacto";
            }
            else if(Modo=="NEW")
            {
                Titulo = "Nuevo Contacto";
            }
            else
            {
                Titulo = "Consultar Contacto";
            }
        }

        protected void VolverAinicio(Object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}