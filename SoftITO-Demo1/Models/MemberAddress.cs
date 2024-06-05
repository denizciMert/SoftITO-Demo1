using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    //Ara Model
    public class MemberAddress
    {
        public int MemberId { get; set; }
        public int AddressId { get; set; }

        //İlişkiler
        [ForeignKey("MemberId")]
        public Member Member { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
