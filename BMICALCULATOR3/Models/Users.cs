using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICALCULATOR3.Models
{
    public class Users
    {
       
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Bmi { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
