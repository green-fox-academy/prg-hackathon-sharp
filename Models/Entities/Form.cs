using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace programmersGuide.Models
{
    public class Form
    {
        public long ID { get; set; }
        public DateTime Time {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Int16 Rating { get; set; }
        public string Review { get; set; }
    }

    public enum Role
    {
        [EnumMember(Value = "frontend")]
        frontend,
        [EnumMember(Value = "backend")]
        backend,
        [EnumMember(Value = "fullstack")]
        fullstack
    }
}
