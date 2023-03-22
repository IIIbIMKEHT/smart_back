using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.User
{
    public class UserCUD
    {
        public long? FacultyId { get; set; }
        public long? DepartmentId { get; set; }
        public long? GroupId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string Password { get; set; }
        public string? ImageUrl { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public long IIN { get; set; }
        public int Status { get; set; }
    }
}
