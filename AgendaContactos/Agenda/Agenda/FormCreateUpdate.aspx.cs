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
                LlenarFormContacto();

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
                
                
                LlenarFormContacto();
                DeshabilitarCampos();
               


            }
        }

        protected void LlenarFormContacto()
        {
            Contacto contactData = (Contacto)Cache["ContactoElegido"];
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

        //En caso de consulta deshabilito los campos
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

            //boton de accion
            btnAccion.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
        }

        //inicializo msj de error y cargo option area desde el servicio
        protected void inicializarForm()
        {
            
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            Application["MsjError"] = "";


            selArea.Items.Clear();
            String[] Areas = (string[])Application["Areas"];
           for (int i = 0; i < Areas.Length; i++)
                {
                     selArea.Items.Add(new ListItem(Areas[i], i.ToString()));
                
            }



        }

        protected void Accion(Object sender, EventArgs e)
        {
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            Application["MsjError"] = "";

            Page.Validate();
            if (Page.IsValid)
            {

                string a = "HOLA";
            }
        
        
        }
        protected void ValidarEmail(object source, ServerValidateEventArgs Email)
        {
            if (inpEmail.Value.IndexOf('@') == -1) {
                Application["MsjError"] = "El EMAIL ingresado es incorrecto";
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
                Email.IsValid = false;
            }
            else
            {
                if(inpEmail.Value.Length == 0)
                {
                    Application["MsjError"] = "Falta completar el campo EMAIL";
                    ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
                    Email.IsValid = false;
                }
                else
                {
                    Email.IsValid = true;
                }
               
            }

        }

        protected void ValidarNombre(object source, ServerValidateEventArgs NombreApellido)
        {
            if (inputNombre.Value.Length == 0)
            {
                Application["MsjError"] = "Falta completar el campo Apellido y Nombre";
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
                NombreApellido.IsValid = false;
            }
            else
            {
                NombreApellido.IsValid = true;
            }

        }

        public void ValidarComuContacto(object source, ServerValidateEventArgs inputs)
        {
            Boolean result = true;

            if (TelCelular.Value.Trim(' ').Length == 0 && TelFijo.Value.Trim(' ').Length == 0 && Skype.Value.Trim(' ').Length == 0)
            {
                Application["MsjError"] = "Al menos un campo de los siguientes debe estar completo: TELEFONO FIJO/CELULAR/SKYPE";
                ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
                result = false;
            }
            inputs.IsValid = result;
        }

        protected void VolverAinicio(Object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }



        
    }
}