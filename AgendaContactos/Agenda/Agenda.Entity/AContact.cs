using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public abstract class AAgendaEntitys
    {
        public String apellido_nombre { get; set; }
        public int? id_pais { get; set; }
        public String localidad { get; set; }
        public int? id_cont_int { get; set; }
        public String organizacion { get; set; }
        public int? id_area { get; set; }
        public int? id_activo { get; set; }

    }
}
