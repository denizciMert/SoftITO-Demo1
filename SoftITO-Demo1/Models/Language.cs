using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Language
    {
        //Kurucu Metod
        public Language(
            string language
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(language))
            {
                throw new ArgumentNullException(nameof(language), "Language name cannot be null or empty.");
            }

            //Veri Atamaları
            LanguageName = language;
            Books = new HashSet<Book>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LanguageName { get; set; }

        //İlişkiler
        public HashSet<Book> Books { get; set; }
    }
}
