namespace GemeloVirtual.Web.Data.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public int Age { get; set; }
        public bool Gender { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public int Telephone { get; set; }
        public string Ilness { get; set; }
        public string Alergies { get; set; }

    }
}
