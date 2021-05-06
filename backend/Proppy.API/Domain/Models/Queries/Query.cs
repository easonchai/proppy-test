namespace Proppy.API.Domain.Models.Queries
{
    public class Query
    {
        public int Page {get; protected set;}
        public int ItemsPerPage {get; protected set;}
        public string SortBy {get; protected set;}

        public Query(int page, int itemsPerPage, string sortBy)
        {
            Page = page;
            ItemsPerPage = itemsPerPage;
            SortBy = sortBy;

            // We can do some basic built-in error handling like below:
            if (page <= 0)
                Page = 1;
            if (itemsPerPage <= 0)
                ItemsPerPage = 10;
        }
    }
}