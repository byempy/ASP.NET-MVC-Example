namespace ConsultaDB.SQLServer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ConsultaDB.Entities;
    using ConsultaDB.Interfaces;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class PersonEntityData : DbContext, IDataHelper
    {
        public PersonEntityData()
            : base("name=PersonEntityData")
        {
            Persons = Set<Person>();
        }

        private DbSet<Person> Persons { get; set; }

        public void AddPerson(Person person)
        {
            Persons.Add(person);
            SaveChanges();
        }

        public void DelPerson(int id)
        {
            var person = Persons.Single(p => p.Id == id);
            Persons.Remove(person);
            SaveChanges();
        }

        public List<Person> GetListaPersonas(Person persona)
        {
            return Persons.Where(p => (persona.FirstName.Equals("") || persona.FirstName.ToUpper().Equals(p.FirstName.ToUpper()))
            && (persona.LastName.Equals("") || persona.LastName.ToUpper().Equals(p.LastName.ToUpper()))).ToList();

        }

        public Person GetPersonaDetallada(int id)
        {
            return Persons.Single(p => id == p.Id);
        }

        public void UpdatePerson(Person person)
        {
            var persona = Persons.Single(p => p.Id == person.Id);
            Entry(persona).CurrentValues.SetValues(person);
            
            SaveChanges();
        }

    }
}
