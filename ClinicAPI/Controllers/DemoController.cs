using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAPI.Controllers
{
	public class DemoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
