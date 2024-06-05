using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Penalty
    {
        //Kurucu Metod
        public Penalty(
            string penaltyName, 
            decimal amount, 
            Member member,
            Book book,
            bool isPaid = false
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(penaltyName))
            {
                throw new ArgumentNullException(nameof(penaltyName), "Penalty name cannot be null or empty.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
            }
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member cannot be null.");
            }
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }

            //Veri Atamaları
            PenaltyName = penaltyName;
            IssuedDate = DateTime.Now.Date;
            IsPaid = isPaid;
            Amount = amount;
            Member = member;
            Book = book;
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PenaltyName { get; set; }
        public bool IsPaid { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }

        //İlişkiler
        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
