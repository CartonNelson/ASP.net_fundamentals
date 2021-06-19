using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Contacto : AAgendaEntitys
    {
        public int? id_contacto { get; set; }
        public int id_genero { get; set; }
        public String direccion { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public String tel_fijo { get; set; }
        public String tel_cel { get; set; }
        public String e_mail { get; set; }
        public String skype { get; set; }
        public String d_genero { get; set; }
        public String d_pais { get; set; }
        public String d_con_int { get; set; }
        public String d_area { get; set; }
        public String d_activo { get; set; }

        //constructor para iniciar contactos con ID
        public Contacto(int P_ID, String P_ApellidoNombre, String P_Genero, String P_Pais)
        {
            //this.ID_contacto = P_ID;
            //this.ApellidoNombre = P_ApellidoNombre;
            //this.Genero = P_Genero;
            //this.Pais = P_Pais;
        }

        public Contacto(String P_ApellidoNombre, String P_Genero, String P_Pais)
        {
           
            //this.ApellidoNombre = P_ApellidoNombre;
            //this.Genero = P_Genero;
            //this.Pais = P_Pais;
        }
        public Contacto()
        {

        }
    }
}
