using ClinicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Services
{
	public interface MedicineService
	{
		public List<Medicine> FindAll();
		public Medicine Find(int id);
		// type medice +create +delete
		public List<TypeOfMedicine> TypeMedicine();
		public TypeOfMedicine AddTypeMedicine(TypeOfMedicine typeOfMedicine);
		public void DeleteTypeMedicine(int id);
		//add+update medicine 
		public Medicine AddMedicine(Medicine medicine);
		public Medicine UpdateMedicine(Medicine medicine);
		public void DeleteMedicine(int id);
		//search
		public List<Medicine> Search(string keyword);
		public List<Medicine> SearchType(int madicineType);
	}
}
