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
            try
            {
                Response.Write("<BR/>");
                //inicializo datos

                List<Contacto> ContactosList = new List<Contacto>((List<Contacto>)Application["ContactList"]);
                IAgendaBussines AgendaBss = new AgendaABM(ContactosList);
                Response.Write("Listado general");
                Response.Write("<BR/>");
                print(ContactosList);


                Response.Write("<BR/>");
                Response.Write("Obtengo el registro con Id=2 y lo imprimo en pantalla:");
                Response.Write("<BR/>");
                Contacto Contacto = AgendaBss.GetContactByID(2);
                Response.Write(string.Concat("Id: ", Contacto.ID_contacto.ToString(), ", Apellido y Nombre:", Contacto.ApellidoNombre, ", Genero:", Contacto.Genero, ", Pais:", Contacto.Pais));
                Response.Write("<BR/>");
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");

                Response.Write("Actualizo el Pais del contacto obtenido, lo recupero y lo imprimo en pantalla:");
                Response.Write("<BR/>");
                Contacto.Pais = "Alemania";
                AgendaBss.Update(Contacto);
                Contacto ContactoModif = AgendaBss.GetContactByID(2);
                Response.Write(string.Concat("Id: ", ContactoModif.ID_contacto.ToString(), ", Apellido y Nombre:", ContactoModif.ApellidoNombre, ", Genero:", ContactoModif.Genero, ", Pais:", ContactoModif.Pais));
                Response.Write("<BR/>");
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");

                Response.Write("Elimino el usuario anterior (2)");
                Response.Write("<BR/>");
                AgendaBss.Delete(ContactoModif.ID_contacto);
                Response.Write("Resultado post eliminacion");
                Response.Write("<BR/>");
                print(AgendaBss.GetAllContacts());
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");


                Response.Write("Inserto un nuevo registro y lo imprimo en pantalla:");
                Response.Write("<BR/>");
                Contacto Nuevo = AgendaBss.Insert(new Contacto("NUEVO CONTACTO", "F", "Jamaica"));
                Response.Write(string.Concat("Id: ", Nuevo.ID_contacto.ToString(), ", Apellido y Nombre:", Nuevo.ApellidoNombre, ", Genero:", Nuevo.Genero, ", Pais:", Nuevo.Pais));
                Response.Write("<BR/>");
                Response.Write("--------------------------------------");
                Response.Write("<BR/>");

                Response.Write("Imprimo en pantalla el listado de registros filtrados por nombre y apellido:");
                Response.Write("<BR/>");
                print(AgendaBss.GetListContactFilter(new Filtro() { ApellidoNombre = "Segura Emanuel" }));



            }
            catch (Exception ex)
            {
                Response.Write(string.Concat("ERROR", ex.Message, ex.StackTrace));
            }
            
        }
    }
}