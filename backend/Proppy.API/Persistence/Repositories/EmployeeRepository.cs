using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proppy.API.Domain.Models;
using Proppy.API.Domain.Repositories;
using Proppy.API.Persistence.Contexts;
using Proppy.API.Domain.Models.Queries;
using System.Linq;
using System.Linq.Dynamic.Core;
using System;

namespace Proppy.API.Persistence.Repositories
{
    public class EmployeeRepository: BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context): base(context)
        {
        }

        public IQueryable<Employee> FilterBy(IQueryable<Employee> queryable, EmployeesQuery query)
        {
            if (!string.IsNullOrEmpty(query.Gender))
            {
                queryable = queryable.Where(e => e.Gender == query.Gender);
            }
            if (!string.IsNullOrEmpty(query.PositionCode))
            {
                queryable = queryable.Where(e => e.Position_Code == query.PositionCode);
            }
            if (!string.IsNullOrEmpty(query.DOB))
            {
                var dobString = query.DOB.Split("-");
                var year = dobString[0];
                var month = dobString.Length == 2 ? dobString[1] : null;

                if (Int32.TryParse(month, out int numericMonth) && numericMonth > 0 && numericMonth < 12)
                    queryable = queryable.Where(e => e.DOB.Month == numericMonth);
                if (Int32.TryParse(year, out int numericYear) && numericYear > 0 && numericYear < 9999)
                    queryable = queryable.Where(e => e.DOB.Year == numericYear);
            }
            return queryable;
        }

        public async Task<QueryResult<Employee>> ListAsync(EmployeesQuery query)
        {
            /* 
            We need to do a few things:
            1. Filter (if provided)
            2. Count
            3. Sort
            4. Paginate
            5. Return
            */

            IQueryable<Employee> queryable = _context.Employees.Include(e => e.Position)
                                                                .AsNoTracking(); // Disable tracking as not needed

            // Filter
            queryable = FilterBy(queryable, query);

            // Count the rows present in this query
            int totalItems = await queryable.CountAsync();

            // Sorting
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                // Getting the strings to check
                var sortBy = query.SortBy.Split(":")[0];
                var orderBy = query.SortBy.EndsWith("desc") ? "descending" : "ascending";

                // Pulling the properties
                var objProperties = typeof(Employee).GetProperties();
                var property = objProperties.FirstOrDefault(em => em.Name.Equals(sortBy, System.StringComparison.InvariantCultureIgnoreCase));

                if (property != null)
                {
                    var orderQuery = $"{property.Name.ToString()} {orderBy}";
                    queryable = queryable.OrderBy(orderQuery);
                }
            }
            else
            {
                queryable = queryable.OrderBy(e => e.ID); // Default
            }

            // Pagination
            List<Employee> employees = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                        .Take(query.ItemsPerPage)
                                                        .ToListAsync();

            // Finally, return the object
            return new QueryResult<Employee>
            {
                Items = employees,
                TotalItems = totalItems
            };
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task<Employee> FindByIdAsync(long code)
        {
            // Include changes the return type, so we have to change ToListAsync -> FirstOrDefaultAsync
            return await _context.Employees.Include(e => e.Position)
                                            .FirstOrDefaultAsync(e => e.ID == code);
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
    }
}