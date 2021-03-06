using AutoMapper;
using Proppy.API.Domain.Models;
using Proppy.API.Resources;
using Proppy.API.Domain.Models.Queries;

namespace Proppy.API.Mapping
{
    public class ResourceToModelProfile: Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePositionResource, Position>();
            CreateMap<UpdatePositionResource, Position>();

            CreateMap<SaveEmployeeResource, Employee>();
            CreateMap<EmployeeQueryResource, EmployeesQuery>();
        }
    }
}