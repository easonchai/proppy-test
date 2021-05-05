using System.Collections.Generic;
using System;

namespace Proppy.API.Domain.Models
{
    public class Employee
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public string Phone_No {get; set;}
        public string Email{get; set;}
        public string Gender {get; set;}
        public Position Position {get; set;}
        public string Position_Code {get; set;}
        public DateTime DOB {get; set;} 
        public int Salary {get; set;}
        public string Remarks {get; set;}
        public string Photo {get; set;}
    }
}