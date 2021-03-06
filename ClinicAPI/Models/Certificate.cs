using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAPI.Models
{
    public partial class Certificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime? Created { get; set; }
        public int? StaffId { get; set; }

        public virtual staff Staff { get; set; }
    }
}
