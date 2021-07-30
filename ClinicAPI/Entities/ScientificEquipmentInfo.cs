using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Web_Api.Entities
{
	public class ScientificEquipmentInfo
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Illustration { get; set; }
        public int? InventedYear { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public bool? Status { get; set; }
        public int? BrandId { get; set; }
        public int? OriginId { get; set; }
        public int? MachineCategoryId { get; set; }
        public int? Priceid { get; set; }


    }
}
