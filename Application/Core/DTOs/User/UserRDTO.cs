using Application.Core.DTOs.Department;
using Application.Core.DTOs.Faculty;
using Application.Core.DTOs.Group;
using Application.Core.DTOs.Role;
using Application.Core.DTOs.RolesUsers;
using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.User
{
    public class UserRDTO : BaseDTO
    {
        public virtual List<RolesUsersRDTO> RolesUsers { get; set; }
        public long? FacultyId { get; set; }
        public virtual FacultyRDTO Faculty { get; set; }
        public long? DepartmentId { get; set; }
        public virtual DepartmentRDTO Department { get; set; }
        public long? GroupId { get; set; }
        public virtual GroupRDTO Group { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public long IIN { get; set; }
        public int Status { get; set; }
    }
}
