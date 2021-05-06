using System.Collections.Generic;

namespace Proppy.API.Resources
{
    // Returns a generic class, therefore it is reusable
    public class QueryResultResource<T>
    {
        public int TotalItems {get; set;} = 0;
        public List<T> Items {get; set;} = new List<T>();
    }
}