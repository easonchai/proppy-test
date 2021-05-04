using System.Collections.Generic;

namespace Profile.API.Domain.Models
{
    public class Position
    {
        public string Code {get; set;}
        public string Description {get; set;}
        public ICollection<Employee> Employees {get; set;}
    }
}