using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.Entities
{
    public class UserAward
    {
        public Guid UserId { get; set; }
        public Guid AwardId { get; set; }
    }
}
