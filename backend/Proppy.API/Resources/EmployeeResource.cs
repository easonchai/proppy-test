using System;

namespace Proppy.API.Resources
{
    public class EmployeeResource
    {
        public long ID {get; set;}
        public string Name {get; set;}
        public string PhoneNo {get; set;}
        public string Email{get; set;}
        public string Gender {get; set;}
        public PositionResource Position {get; set;}
        public DateTime DOB {get; set;} 
        public int Salary {get; set;}
        public string Remarks {get; set;}
        public string Photo {get; set;}
    }
}