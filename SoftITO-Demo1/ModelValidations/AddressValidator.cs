namespace SoftITO_Demo1.ModelValidations
{
    public class AddressValidator
    {
        public static bool CheckNulls(string? city, string? state)
        {
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(state))
            {
                throw new ArgumentException("City and State can't be null or empty at the same time.");
            }

            return true;
        }
    }
}
