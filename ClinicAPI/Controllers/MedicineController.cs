using ClinicAPI.Models;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
	[Route("api/medicine")]
	public class MedicineController : Controller
	{
		private MedicineService medicineService;

		public MedicineController(MedicineService _medicineService)
		{
			medicineService = _medicineService;
		}
		//findall
		[Produces("application/json")]
		[HttpGet("findall")]
		public IActionResult FindAll()
		{
			try
			{

				return Ok(medicineService.FindAll());
			}
			catch
			{
				return BadRequest();
			}
		}
		//type thuoc
		[Produces("application/json")]
		[HttpGet("typemedicine")]
		public IActionResult TypeMedicine()
		{
			try
			{

				return Ok(medicineService.TypeMedicine());
			}
			catch
			{
				return BadRequest();
			}
		}
		//search

		[Produces("application/json")]
		[HttpGet("search/{keyword}")]
		public IActionResult Search(string keyword)
		{
			try
			{
				return Ok(medicineService.Search(keyword));
			}
			catch
			{
				return BadRequest();
			}
		}
		//search type
		[Produces("application/json")]
		[HttpGet("searchtype/{madicinetype}")]
		public IActionResult SearchType(int madicinetype)
		{
			try
			{
				return Ok(medicineService.SearchType(madicinetype));
			}
			catch
			{
				return BadRequest();
			}
		}
		//find
		[Produces("application/json")]
		[HttpGet("find/{id}")]
		public IActionResult Find(int id)
		{
			try
			{
				return Ok(medicineService.Find(id));
			}
			catch
			{
				return BadRequest();
			}
		}
		//create medicine
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("addmedicine")]
		public IActionResult AddMedicine([FromBody] Medicine medicine)
		{
			try
			{
				return Ok(medicineService.AddMedicine(medicine));
			}
			catch
			{
				return BadRequest();
			}
		}

		//update medicine
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("updatemedicine")]
		public IActionResult UpdateMedicine([FromBody] Medicine medicine)
		{
			try
			{

				return Ok(medicineService.UpdateMedicine(medicine));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete medicine
		[HttpDelete("deletemedicine/{id}")]
		public IActionResult DeleteMedicine(int id)
		{
			try
			{

				medicineService.DeleteMedicine(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		//add type medicine
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("addmedicinetype")]
		public IActionResult AddMedicineType([FromBody] TypeOfMedicine typeOfMedicine)
		{
			try
			{
				return Ok(medicineService.AddTypeMedicine(typeOfMedicine));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete type medicine
		[HttpDelete("deletemedicinetype/{id}")]
		public IActionResult DeleteMedicineType(int id)
		{
			try
			{

				medicineService.DeleteTypeMedicine(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
