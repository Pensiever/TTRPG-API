using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_BLL.Models
{
    public class Favorite
    {
        public int Id { get; set; }
        public int QuesterId { get; set; }
        public int GameGenreId { get; set; }
    }
}
