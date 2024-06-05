using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    //Ara Model
    public class StaffAddress
    {
        public int StaffId { get; set; }
        public int AddressId { get; set; }

        //İlişkiler
        [ForeignKey("StaffId")]
        public Staff Staff { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
