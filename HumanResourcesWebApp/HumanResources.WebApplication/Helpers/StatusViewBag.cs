using HumanResources.DataModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.WebApplication.Helpers
{
    public class StatusViewBag
    {
        public IEnumerable<string> GetDistintList(List<HumanResource> resourceList)
        {
            return (from resource in resourceList
                    select resource.Status).Distinct();
        }

        public List<SelectListItem> GetStatusListItems(List<HumanResource> resourceList)
        {
            var distinctStatusList = GetDistintList(resourceList);
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
