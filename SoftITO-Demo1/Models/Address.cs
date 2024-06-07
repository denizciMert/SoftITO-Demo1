using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftITO_Demo1.Models
{
    public class Address
    {
        //Kurucu Metod
        public Address(
            string country,
            string district,
            string street,
            string apartment,
            string number,
            string? state = null,
            string? city = null,
            string? postalCode = null
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentNullException(nameof(country), "Country cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(district))
            {
                throw new ArgumentNullException(nameof(district), "District cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(street))
            {
                throw new ArgumentNullException(nameof(street), "Street cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(apartment))
            {
                throw new ArgumentNullException(nameof(apartment), "Apartment cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(number), "Number cannot be null or empty.");
            }
            ModelValidations.AddressValidator.CheckNulls(city, state);

            //Veri Atamaları
            Country = country;
            District = district;
            Street = street;
            Apartment = apartment;
            Number = number;
            State = state;
            City = city;
            PostalCode = postalCode;
            MemberAddresses = new HashSet<MemberAddress>();
            PublisherAddresses = new HashSet<PublisherAddress>();
            StaffAddresses = new HashSet<StaffAddress>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Çok fazla model oluşacağı için bu özellikleri ayrı modellerle birbirine baağlayarak adresleri oluşturmadım.
        public string Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Number { get; set; }
        public string? PostalCode { get; set; }

        //İlişkiler
        public HashSet<MemberAddress> MemberAddresses { get; set; }
        public HashSet<PublisherAddress> PublisherAddresses { get; set; }
        public HashSet<StaffAddress> StaffAddresses { get; set; }
    }
}
