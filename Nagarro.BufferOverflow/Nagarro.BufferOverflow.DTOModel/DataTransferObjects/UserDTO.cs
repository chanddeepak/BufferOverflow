using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("User", MappingType.TotalExplicit)]
    public class UserDTO : DTOBase, IUserDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "FirstName")]
        public string FirstName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "LastName")]
        public string LastName { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Email")]
        public string Email { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Password")]
        public string Password { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Image")]
        public string Image { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Created")]
        public DateTime Created { get; set; }

    }
}
