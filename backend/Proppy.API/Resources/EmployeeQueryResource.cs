using System;

namespace Proppy.API.Resources
{
    public class EmployeeQueryResource: QueryResource
    {
        // For filtering
        public string Gender {get; set;}  // This will allow people to GET by /api/employees?gender=M
        public string PositionCode {get; set;}
        public string DOB {get; set;} // Will allow by month or year

        // The rest of the properties don't make sense to be filtered. They should be searched instead.
    }
}