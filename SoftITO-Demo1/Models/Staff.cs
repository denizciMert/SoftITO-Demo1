namespace SoftITO_Demo1.Models
{
    public class Staff : Person
    {
        //Kurucu Metod
        public Staff(
            string firstName, 
            string lastName, 
            DateTime dateOfBirth, 
            string contactEmail, 
            string contactNumber,
            Nation nation,
            Position position
            ) : base(firstName, lastName, contactEmail, contactNumber, dateOfBirth)
        {
            //Null Kontrolü
            if (position == null)
            {
                throw new ArgumentNullException(nameof(position), "Position cannot be null.");
            }
            ModelValidations.AgeValidator.Check(dateOfBirth, true);

            //Veri Atamaları
            Nation = nation;
            Position = position;
            HireDate = DateTime.Now.Date;
            Active = true;
            StaffAddresses = new HashSet<StaffAddress>();
        }

        //Model
        public DateTime HireDate { get; set; }
        public bool Active { get; set; }

        //İlişkiler
        public Nation Nation { get; set; }
        public Position Position { get; set; }
        public HashSet<StaffAddress> StaffAddresses { get; set; }
    }
}
