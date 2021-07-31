using Clinic_Web_Api.Entities;
using ClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Services
{
	public class ScientificEquipmentServicelmpl : ScientificEquipmentService
	{
		private DatabaseContext db;

		public ScientificEquipmentServicelmpl(DatabaseContext _db)
		{
			db = _db;
		}
		
		//findall
		public List<ScientificEquipment> FindAll()
		{
			return db.ScientificEquipments.Select(s => new ScientificEquipment
			{
				Id = s.Id,
				Name = s.Name,
				Illustration = s.Illustration,
				InventedYear = s.InventedYear,
				Description = s.Description,
				Status = s.Status,
				Quantity = s.Quantity,
				BrandId = s.BrandId,
				OriginId = s.OriginId,
				MachineCategoryId = s.MachineCategoryId,
				Priceid = s.Priceid

			}).ToList();
		}
		//find
		public ScientificEquipment Find(int id)
		{
			return db.ScientificEquipments.Where(p => p.Id == id).Select(s => new ScientificEquipment
			{
				Id = s.Id,
				Name = s.Name,
				Illustration = s.Illustration,
				InventedYear = s.InventedYear,
				Description = s.Description,
				Status = s.Status,
				Quantity = s.Quantity,
				BrandId = s.BrandId,
				OriginId = s.OriginId,
				MachineCategoryId = s.MachineCategoryId,
				Priceid = s.Priceid,


			}).FirstOrDefault();
		}


		//combobox

		public List<Brand> Brand()
		{
			return db.Brands.Select(b => new Brand
			{
				Id=b.Id,
				Brand1=b.Brand1,
			
			}).ToList();
		}
		public List<MachineCategory> MachineCategory()
		{
			return db.MachineCategories.Select(m => new MachineCategory
			{
				Id = m.Id,
				Name=m.Name

			}).ToList();
		}

		public List<Origin> Orgin()
		{
			return db.Origins.Select(m => new Origin
			{
				Id = m.Id,
				Origin1 = m.Origin1

			}).ToList();
		}

		public List<Price> Price()
		{
			return db.Prices.Select(m => new Price
			{
				Id = m.Id,
				Price1 = m.Price1,
				Date=m.Date

			}).ToList();
		}

		public List<TypeOfMedicine> TypeOfMedicine()
		{
			return db.TypeOfMedicines.Select(m => new TypeOfMedicine
			{
				Id = m.Id,
				Category = m.Category

			}).ToList();
		}

		//search
		public List<ScientificEquipment> Search(string keyword)
		{
			return FindAll().Where(p => p.Name.Contains(keyword)).ToList();
		}

		public List<ScientificEquipment> SearchType(int machineType)
		{
			return FindAll().Where(a => a.MachineCategoryId == machineType).ToList();
		}
		//delete
		public void Delete(int id)
		{
			db.ScientificEquipments.Remove(db.ScientificEquipments.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}
		//create thiet bi
		public ScientificEquipmentInfo Create(ScientificEquipment scientific)
		{
			db.ScientificEquipments.Add(scientific);
			db.SaveChanges();
			return new ScientificEquipmentInfo
			{
				Id=scientific.Id,
				Name = scientific.Name,
				Illustration = scientific.Illustration,
				InventedYear = scientific.InventedYear,
				Description = scientific.Description,
				Status = scientific.Status,
				Quantity = scientific.Quantity,
				BrandId = scientific.BrandId,
				OriginId = scientific.OriginId,
				MachineCategoryId = scientific.MachineCategoryId,
				Priceid = scientific.Priceid

			};
		}
		//update thiet bi
		public ScientificEquipmentInfo Update(ScientificEquipment scientific)
		{
			db.Entry(scientific).State = EntityState.Modified;
			db.SaveChanges();

			return new ScientificEquipmentInfo
			{
				Id=scientific.Id,
				Name = scientific.Name,
				Illustration = scientific.Illustration,
				InventedYear = scientific.InventedYear,
				Description = scientific.Description,
				Status = scientific.Status,
				Quantity = scientific.Quantity,
				BrandId = scientific.BrandId,
				OriginId = scientific.OriginId,
				MachineCategoryId = scientific.MachineCategoryId,
				Priceid = scientific.Priceid

			};
		}
		//add+delete barand
		public Brand AddBrand(Brand brand)
		{
			db.Brands.Add(brand);
			db.SaveChanges();
			return new Brand
			{
				Brand1=brand.Brand1
			};
		}

		public void DeleteBrand(int id)
		{
			db.Brands.Remove(db.Brands.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}
		//add+delete origin
		public Origin AddOrigin(Origin origin)
		{
			db.Origins.Add(origin);
			db.SaveChanges();
			return new Origin
			{
				Origin1 = origin.Origin1
			};
		}

		public void DeleteOrigin(int id)
		{
			db.Origins.Remove(db.Origins.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}
		//add+delete machineCategory
		public MachineCategory AddMachineCategory(MachineCategory machineCategory)
		{
			db.MachineCategories.Add(machineCategory);
			db.SaveChanges();
			return new MachineCategory
			{
				Name=machineCategory.Name
			};
		}

		public void DeleteMachineCategory(int id)
		{
			db.MachineCategories.Remove(db.MachineCategories.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}
		//add+delete price
		public Price AddPrice(Price price)
		{
			db.Prices.Add(price);
			db.SaveChanges();
			return new Price
			{
				Price1=price.Price1,
				Date=price.Date
			};
		}

		public void DeletePrice(int id)
		{
			db.Prices.Remove(db.Prices.Find(id));
			db.SaveChanges();
			Debug.WriteLine("id:" + id);
		}

		//
	}
}
