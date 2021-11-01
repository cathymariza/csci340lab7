using System;
using System.ComponentModel.DataAnnotations;

namespace HobbiesRP.Models
{
    public class Hobby
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string HoursperWeek { get; set; }
        public string Activities { get; set; }
        public string Recommendation { get; set; }
    }
}