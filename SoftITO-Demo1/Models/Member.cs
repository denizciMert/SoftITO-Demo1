namespace SoftITO_Demo1.Models
{
    public class Member : Person
    {
        //Kurucu Metod
        public Member(
            string firstName, 
            string lastName, 
            bool gender,
            string contactEmail, 
            string contactNumber, 
            DateTime dateOfBirth,
            Nation nation,
            DateTime? joinDate = null
            ) : base(firstName, lastName, gender, contactEmail, contactNumber, dateOfBirth)
        {
            //Null Kontrolü
            ModelValidations.AgeValidator.Check(dateOfBirth);

            //Veri Atamaları
            JoinDate = joinDate ?? DateTime.Now;
            Active = true;
            Nation = nation;
            MemberAddresses = new HashSet<MemberAddress>();
        }

        //Model
        public DateTime JoinDate { get; set; }
        public bool Active { get; set; }

        //İlişkiler
        public Nation Nation { get; set; }
        public HashSet<MemberAddress> MemberAddresses { get; set; }
    }
}
