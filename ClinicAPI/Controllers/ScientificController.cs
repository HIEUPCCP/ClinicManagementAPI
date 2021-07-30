using ClinicAPI.Models;
using ClinicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Web_Api.Controllers
{
	[Route("api/scientific")]
	public class ScientificController : Controller
	{
		private ScientificEquipmentService scientific;

		public ScientificController(ScientificEquipmentService _scientific)
		{
			scientific = _scientific;
		}
		//findall
		[Produces("application/json")]
		[HttpGet("findall")]
		public IActionResult FindAll()
		{
			try
			{
			
				return Ok(scientific.FindAll());
			}
			catch
			{
				return BadRequest();
			}
		}
		//brand
		[Produces("application/json")]
		[HttpGet("brand")]
		public IActionResult Brand()
		{
			try
			{

				return Ok(scientific.Brand());
			}
			catch
			{
				return BadRequest();
			}
		}
		//origin
		[Produces("application/json")]
		[HttpGet("origin")]
		public IActionResult Origin()
		{
			try
			{

				return Ok(scientific.Orgin());
			}
			catch
			{
				return BadRequest();
			}
		}
		//type thiet bi
		[Produces("application/json")]
		[HttpGet("machineCategory")]
		public IActionResult MachineCategory()
		{
			try
			{

				return Ok(scientific.MachineCategory());
			}
			catch
			{
				return BadRequest();
			}
		}
		//type thuoc
		[Produces("application/json")]
		[HttpGet("typeofmedicine")]
		public IActionResult TypeOfMedicine()
		{
			try
			{

				return Ok(scientific.TypeOfMedicine());
			}
			catch
			{
				return BadRequest();
			}
		}
		//price
		[Produces("application/json")]
		[HttpGet("price")]
		public IActionResult Price()
		{
			try
			{

				return Ok(scientific.Price());
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
				return Ok(scientific.Search(keyword));
			}
			catch
			{
				return BadRequest();
			}
		}
		//search type
		[Produces("application/json")]
		[HttpGet("searchtype/{machinetype}")]
		public IActionResult SearchType(int machinetype)
		{
			try
			{
				return Ok(scientific.SearchType(machinetype));
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
				return Ok(scientific.Find(id));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete
		[HttpDelete("delete/{id}")]
		public IActionResult Delete(int id)
		{
			try
			{

				scientific.Delete(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		//create
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("createdtb")]
		public IActionResult Created([FromBody] ScientificEquipment scientificEquipment)
		{
			try
			{
				return Ok(scientific.Create(scientificEquipment));
			}
			catch
			{
				return BadRequest();
			}
		}

		//update
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("updatetb")]
		public IActionResult Update([FromBody] ScientificEquipment scientificEquipment)
		{
			try
			{

				return Ok(scientific.Update(scientificEquipment));
			}
			catch
			{
				return BadRequest();
			}
		}
		//add barand
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("addbrand")]
		public IActionResult AddBrand([FromBody] Brand brand)
		{
			try
			{

				return Ok(scientific.AddBrand(brand));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete brand
		[HttpDelete("deletebrand/{id}")]
		public IActionResult DeleteBrand(int id)
		{
			try
			{
				scientific.DeleteBrand(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}


		//add origin
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("addorigin")]
		public IActionResult AddOrigin([FromBody] Origin origin)
		{
			try
			{

				return Ok(scientific.AddOrigin(origin));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete origin
		[HttpDelete("deleteorigin/{id}")]
		public IActionResult DeleteOrigin(int id)
		{
			try
			{
				scientific.DeleteOrigin(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		//add addmachinecategory
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("addmachinecategory")]
		public IActionResult AddMachineCategory([FromBody] MachineCategory machineCategory)
		{
			try
			{

				return Ok(scientific.AddMachineCategory(machineCategory));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete deletemachinecategory
		[HttpDelete("deletemachinecategory/{id}")]
		public IActionResult DeleteMachineCategory(int id)
		{
			try
			{
				scientific.DeleteMachineCategory(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}

		//add addprice
		[Produces("application/json")]
		[Consumes("application/json")]
		[HttpPost("addprice")]
		public IActionResult AddPrice([FromBody] Price price)
		{
			try
			{

				return Ok(scientific.AddPrice(price));
			}
			catch
			{
				return BadRequest();
			}
		}
		//delete deleteprice
		[HttpDelete("deleteprice/{id}")]
		public IActionResult DeletePrice(int id)
		{
			try
			{
				scientific.DeletePrice(id);
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}




	}
}
