using HumanResources.DataModels;
using HumanResources.Services.Interfaces;
using HumanResources.WebApplication.Helpers;
using HumanResources.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly int _pageSize;

        public HomeController(ILogger<HomeController> logger,
            IHumanResourceService humanResourceService,
            IOptions<AccreditSettings> accreditSettings)
        {
            _logger = logger;
            _humanResourceService = humanResourceService;
            _pageSize = accreditSettings.Value.TotalResultsPerPage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List(string department, string resourceStatus, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = _pageSize;
            var resourceList = _humanResourceService.GetAllHumanResources();

            ViewBag.Department = GetDistinctListOfDepartments(resourceList);
            ViewBag.ResourceStatus = GetDistintListOfResourceStatus(resourceList);

            IEnumerable<HumanResource> filteredList = GetFilteredListOfResources(department, resourceStatus, resourceList);

            return View(filteredList.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Add()
        {
            var resourceList = _humanResourceService.GetAllHumanResources();
            ViewBag.Status = GetViewBagStatusList(resourceList);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(HumanResource humanResource)
        {
            _humanResourceService.Create(humanResource);
            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var resourceList = _humanResourceService.GetAllHumanResources();
            var resource = resourceList.FirstOrDefault(resource => resource.EmployeeNumber == id);
            ViewBag.Status = GetViewBagStatusList(resourceList);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(HumanResource humanResource)
        {
            _humanResourceService.Update(humanResource);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var resourceList = _humanResourceService.GetAllHumanResources();
            var resource = resourceList.FirstOrDefault(resource => resource.EmployeeNumber == id);
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
        private IEnumerable<HumanResource> GetFilteredListOfResources(string department, string resourceStatus, List<HumanResource> resourceList)
        {
            return from resource in resourceList
                   orderby resource.FirstName, resource.LastName
                   where resource.Department == department || department == null || department == ""
                   where resource.Status == resourceStatus || resourceStatus == null || resourceStatus == ""
                   select resource;
        }

        private IEnumerable<string> GetDistintListOfResourceStatus(List<HumanResource> resourceList)
        {
            return (from resource in resourceList
                    select resource.Status).Distinct();
        }

        private IEnumerable<string> GetDistinctListOfDepartments(List<HumanResource> resourceList)
        {
            return (from resource in resourceList
                    select resource.Department).Distinct();
        }

        private List<SelectListItem> GetViewBagStatusList(List<HumanResource> resourceList)
        {
            var distinctStatusList = GetDistintListOfResourceStatus(resourceList);
            return ListOfResourceStatusSelectListItems(distinctStatusList);
        }

        private List<SelectListItem> ListOfResourceStatusSelectListItems(IEnumerable<string> distinctStatusList)
        {
            List<SelectListItem> selectListOfResourceStatus = new List<SelectListItem>();
            foreach (string status in distinctStatusList)
            {
                selectListOfResourceStatus.Add(
                    new SelectListItem
                    {
                        Value = status,
                        Text = status
                    });
            }
            return selectListOfResourceStatus;
        }
    }
}
