namespace TtrpgApi.Models
{
    public class ConnectedQuester
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
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
        public string Token { get; set; }
    }
}
