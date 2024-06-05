using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SoftITO_Demo1.Models
{
    //Kurucu Metod
    public class Position
    {
        public Position(
            string positionName
        )
        {
            //Null Kontrolü
            if (string.IsNullOrWhiteSpace(positionName))
            {
                throw new ArgumentNullException(nameof(positionName),"Position name cannot be null or empty.");
            }
            
            //Veri Atamaları
            PositionName = positionName;
        }

        //Model
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string PositionName { get; set; }

        //İlişkiler
        public List<Staff> Staff { get; set; } = [];
    }
}
