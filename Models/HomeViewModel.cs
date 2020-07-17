using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Models
{
    public class HomeViewModel
    {
        public Review Review { get; set; }
        public List<Review> Reviews { get; set; }
        public User User { get; set; }
    }
}
