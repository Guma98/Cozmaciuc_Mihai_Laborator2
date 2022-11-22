namespace Cozmaciuc_Mihai_Laborator2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public ICollection<Book>? Books { get; set; } //navigation property
    }
}
