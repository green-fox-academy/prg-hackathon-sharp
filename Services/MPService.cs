using programmersGuide.Services.Interfaces;
using System;
using System.Runtime.Serialization;

namespace programmersGuide.Services
{
    public class MPService : IMPService
    {
        public string GetPhrase()
        {
            var values = Enum.GetValues(typeof(MotivationalPhrases));
            var phrases = new string[values.Length];
            values.CopyTo(phrases, 0);
            return phrases[new Random().Next(phrases.Length)];
        }

        public enum MotivationalPhrases
        {
            [EnumMember(Value = "null")]
            nullquote,
            [EnumMember(Value = "\"Trying is the first step toward failure.\" - Homer Simpson")]
            homerSimpson,
            [EnumMember(Value = "\"The best things in life are actually really expensive.\" - Unknown")]
            unknown,
            [EnumMember(Value = "\"Not everything is a lesson. Sometimes you just fail.\" - Dwight Schrute")]
            dwightSchrute,
            [EnumMember(Value = "\"Challenging yourself...is a good way to fail.\" - Dom Mazzetti")]
            domMazzetti,
            [EnumMember(Value = "\"It’s only when you look at an ant through a magnifying glass on a sunny day that you realize how often they burst into flames.\" - Harry Hill")]
            harryHill
        }
    }
}
