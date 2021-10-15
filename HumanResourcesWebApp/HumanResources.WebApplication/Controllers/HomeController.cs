using HumanResources.DataModels;
using HumanResources.Services.Interfaces;
using HumanResources.WebApplication.Helpers;
using HumanResources.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using X.PagedList;

namespace HumanResources.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHumanResourceService _humanResourceService;
        private readonly int _totalResultsPerPage;
        private readonly ResourceList _resourceList;
        private readonly DepartmentViewBag _departmentViewBag;
        private readonly StatusViewBag _statusViewBag;

        public HomeController(ILogger<HomeController> logger,
            IHumanResourceService humanResourceService,
            IOptions<AccreditSettings> accreditSettings)
        {
            _logger = logger;
            _humanResourceService = humanResourceService;
            _totalResultsPerPage = accreditSettings.Value.TotalResultsPerPage;
            _resourceList = new ResourceList();
            _departmentViewBag = new DepartmentViewBag();
            _statusViewBag = new StatusViewBag();
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List(string department, string resourceStatus, int? page)
        {
            var resourceList = _humanResourceService.GetAllHumanResources();

            ViewBag.Department = _departmentViewBag.GetDistinctList(resourceList);
            ViewBag.ResourceStatus = _statusViewBag.GetDistintList(resourceList);

            IEnumerable<HumanResource> filteredList = _resourceList.Filter(department, resourceStatus, resourceList);

            var pageNumber = page ?? 1;
            return View(filteredList.ToPagedList(pageNumber, _totalResultsPerPage));
        }

        public IActionResult Add()
        {
            var resourceList = _humanResourceService.GetAllHumanResources();
            ViewBag.Status = _statusViewBag.GetStatusListItems(resourceList);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(HumanResource humanResource)
        {
            if(!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            _humanResourceService.Create(humanResource);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var resourceList = _humanResourceService.GetAllHumanResources();
            var resource = resourceList.FirstOrDefault(resource => resource.EmployeeNumber == id);
            ViewBag.Status = _statusViewBag.GetStatusListItems(resourceList);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HumanResource humanResource)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }
            _humanResourceService.Update(humanResource);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var resource = _humanResourceService.GetHumanResource(id);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(HumanResource humanResource)
        {
            _humanResourceService.Delete(humanResource.EmployeeNumber);
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
