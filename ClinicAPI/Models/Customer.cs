using System;
using System.Collections.Generic;

#nullable disable

namespace ClinicAPI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            DetailOrders = new HashSet<DetailOrder>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DetailOrder> DetailOrders { get; set; }
    }
}
