using System.ComponentModel.DataAnnotations.Schema;

namespace TtrpgApi.Models
{
    public class Connection
    {
        public string ConnectionId { get; set; }
        public bool IsConnected { get; set; }
    }
}
