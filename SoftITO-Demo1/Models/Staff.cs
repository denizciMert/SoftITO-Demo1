using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Staff
    {
        //Kurucu Metod
        public Staff(
            string firstName, 
            string lastName, 
            DateTime birthDate, 
            string contactEmail, 
            string contactNumber,
            Position position
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
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position), "Position cannot be null.");
            }
            ModelValidations.AgeValidator.Check(birthDate, true);

            //Veri Atamaları
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate.Date;
            ContactEmail = contactEmail;
            ContactNumber = contactNumber;
            Position = position;
            HireDate = DateTime.Now.Date;
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        //İlişkiler
        public Position Position { get; set; }
        public List<StaffAddress> StaffAddresses { get; set; } = [];
    }
}
