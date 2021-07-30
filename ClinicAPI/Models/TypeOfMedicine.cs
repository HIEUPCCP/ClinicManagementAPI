using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAPI.Models
{
    public partial class TypeOfMedicine
    {
        public TypeOfMedicine()
        {
            Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
