using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.Entity;
namespace Agenda
{
    public partial class FormCreateUpdate : Page
    {
        //private String Modo = "";
        protected String Titulo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Modo = (String)Application["Modo"];
           
            inicializarForm();

            if (!IsPostBack)
            {
                AjustarSegunModo((String)Application["Modo"]);
            }
            //selGenero.Items.Add(new ListItem("1", "2")); // texto, value

            

        }
        private void AjustarSegunModo(String Modo)
        {
            if (Modo == "EDIT")
            {
                Titulo = "Editar Contacto";
                btnAccion.Text = "Grabar";
            }
            else if (Modo == "NEW")
            {
                Titulo = "Nuevo Contacto";
                btnAccion.Text = "Enviar";
                selArea.Attributes.Add("disabled", "true");
            }
            else
            {
                Titulo = "Consultar Contacto";
                btnAccion.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
                
                LlenarFormContacto();
                DeshabilitarCampos();
               


            }
        }

        protected void LlenarFormContacto()
        {
            Contacto contactData = (Contacto)Cache["Contacto"];
            inputNombre.Value = contactData.apellido_nombre;
            selGenero.Value = contactData.id_genero.ToString();
            selPais.Value = contactData.id_pais.ToString();
            inputLocal.Value = contactData.localidad == "&nbsp;" ? " " : contactData.localidad;
            selCinterno.Value = contactData.id_cont_int.ToString();
            inputOrg.Value = contactData.organizacion == "&nbsp;" ? " " : contactData.organizacion;
            selArea.Value = contactData.id_area.ToString();
            selActivo.Value = contactData.id_activo.ToString();
            Direccion.Value = contactData.direccion == "&nbsp;" ? " " : contactData.direccion; 
            TelFijo.Value = contactData.tel_fijo == "&nbsp;" ? " " : contactData.tel_fijo;
            TelCelular.Value = contactData.tel_cel == "&nbsp;" ? " " : contactData.tel_cel;
            inpEmail.Value = contactData.e_mail == "&nbsp;" ? " " : contactData.e_mail;
            Skype.Value = contactData.skype == "&nbsp;" ? " " : contactData.skype; 
             
        }
        protected void DeshabilitarCampos()
        {
            inputNombre.Attributes.Add("disabled", "true");
            selGenero.Attributes.Add("disabled", "true");
            selPais.Attributes.Add("disabled", "true");
            inputLocal.Attributes.Add("disabled", "true");
            selCinterno.Attributes.Add("disabled", "true");
            inputOrg.Attributes.Add("disabled", "true");
            selArea.Attributes.Add("disabled", "true");
            selActivo.Attributes.Add("disabled", "true");
            Direccion.Attributes.Add("disabled", "true");
            TelFijo.Attributes.Add("disabled", "true");
            TelCelular.Attributes.Add("disabled", "true");
            inpEmail.Attributes.Add("disabled", "true");
            Skype.Attributes.Add("disabled", "true");
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