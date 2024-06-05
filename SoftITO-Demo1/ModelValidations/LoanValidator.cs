namespace SoftITO_Demo1.ModelValidations
{
    public class LoanValidator
    {
        public static DateTime Calculate(DateTime loanDate, int days)
        {
            DateTime dueDate = loanDate.AddDays(days);
            return dueDate.Date;
        }
    }
}
