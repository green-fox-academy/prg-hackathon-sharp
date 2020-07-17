using programmersGuide.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace programmersGuide.Models.Entities
{
    public class Quiz
    {
        public long Id { get; set; }
        public Role Result { get; set; }
        public long ResultCount { get; set; }
    }
}
