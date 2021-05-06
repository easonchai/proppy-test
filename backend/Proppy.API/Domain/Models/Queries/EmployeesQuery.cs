using System;

namespace Proppy.API.Domain.Models.Queries
{
    public class EmployeesQuery: Query
    {
        public string Gender {get; set;}
        public string PositionCode {get; set;}
        public string DOB {get; set;}

        public EmployeesQuery(string gender, string positionCode, string dob, int page, int itemsPerPage, string sortBy): base(page, itemsPerPage, sortBy)
        {
            Gender = gender;
            PositionCode = positionCode;
            DOB = dob;
        }
    }
}