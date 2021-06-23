using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.Entity;
using Agenda.BBL;
namespace Agenda
{
    public partial class FormCreateUpdate : Page
    {
        //private String Modo = "";
        protected String Titulo = "";
        //protected int? var_id_cont;
        protected const String SUCCESS = "alert alert-success";
        protected const String DANGER = "alert alert-danger";

        public const String CREACION = "NEW";
        public const String MODIFICACION = "EDIT";
        public const String CONSULTA = "INFO";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Modo = (String)Application["Modo"];
           
            

            if (!IsPostBack)
            {
                inicializarForm();
                AjustarSegunModo((String)Application["Modo"]);
                

            }           

        }
        private void AjustarSegunModo(String Modo)
        {
            if (Modo == MODIFICACION)
            {
                Titulo = "Editar Contacto";
                btnAccion.Text = "Guardar";
                LlenarFormContacto();
                setDisabled();

                GetCUIL(btnCUIL, new EventArgs());

            }
            else if (Modo == CREACION)
            {
                Titulo = "Nuevo Contacto";
                btnAccion.Text = "Insertar";
                selArea.Attributes.Add("disabled", "true");
            }
            else
            {
                Titulo = "Consultar Contacto";
                

                LlenarFormContacto();
                DeshabilitarCampos();

                GetCUIL(btnCUIL, new EventArgs());


            }
        }

        protected void LlenarFormContacto()
        {
            Contacto contactData = (Contacto)Cache["ContactoElegido"];
            //var_id_cont = contactData.id_contacto;
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

            limpiarError();
            selArea.Items.Clear();

            String[] Areas = (string[])Application["Areas"];
            selArea.Items.Add(new ListItem("Ninguna", "10")); //opcion vacio
            for (int i = 0; i < Areas.Length; i++){
                 selArea.Items.Add(new ListItem(Areas[i], i.ToString()));  
            }



        }
        

        //obtener cuil con servicio ALTA
        protected void GetCUIL(Object sender, EventArgs e)
        {
            string apellidoNombre = inputNombre.Value;

            if (!String.IsNullOrEmpty(apellidoNombre))
            {
                
                int id_genero = int.Parse(selGenero.Value);
                ServiceCUIL.ServiceClient CUILsrv = new ServiceCUIL.ServiceClient();

                CUIL.Value = CUILsrv.getCuil(apellidoNombre, id_genero);
            }
            else
            {
                CUIL.Value = "";
            }
           
        }


            //Insertar-Actualizar contacto
            protected void Accion(Object sender, EventArgs e)
        {
            limpiarError();

            Page.Validate();
            if (Page.IsValid)
            {
                Contacto ContactoEnvio = new Contacto();
               

                using (AgendaABM business = new AgendaABM())
                {
                    if (btnAccion.Text == "Guardar")
                    { //modo edicion
                        ContactoEnvio = CrearContactoActualiz();
                        var regAfectados = business.ActualizarContacto(ContactoEnvio);
                        if (regAfectados == null || regAfectados < 1)
                        {
                            MostrarError("No se actualizo ningun registro", DANGER);
                        }else
                        {             
                            MostrarError("Actualizacion correcta", SUCCESS);
                        }
                    }
                    else //modo creacion
                    {
                        ContactoEnvio = CrearContactoAlta();
                        var regAfectados = business.CrearContacto(ContactoEnvio);
                        if (regAfectados == null || regAfectados < 1)
                        {
                            MostrarError("No pudo crear el contacto", DANGER);
                        }
                        else
                        {
                            MostrarError("Contacto creado correctamente", SUCCESS);
                        }
                    }
                }
            }
            setDisabled();

        }

        protected void setDisabled()
        {
            if (selCinterno.Value == "2")
            {
                selArea.Attributes.Remove("disabled");
                inputOrg.Attributes.Add("disabled", "true");
            }
            else
            {
                inputOrg.Attributes.Remove("disabled");
                selArea.Attributes.Add("disabled", "true");
            }
        }

        protected void MostrarError(string msj, string classError)
        {
            Application["MsjError"] = msj;
            ErrorContainer.Attributes.Add("class", classError);
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "visible";
        }

        protected void limpiarError()
        {
            ErrorContainer.Attributes.CssStyle[HtmlTextWriterStyle.Visibility] = "hidden";
            Application["MsjError"] = "";
        }


        protected Contacto CrearContactoActualiz()
        {
            Contacto contAux = new Contacto();
            contAux = (Contacto)Cache["ContactoElegido"];

            Contacto ContactoSet = new Contacto
            {
                id_contacto = contAux.id_contacto,
                apellido_nombre = inputNombre.Value,
                id_genero = int.Parse(selGenero.Value),
                id_pais = int.Parse(selPais.Value),
                localidad = inputLocal.Value,
                id_cont_int = int.Parse(selCinterno.Value),
                organizacion = inputOrg.Value,
                id_area = int.Parse(selArea.Value),
                id_activo = int.Parse(selActivo.Value),
                direccion = Direccion.Value,
                tel_fijo = TelFijo.Value,
                tel_cel = TelCelular.Value,
                e_mail = inpEmail.Value,
                skype = Skype.Value

            };

            return ContactoSet;

        }

        //insertar datos del form en el usuario a crear
        protected Contacto CrearContactoAlta()
        {
            

            Contacto ContactoSet = new Contacto
            {
                //id_contacto = contAux.id_contacto == null ? 0 : contAux.id_contacto,
                apellido_nombre = inputNombre.Value,
                id_genero = int.Parse(selGenero.Value),
                id_pais = int.Parse(selPais.Value),
                localidad = inputLocal.Value,
                id_cont_int = int.Parse(selCinterno.Value),
                organizacion = inputOrg.Value,
                id_area = int.Parse(selArea.Value),
                id_activo = int.Parse(selActivo.Value),
                direccion = Direccion.Value,
                tel_fijo = TelFijo.Value,
                tel_cel = TelCelular.Value,
                e_mail = inpEmail.Value,
                skype = Skype.Value

            };

            return ContactoSet;
        }

        protected void ValidarEmail(object source, ServerValidateEventArgs Email)
        {
            if (inpEmail.Value.IndexOf('@') == -1) {
                
                MostrarError("El EMAIL ingresado es incorrecto", DANGER);
                Email.IsValid = false;
            }
            else
            {
                //if(inpEmail.Value.Length == 0)
                //{
                //    MostrarError("Falta completar el campo EMAIL", DANGER);
                //    Email.IsValid = false;
                //}
                //else
                //{
                    Email.IsValid = true;
                //}
               
            }

        }


        public void ValidarComuContacto(object source, ServerValidateEventArgs inputs)
        {
            Boolean result = true;

            if (TelCelular.Value.Trim(' ').Length == 0 && TelFijo.Value.Trim(' ').Length == 0 && Skype.Value.Trim(' ').Length == 0)
            {
                MostrarError("Al menos un campo de los siguientes debe estar completo: TELEFONO FIJO/CELULAR/SKYPE", DANGER);
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