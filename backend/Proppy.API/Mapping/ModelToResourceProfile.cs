using AutoMapper;
using Proppy.API.Domain.Models;
using Proppy.API.Resources;
using Proppy.API.Domain.Models.Queries;

namespace Proppy.API.Mapping
{
    public class ModelToResourceProppy: Profile
    {
        public ModelToResourceProppy()
        {
            CreateMap<Position, PositionResource>();
            CreateMap<Employee, EmployeeResource>();
            CreateMap<QueryResult<Employee>, QueryResultResource<EmployeeResource>>();
        }
    }
}