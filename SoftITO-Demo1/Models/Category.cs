using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Category
    {
        //Kurucu Metod
        public Category(
            string categoryName
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException(nameof(categoryName), "Category name cannot be null or empty.");
            }

            //Veri Atamaları
            CategoryName = categoryName;
            Books = new HashSet<Book>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        //İlişkiler
        public HashSet<Book> Books { get; set; }
    }
}
