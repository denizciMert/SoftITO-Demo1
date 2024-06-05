using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Member
    {
        //Kurucu Metod
        public Member(
            string firstName, 
            string lastName, 
            string contactEmail, 
            string contactNumber, 
            DateTime birthDate,
            DateTime? joinDate = null
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
            ModelValidations.AgeValidator.Check(birthDate);

            //Veri Atamaları
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate.Date;
            ContactEmail = contactEmail;
            ContactNumber = contactNumber;
            JoinDate = joinDate ?? DateTime.Now;
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
        public DateTime JoinDate { get; set; }

        //İlişkiler
        public List<MemberAddress> MemberAddresses { get; set; } = [];
    }
}
