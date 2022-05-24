using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Quester
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBanned { get; set; }
        public int Strikes { get; set; }
        public int BackgroundId { get; set; }
        public string Bio { get; set; }
        public bool OnlinePlay { get; set; }
        public bool OfflinePlay { get; set; }
        public int PostalCode { get; set; }
    }
}
