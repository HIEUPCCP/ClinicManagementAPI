using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Services
{
	public class MedicineServicelmpl:MedicineService
	{
		private DatabaseContext db;

		public MedicineServicelmpl(DatabaseContext _db)
		{
			db = _db;
		}

		public List<Medicine> FindAll()
		{
			return db.Medicines.Select(m => new Medicine
			{
				Id = m.Id,
				Name=m.Name,
				Illustration=m.Illustration,
				Ingredient=m.Ingredient,
				PresentationFormat=m.PresentationFormat,
				Point=m.Point,
				Using=m.Using,
				SpecialWarning=m.SpecialWarning,
				Quantity=m.Quantity,
				DateOfManufacture=m.DateOfManufacture,
				Expiry=m.Expiry,
				Status=m.Status,
				OriginId=m.OriginId,
				TypeOfId=m.TypeOfId,
				BrandId=m.BrandId,
				Priceid=m.Priceid,		

			}).ToList();
		}
		//find
		public Medicine Find(int id)
		{
			return db.Medicines.Where(p => p.Id == id).Select(m => new Medicine
			{
				Id = m.Id,
				Name = m.Name,
				Illustration = m.Illustration,
				Ingredient = m.Ingredient,
				PresentationFormat = m.PresentationFormat,
				Point = m.Point,
				Using = m.Using,
				SpecialWarning = m.SpecialWarning,
				Quantity = m.Quantity,
				DateOfManufacture = m.DateOfManufacture,
				Expiry = m.Expiry,
				Status = m.Status,
				OriginId = m.OriginId,
				TypeOfId = m.TypeOfId,
				BrandId = m.BrandId,
				Priceid = m.Priceid,


			}).FirstOrDefault();
		}
		//list typeb medicine
		public List<TypeOfMedicine> TypeMedicine()
		{
			return db.TypeOfMedicines.Select(t => new TypeOfMedicine
			{
				Id=t.Id,
				Category=t.Category
			}).ToList();
		}
		//add type medicine
		public TypeOfMedicine AddTypeMedicine(TypeOfMedicine typeOfMedicine)
		{
			db.TypeOfMedicines.Add(typeOfMedicine);
			db.SaveChanges();
			return new TypeOfMedicine
			{
				Category = typeOfMedicine.Category
			};
		}
		//delete type medicine
		public void DeleteTypeMedicine(int id)
		{
			db.TypeOfMedicines.Remove(db.TypeOfMedicines.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}
		//ADD+update+delete medicine
		public Medicine AddMedicine(Medicine medicine)
		{
			db.Medicines.Add(medicine);
			db.SaveChanges();
			return new Medicine
			{
				Id = medicine.Id,
				Name = medicine.Name,
				Illustration = medicine.Illustration,
				Ingredient = medicine.Ingredient,
				PresentationFormat = medicine.PresentationFormat,
				Point = medicine.Point,
				Using = medicine.Using,
				SpecialWarning = medicine.SpecialWarning,
				Quantity = medicine.Quantity,
				DateOfManufacture = medicine.DateOfManufacture,
				Expiry = medicine.Expiry,
				Status = medicine.Status,
				OriginId = medicine.OriginId,
				TypeOfId = medicine.TypeOfId,
				BrandId = medicine.BrandId,
				Priceid = medicine.Priceid,
			};
		}

		public Medicine UpdateMedicine(Medicine medicine)
		{
			db.Entry(medicine).State = EntityState.Modified;
			db.SaveChanges();

			return new Medicine
			{
				Id = medicine.Id,
				Name = medicine.Name,
				Illustration = medicine.Illustration,
				Ingredient = medicine.Ingredient,
				PresentationFormat = medicine.PresentationFormat,
				Point = medicine.Point,
				Using = medicine.Using,
				SpecialWarning = medicine.SpecialWarning,
				Quantity = medicine.Quantity,
				DateOfManufacture = medicine.DateOfManufacture,
				Expiry = medicine.Expiry,
				Status = medicine.Status,
				OriginId = medicine.OriginId,
				TypeOfId = medicine.TypeOfId,
				BrandId = medicine.BrandId,
				Priceid = medicine.Priceid,

			};
		}

		public void DeleteMedicine(int id)
		{
			db.Medicines.Remove(db.Medicines.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}
		//search 
		public List<Medicine> Search(string keyword)
		{
			return FindAll().Where(p => p.Name.Contains(keyword)).ToList();
		}

		public List<Medicine> SearchType(int madicineType)
		{
			return FindAll().Where(a => a.TypeOfId == madicineType).ToList();
		}
		//
	}
}
