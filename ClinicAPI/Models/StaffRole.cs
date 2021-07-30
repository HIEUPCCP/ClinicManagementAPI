using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAPI.Models
{
    public partial class StaffRole
    {
        public int StaffId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual staff Staff { get; set; }
    }
}
