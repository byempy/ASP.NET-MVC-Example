using System.ComponentModel.DataAnnotations;

namespace ConsultaDB.Entities
{
    public class Person
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _title;

        public int Id {
            get { return _id; }
            set { _id = value; }
        }

        [Required]
        [StringLength(50)]
        public string FirstName {
            get {return _firstName; }
            set {_firstName = value ?? ""; }
        }
        [Required]
        [StringLength(50)]
        public string LastName {
            get {return _lastName; }
            set {_lastName = value ?? ""; }
        }
        [StringLength(5)]
        public string MiddleName {
            get {return _middleName; }
            set {_middleName = value ?? ""; }
        }
        [StringLength(5)]
        public string Title {
            get {return _title; }
            set {_title = value ?? ""; }
        }

        public Person(int id, string nombre, string apellido, string segundoNombre, string titulo)
        {
            this.Id = id;
            FirstName = nombre;
            LastName = apellido;
            MiddleName = segundoNombre;
            Title = titulo;
        }

        public Person()
        {
            FirstName = "";
            LastName = "";
            MiddleName = "";
            Title = "";
        }

        public override bool Equals(object persona)
        {
            var persona2 = (Person)persona;
            return Id.Equals(persona2.Id) 
                && FirstName.Equals(persona2.FirstName) 
                && LastName.Equals(persona2.LastName);
        }
    }
}
