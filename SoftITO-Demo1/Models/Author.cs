using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Author
    {
        //Kurucu Metod
        public Author(
            string firstName, 
            string lastName, 
            string nationality
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "First name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Last name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(nationality))
            {
                throw new ArgumentNullException(nameof(nationality), "Nationality cannot be null or empty.");
            }

            //Veri Atamaları
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            Books = new List<Book>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }

        //İlişkiler
        public List<Book> Books { get; set; }
    }
}
