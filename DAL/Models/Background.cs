using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Background
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string NavTop { get; set; }
        public string NavTopFont { get; set; }
        public string NavSide { get; set; }
        public string NavSideFont { get; set; }
        public string NavSideButton { get; set; }
        public string Footer { get; set; }
        public string FooterFont { get; set; }
    }
}
