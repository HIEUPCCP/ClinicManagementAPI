using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic_Web_Api.Entities;
using ClinicAPI.Models;
namespace ClinicAPI.Services
{
	public interface ScientificEquipmentService
	{
		public List<ScientificEquipment> FindAll();
		//bang nho
		public List<Origin> Orgin();
		public List<Brand> Brand();
		public List<MachineCategory> MachineCategory();
		public List<Price> Price();
		public List<TypeOfMedicine> TypeOfMedicine();
		//
		public ScientificEquipment Find(int id);
		//search
		public List<ScientificEquipment> Search(string keyword);
		public List<ScientificEquipment> SearchType(int machineType);
		//delete
		public void Delete(int id);
		//create
		public ScientificEquipmentInfo Create(ScientificEquipment scientific);
		//update
		public ScientificEquipmentInfo Update(ScientificEquipment scientific);
		//add+delete barand
		public Brand AddBrand(Brand brand);
		public void DeleteBrand(int id);
		//add+delete origin
		public Origin AddOrigin(Origin origin);
		public void DeleteOrigin(int id);
		//add+delete MachineCategory
		public MachineCategory AddMachineCategory(MachineCategory machineCategory);
		public void DeleteMachineCategory(int id);
		//add+delete MachineCategory
		public Price AddPrice(Price price);
		public void DeletePrice(int id);




	}
}
