using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SoftITO_Demo1.Models
{
    public class Person
    {
        //Kurucu Metod
        public Person(
            string firstName,
            string lastName,
            string contactEmail,
            string contactNumber,
            DateTime dateOfBirth
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
            if (string.IsNullOrWhiteSpace(contactEmail))
            {
                throw new ArgumentNullException(nameof(contactEmail), "Contact email cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                throw new ArgumentNullException(nameof(contactNumber), "Contact number cannot be null or empty.");
            }

            //Veri Atamaları
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth.Date;
            ContactEmail = contactEmail;
            ContactNumber = contactNumber;
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
