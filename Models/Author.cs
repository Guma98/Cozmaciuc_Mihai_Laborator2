using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cozmaciuc_Mihai_Laborator2.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
