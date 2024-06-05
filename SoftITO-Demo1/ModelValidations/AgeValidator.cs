namespace SoftITO_Demo1.ModelValidations
{
    public class AgeValidator
    {
        private const int MinimumAgeForMember = 9;
        private const int MinimumAgeForStaff = 18;
        private const int MaximumAge = 150;
        public static bool Check(DateTime birthDate, bool forStaff=false)
        {
            DateTime date = DateTime.Now;
            int age = date.Year - birthDate.Year;
            if (date.Month < birthDate.Month || (date.Month == birthDate.Month && date.Day < birthDate.Day))
            {
                age--;
            }
            if (age < MinimumAgeForMember || age > MaximumAge)
            {
                throw new ArgumentOutOfRangeException(nameof(birthDate), "Invalid birth date input.");
            }
            if (forStaff && age < MinimumAgeForStaff)
            {
                throw new ArgumentOutOfRangeException(nameof(birthDate), "Staff member must be at least 18 years old.");
            }
            return true;
        }
    }
}
