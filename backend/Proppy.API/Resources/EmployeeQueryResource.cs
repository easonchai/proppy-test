namespace Proppy.API.Resources
{
    public class EmployeeQueryResource: QueryResource
    {
        // For filtering
        public string Gender {get; set;}  // This will allow people to GET by /api/employees?gender=M
    }
}