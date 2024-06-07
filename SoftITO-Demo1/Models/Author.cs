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
            Nation nation, 
            string biography, 
            DateTime dateOfBirth, 
            DateTime? dateOfDeath
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

            //Veri Atamaları
            FirstName = firstName;
            LastName = lastName;
            Nation = nation;
            Biography = biography;
            DateOfBirth = dateOfBirth;
            DateOfDeath = dateOfDeath;
            Books = new HashSet<Book>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        //İlişkiler
        public Nation Nation { get; set; }
        public HashSet<Book> Books { get; set; }
    }
}
