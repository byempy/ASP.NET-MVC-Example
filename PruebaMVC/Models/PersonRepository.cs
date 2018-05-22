using ConsultaDB.Entities;
using ConsultaDB.Interfaces;
using ConsultaDB.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMVC.Models
{
    public class PersonRepository : IPersonBL
    {
        IDataHelper data;
        public PersonRepository() {
            data = new PersonEntityData();
        }

        public void AddPerson(Person person)
        {
            data.AddPerson(person);
        }

        public void DelPerson(int id)
        {
            data.DelPerson(id);
        }

        public void Dispose()
        {
            if(data != null)
                data.Dispose();
        }

        public List<Person> GetListaPersonas(Person persona)
        {
            return data.GetListaPersonas(persona);
        }

        public Person GetPersonaDetallada(int id)
        {
            return data.GetPersonaDetallada(id);
        }

        public void UpdatePerson(Person person)
        {
            data.UpdatePerson(person);
        }
    }
}