namespace Proppy.API.Resources
{
    // This will be used as a composition class to help with querying data
    public class QueryResource
    {
        public int Page {get; set;}
        public int ItemsPerPage {get; set;}
        public string SortBy {get; set;}
    }
}