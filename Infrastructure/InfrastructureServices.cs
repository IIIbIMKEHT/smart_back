using Application.Core.Interfaces;
using Application.Core.Specification;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            //Repositories
            services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IGroup, GroupRepository>();
            services.AddScoped<IProfession, ProfessionRepository>();
            services.AddScoped<ISpecialization, SpecializationRepository>();
            services.AddScoped<IAcademicDegree, AcademicDegreeRepository>();
            services.AddScoped<IAcademicYear, AcademicYearRepository>();
            services.AddScoped<ISubject, SubjectRepository>();
            services.AddScoped<ILanguage, LanguageRepository>();
            services.AddScoped<IRolesUsers, RolesUsersRepository>();
            services.AddScoped<IExercise, ExerciseRepository>();
            services.AddScoped<IWorkload, WorkloadRepository>();
            return services;
        }
    }
}
