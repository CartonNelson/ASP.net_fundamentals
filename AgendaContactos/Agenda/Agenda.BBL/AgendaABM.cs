using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Agenda.Entity;

namespace Agenda.BBL
{
    public class AgendaABM : IAgendaBussines
    {
        private List<Contacto> ListaContactos;
        public AgendaABM(List<Contacto> P_ListaContactos)
        {
            this.ListaContactos = P_ListaContactos;
        }
        public void Delete(int P_ID)
        {

            try
            {
                
                  Contacto ContDel = this.ListaContactos.Find(c => c.ID_contacto.Equals(P_ID));
                  this.ListaContactos.Remove(ContDel);
              
                
            }
            catch
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.Delete");
            }
           
            
        }

        //borrado logico
        public void DeleteL(int P_cont)
        {
            throw new Exception("error forzado");
        }
        public Contacto GetContactByID(int P_ID)
        {
            try
            {
                
                return this.ListaContactos.First(p => p.ID_contacto.Equals(P_ID));
                
            }
            catch
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.GetContactByID");
            }
        }
        public List<Contacto> GetAllContacts()
        {

            try
            {

                    return this.ListaContactos.OrderBy(p => p.ID_contacto).ToList();
              
            }
            catch
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.GetAllContacts");
            }

        }

        //Por el momento realiozo la busqueda para Apellido y nombre
        public List<Contacto> GetListContactFilter(Filtro P_Filtro)
        {

            try
            {
                if (!string.IsNullOrEmpty(P_Filtro.ApellidoNombre))
                {
                    return this.ListaContactos.FindAll(p => p.ApellidoNombre.Contains(P_Filtro.ApellidoNombre)).OrderBy(p => p.ID_contacto).ToList();
                }
                else
                {
                    return this.ListaContactos.OrderBy(p => p.ID_contacto).ToList();
                }
            }
            catch
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.GetListContact");
            }
            
        }

        public Contacto Insert(Contacto P_cont)
        {
            try
            {
                P_cont.ID_contacto = (ListaContactos.Max(p => p.ID_contacto) + 1);
                this.ListaContactos.Add(P_cont);

                return P_cont;
            }
            catch
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.Insert");
            }
        }

        public void Update(Contacto P_cont)
        {
            try
            {
                this.ListaContactos.Remove(P_cont);
                this.ListaContactos.Add(P_cont);
            }
            catch
            {
                throw new Exception("ERROR GENERAL EN AgendaABM.Update");
            }
           
        }

    }
}
