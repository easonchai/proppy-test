using AutoMapper;
using Proppy.API.Domain.Models;
using Proppy.API.Resources;

namespace Proppy.API.Mapping
{
    public class ModelToResourceProppy: Profile
    {
        public ModelToResourceProppy()
        {
            CreateMap<Position, PositionResource>();
            CreateMap<Employee, EmployeeResource>()
                .ForMember(src => src.Gender,
                            options => options.MapFrom(src => src.Gender.ToDescriptionString()));
        }
    }
}