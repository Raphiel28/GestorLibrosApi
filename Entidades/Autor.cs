namespace GerstorLibrosAPI.Entidades
{
    public class Autor
    {

        public Autor(int id, int idBook, string firstName, string lastName) {
        
            Id = id;
            IdBook = idBook;
            FirstName = firstName;
            LastName = lastName;
        
        
        }

        public int Id { get; set; }
        public int IdBook { get; set; }
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
