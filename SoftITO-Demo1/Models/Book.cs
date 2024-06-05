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
            int pages, 
            int copyCount, 
            DateTime publishDate, 
            Language language,
            List<Author> authors, 
            List<Publisher> publishers, 
            List<Category> categories, 
            List<Shelf> shelves
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
            PublishDate = publishDate;
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
        public int Pages { get; set; }
        public int CopyCount { get; set; }
        public DateTime PublishDate { get; set; }

        //İlişkiler
        public List<Author> Authors { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Category> Categories { get; set; }
        public Language Language { get; set; }
        public List<Shelf> Shelves { get; set; }
    }
}
