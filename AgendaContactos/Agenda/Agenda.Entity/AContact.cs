using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public abstract class AAgendaEntitys
    {
        public String ApellidoNombre { get; set; }
        public String Pais { get; set; }
        public String Localidad { get; set; }
        public DateTime F_ingresoD { get; set; }
        public DateTime F_ingresoH { get; set; }
        public String Contacto_int { get; set; }
        public String Organizacion { get; set; }
        public String Area { get; set; }
        public String Activo { get; set; }

    }
}
