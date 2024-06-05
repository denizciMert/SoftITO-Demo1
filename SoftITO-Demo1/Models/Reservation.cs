using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Reservation
    {
        //Kurucu Metod
        public Reservation(
            DateTime reservationEndDate, 
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
            ReservationDate = DateTime.Now;
            ReservationEndDate = reservationEndDate;
            Book = book;
            Member = member;
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime ReservationDate { get; set; }
        public DateTime ReservationEndDate { get; set; }

        //İlişkiler
        public Book Book { get; set; }
        public Member Member { get; set; }

    }
}
