using System.Collections.Generic;

namespace Proppy.API.Domain.Models
{
    public class Position
    {
        public int Id {get; set;}
        public string Code {get; set;}
        public string Description {get; set;}
        public ICollection<Employee> Employees {get; set;}
    }
}