using HumanResources.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace HumanResources.WebApplication.Helpers
{
    public class ResourceList
    {
        public IEnumerable<HumanResource> Filter(string department, string resourceStatus, List<HumanResource> resourceList)
        {
            return from resource in resourceList
                   orderby resource.FirstName, resource.LastName
                   where resource.Department == department || department == null || department == ""
                   where resource.Status == resourceStatus || resourceStatus == null || resourceStatus == ""
                   select resource;
        }
    }
}
