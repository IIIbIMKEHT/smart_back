using Application.Core.DTOs.Role;
using Application.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.DTOs.RolesUsers
{
    public class RolesUsersRDTO : BaseDTO
    {
        public long RoleId { get; set; }
        public virtual RoleRDTO Role { get; set; }
        public long UserId { get; set; }
        public virtual UserRDTO User { get; set; }
    }
}
