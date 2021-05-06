namespace Proppy.API.Domain.Models.Queries
{
    public class EmployeesQuery: Query
    {
        public string Gender {get; set;}

        public EmployeesQuery(string gender, int page, int itemsPerPage): base(page, itemsPerPage)
        {
            Gender = gender;
        }
    }
}