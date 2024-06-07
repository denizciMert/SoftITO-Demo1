using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftITO_Demo1.Models
{
    public class Book
    {
        //Kurucu Metod
        public Book(
            string title, 
            string isbn, 
            short pages, 
            byte copyCount, 
            DateTime publishDate, 
            Language language,
            HashSet<Author> authors, 
            HashSet<Publisher> publishers, 
            HashSet<Category> categories, 
            HashSet<Shelf> shelves
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentNullException(nameof(isbn), "ISBN cannot be null or empty.");
            }
            if (pages <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pages), "Pages must be greater than zero.");
            }
            if (copyCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(copyCount), "Copy count must be greater than zero.");
            }

            //Veri Atamaları
            Title = title;
            Isbn = isbn;
            Pages = pages;
            CopyCount = copyCount;
            Active = true;
            PublishDate = publishDate.Date.Year;
            Language = language ?? throw new ArgumentNullException(nameof(language), "Language cannot be null.");
            Authors = authors;
            Publishers = publishers;
            Categories = categories;
            Shelves = shelves;
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Isbn { get; set; }
        public short Pages { get; set; }
        public byte CopyCount { get; set; }
        public bool Active { get; set; }
        public int PublishDate { get; set; }

        //İlişkiler
        public HashSet<Author> Authors { get; set; }
        public HashSet<Publisher> Publishers { get; set; }
        public HashSet<Category> Categories { get; set; }
        public Language Language { get; set; }
        public HashSet<Shelf> Shelves { get; set; }
    }
}
