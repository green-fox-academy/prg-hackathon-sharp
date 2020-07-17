using Microsoft.AspNetCore.Identity;
using System.Runtime.Serialization;

namespace programmersGuide.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string? QuizAnswers { get; set; }
        public ProgrammingPath? ProgrammingPath { get; set; }
    }

    public enum ProgrammingPath
    {
        [EnumMember(Value = "frontend")]
        frontend,
        [EnumMember(Value = "backend")]
        backend,
        [EnumMember(Value = "fullstack")]
        fullstack
    }
}
