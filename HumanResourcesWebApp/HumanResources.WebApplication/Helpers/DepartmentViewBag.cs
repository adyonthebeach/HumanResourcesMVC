using HumanResources.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.WebApplication.Helpers
{
    public class DepartmentViewBag
    {
        public IEnumerable<string> GetDistinctList(List<HumanResource> resourceList)
        {
            return (from resource in resourceList
                    select resource.Department).Distinct();
        }
    }
}
