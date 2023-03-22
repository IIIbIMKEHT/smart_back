using Application.Core.Interfaces;
using Application.Features.Departments.Params;
using Domain.Entities.Systems;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Specifications.DepartmentSpec
{
    public class DepartmentSpecification : BaseSpecification<Department>
    {
        public DepartmentSpecification() 
        {
            AddInclude("Faculty");
        }
    }
}
