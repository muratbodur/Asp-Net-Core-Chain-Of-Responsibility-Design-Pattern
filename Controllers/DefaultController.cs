using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
	public class DefaultController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index (CustomerProcessViewModel model)
		{
			Employee treasurer = new Treasurer();
			Employee managerAssitant = new ManagerAsistant();
			Employee manager = new Manager();
			Employee areaDirector = new AreaDirector();

			treasurer.SetNextApprover(managerAssitant);
			managerAssitant.SetNextApprover(manager);
			manager.SetNextApprover(areaDirector);

			treasurer.ProcessRequest(model);

			return View(model);
		}
	}
}
