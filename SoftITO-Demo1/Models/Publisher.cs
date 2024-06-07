using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Publisher
    {
        //Kurucu Metod
        public Publisher(
            string publisherName, 
            string contactNumber, 
            string contactEmail
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(publisherName))
            {
                throw new ArgumentNullException(nameof(publisherName), "Publisher name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(contactNumber))
            {
                throw new ArgumentNullException(nameof(contactNumber), "Contact number cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(contactEmail))
            {
                throw new ArgumentNullException(nameof(contactEmail), "Contact Email cannot be null or empty.");
            }

            //Veri Atamaları
            PublisherName = publisherName;
            ContactNumber = contactNumber;
            ContactEmail = contactEmail;
            PublisherAddresses = new HashSet<PublisherAddress>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PublisherName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }

        //İlişkiler
        public HashSet<PublisherAddress> PublisherAddresses { get; set; }
    }
}
