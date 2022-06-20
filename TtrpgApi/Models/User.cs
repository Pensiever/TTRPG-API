using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TtrpgApi.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public ICollection<Connection> Connections { get; set; }
        public ICollection<Room> Rooms { get; set; }
        [ForeignKey("Sender")]
        public ICollection<Text> Texts { get; set; }
    }
}
