using AutoMapper;
using EmployeeManagement.model;
using EmployeeManagement.Web.Models;

namespace EmployeeManagement.Web
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                   .ForMember(dest => dest.ConfirmEmail,
                           opt => opt.MapFrom(src => src.Email));
            CreateMap< EditEmployeeModel, Employee>();
        }

    }
}
