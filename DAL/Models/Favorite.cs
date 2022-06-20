using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int QuesterId { get; set; }
        public int GameGenreId { get; set; }
    }
}
