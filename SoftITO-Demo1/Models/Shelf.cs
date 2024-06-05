using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Shelf
    {
        //Kurucu Metod
        public Shelf(
            string shelfChar, 
            string shelfNumber
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(shelfChar))
            {
                throw new ArgumentNullException(nameof(shelfChar), "Shelf character cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(shelfNumber))
            {
                throw new ArgumentNullException(nameof(shelfNumber), "Shelf number cannot be null or empty.");
            }

            //Veri Atamaları
            ShelfChar = shelfChar;
            ShelfNumber = shelfNumber;
            Books = new List<Book>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ShelfChar { get; set; }
        public string ShelfNumber { get; set; }

        //İlişkiler
        public List<Book> Books { get; set; }
    }
}
