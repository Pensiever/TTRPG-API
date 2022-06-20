using System.ComponentModel.DataAnnotations.Schema;

namespace TtrpgApi.Models
{
    public class Text
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Room { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
    }
}
