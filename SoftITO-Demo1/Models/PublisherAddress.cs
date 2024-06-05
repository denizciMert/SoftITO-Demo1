using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    //Ara Model
    public class PublisherAddress
    {
        public int PublisherId { get; set; }
        public int AddressId { get; set; }

        //İlişkiler
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
