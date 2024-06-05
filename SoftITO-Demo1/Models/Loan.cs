using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftITO_Demo1.Models
{
    public class Loan
    {
        //Kurucu Metod
        public Loan(
            Book book, 
            Member member
            )
        {
            //Null Kontrolü
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member cannot be null.");
            }

            //Veri Atamaları
            Book = book;
            Member = member;
            LoanDate = DateTime.Now;
            DueDate = ModelValidations.LoanValidator.Calculate(DateTime.Now,30);
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        //İlişkiler
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
