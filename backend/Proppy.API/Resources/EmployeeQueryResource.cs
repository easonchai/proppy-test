namespace Proppy.API.Resources
{
    public class EmployeeQueryResource: QueryResource
    {
        public long? ID {get; set;}  // This is optional since we will use for both the base GET and GET by ID
    }
}