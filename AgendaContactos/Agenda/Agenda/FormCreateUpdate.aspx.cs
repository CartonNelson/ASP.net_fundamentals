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
            
            if (!IsPostBack)
            {
                inicializarForm();
            }
            selGenero.Items.Add(new ListItem("1", "2")); // texto, value

            

        }

        protected void inicializarForm()
        {
            
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            Application["MsjError"] = "";
            //servicio area

            String[] Areas = (string[])Application["Areas"];
            for (int i = 0; i < Areas.Length; i++)
            {
                selArea.Items.Add(new ListItem(Areas[i], i.ToString())); // texto, value
            }
        }
        
        protected void Accion(Object sender, EventArgs e)
        {
            string a = "";
        }
        
        protected void ValidarEmail(object source, ServerValidateEventArgs Email)
        {
            if (Email.Value.IndexOf('@') == -1) {
                Application["MsjError"] = "El EMAIL ingresado es incorrecto";
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
            }
        }

        protected void VolverAinicio(Object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}