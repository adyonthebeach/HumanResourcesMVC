using HumanResources.Services.Interfaces;
using HumanResources.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace HumanResources.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHumanResourceService _humanResourceService;

        public HomeController(ILogger<HomeController> logger,
            IHumanResourceService humanResourceService)
        {
            _logger = logger;
            _humanResourceService = humanResourceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List(string department, string resourceStatus, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var resourceList = _humanResourceService.GetAllHumanResources();

            ViewBag.Department = (from resource in resourceList
                                  select resource.Department).Distinct();

            ViewBag.ResourceStatus = (from resource in resourceList
                                  select resource.Status).Distinct();

            var filteredList = from resource in resourceList
                               orderby resource.FirstName, resource.LastName
                               where resource.Department == department || department == null || department == ""
                               where resource.Status == resourceStatus || resourceStatus == null || resourceStatus == ""
                               select resource;

            return View(filteredList.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
