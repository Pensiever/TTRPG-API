using TtrpgApi.Domain;
using TtrpgApi.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;

namespace TtrpgApi.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private DataContext _dc;
        public ChatHub(DataContext dc)
        {
            _dc = dc;
        }

        public void AddRoom(string name)
        {
            _dc.Rooms.Add(new Room
            {
                Name = name
            });
            _dc.SaveChanges();
        }

        public bool RoomExists(string name)
        {
            var item = _dc.Rooms.First(t => t.Name == name);
            if (item == null)
            {
                return false;
            }

            return true;
        }

        public async Task SendMessage(String message, string roomName)
        {
            if (RoomExists(roomName))
            {
                var user = new User() { Username = Context.User.FindFirstValue(ClaimTypes.Surname) };
                Text sentMessage = new Text
                {
                    Room = roomName,
                    Sender = user.Username,
                    Content = message
                };
                _dc.Texts.Add(sentMessage);
                _dc.SaveChanges();

                await Clients.Group(roomName).SendAsync("messageSending", sentMessage);
            }
            else
            {
                throw new System.Exception("Room does not exist");
            }
        }

        public IEnumerable<Text> GetAllTexts(string name)
        {
            return _dc.Texts.Where(item => item.Room == name).Select(z =>
                new Text
                {
                    Room = z.Room,
                    Sender = z.Sender,
                    Content = z.Content
                });
        }

        public List<Room> GetAllRooms(string Username)
        {
            return _dc.Users.Where(u => u.Username == Username).SelectMany(u => u.Rooms).ToList();
        }

        public async Task AddToRoom(string roomName)
        {
            var room = _dc.Rooms.Find(roomName);
            if (room != null)
            {
                var user = new User() { Username = Context.User.FindFirstValue(ClaimTypes.Surname) };
                _dc.Users.Attach(user);
                room.Users.Add(user);
                _dc.SaveChanges();
                await Groups.AddToGroupAsync(Context.ConnectionId, room.Name);

                var history = GetAllTexts(roomName);
                await Clients.Client(Context.ConnectionId).SendAsync("History", history);

                await Clients.Group(room.Name).SendAsync("Sent", $"{Context.ConnectionId} a rejoint: {room.Name}.");
            }

        }

        public async Task RemoveFromRoom(string roomName)
        {
            var room = _dc.Rooms.Find(roomName);
            if (room != null)
            {
                var user = new User() { Username = Context.User.Identity.Name };
                _dc.Users.Attach(user);
                
                room.Users.Remove(user);
                _dc.SaveChanges();

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.Name);

                await Clients.Group(room.Name).SendAsync("Send", $"{Context.ConnectionId} a quitté: {room.Name}.");
            }
        }

        public async override Task OnConnectedAsync()
        {
            {
                // Retrieve user.
                var user = _dc.Users
                    .Include(u => u.Rooms)
                    .SingleOrDefault(u => u.Username == Context.User.FindFirstValue(ClaimTypes.Surname));

                // If user does not exist in database, adds user.
                if (user == null)
                {
                    user = new User()
                    {
                        Username = Context.User.FindFirstValue(ClaimTypes.Surname)
                    };
                    _dc.Users.Add(user);
                    _dc.SaveChanges();
                }
            }
        }
    }
}
