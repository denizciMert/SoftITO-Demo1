using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftITO_Demo1.Models
{
    public class Nation
    {
        //Kurucu Metod
        public Nation(
            string nationName
            )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(nationName))
            {
                throw new ArgumentNullException(nameof(nationName), "Nation name cannot be null or empty.");
            }

            //Veri Atamaları
            NationName = nationName;
            Author = new HashSet<Author>();
            Staff = new HashSet<Staff>();
            Member = new HashSet<Member>();
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NationName { get; set; }

        //İlişkiler
        public HashSet<Author> Author { get; set; }
        public HashSet<Staff> Staff { get; set; }
        public HashSet<Member> Member { get; set; }
    }
}
