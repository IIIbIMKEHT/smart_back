using Application.Core.DTOs.AcademicDegree;
using Application.Core.DTOs.AcademicYear;
using Application.Core.DTOs.Department;
using Application.Core.DTOs.Exercise;
using Application.Core.DTOs.Faculty;
using Application.Core.DTOs.Group;
using Application.Core.DTOs.Language;
using Application.Core.DTOs.Profession;
using Application.Core.DTOs.Role;
using Application.Core.DTOs.RolesUsers;
using Application.Core.DTOs.Specialization;
using Application.Core.DTOs.Subject;
using Application.Core.DTOs.User;
using Application.Core.DTOs.Workload;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Faculty, FacultyCUD>().ReverseMap();
            CreateMap<Faculty, FacultyRDTO>().ReverseMap();
            CreateMap<Department, DepartmentRDTO>().ReverseMap();
            CreateMap<Department, DepartmentCUD>().ReverseMap();
            CreateMap<Role, RoleCUD>().ReverseMap();
            CreateMap<Role, RoleRDTO>().ReverseMap();
            CreateMap<User, UserCUD>().ReverseMap();
            CreateMap<User, UserRDTO>().ReverseMap();
            CreateMap<RolesUsers, RolesUsersCUD>().ReverseMap();
            CreateMap<RolesUsers, RolesUsersRDTO>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearCUD>().ReverseMap();
            CreateMap<AcademicYear, AcademicYearRDTO>().ReverseMap();
            CreateMap<Group, GroupCUD>().ReverseMap();
            CreateMap<Group, GroupRDTO>().ReverseMap();
            CreateMap<Profession, ProfessionCUD>().ReverseMap();
            CreateMap<Profession, ProfessionRDTO>().ReverseMap();
            CreateMap<Specialization, SpecializationCUD>().ReverseMap();
            CreateMap<Specialization, SpecializationRDTO>().ReverseMap();
            CreateMap<AcademicDegree, AcademicDegreeCUD>().ReverseMap();
            CreateMap<AcademicDegree, AcademicDegreeRDTO>().ReverseMap();
            CreateMap<Subject, SubjectCUD>().ReverseMap();
            CreateMap<Subject, SubjectRDTO>().ReverseMap();
            CreateMap<Language, LanguageCUD>().ReverseMap();
            CreateMap<Language, LanguageRDTO>().ReverseMap();
            CreateMap<Exercise, ExerciseCUD>().ReverseMap();
            CreateMap<Exercise, ExerciseRDTO>().ReverseMap();
            CreateMap<Workload, WorkloadCUD>().ReverseMap();
            CreateMap<Workload, WorkloadRDTO>().ReverseMap();
        }
    }
}
