using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TtrpgApi.Models
{
    public class Room
    {
        [Key]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        [ForeignKey("Room")]
        public ICollection<Text> Texts { get; set; }
    }
}
