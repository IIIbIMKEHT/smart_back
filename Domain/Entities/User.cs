using Domain.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public List<RolesUsers> RolesUsers { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long IIN { get; set; }
        public long? GroupId { get; set; }
        public Group Group { get; set; }
        public long? FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public long? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int Status { get; set; } = 1;
    }
}
