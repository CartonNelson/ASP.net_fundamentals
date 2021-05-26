using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Contacto : AAgendaEntitys
    {
        public int ID_contacto { get; set; }
        public String Genero { get; set; }
        public String Direccion { get; set; }
        public String Telefono_fijo { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }
        public String Skype { get; set; }

        //constructor para iniciar contactos con ID
        public Contacto(int P_ID, String P_ApellidoNombre, String P_Genero, String P_Pais)
        {
            this.ID_contacto = P_ID;
            this.ApellidoNombre = P_ApellidoNombre;
            this.Genero = P_Genero;
            this.Pais = P_Pais;
        }

        public Contacto(String P_ApellidoNombre, String P_Genero, String P_Pais)
        {
           
            this.ApellidoNombre = P_ApellidoNombre;
            this.Genero = P_Genero;
            this.Pais = P_Pais;
        }
    }
}
