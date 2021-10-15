using HumanResources.DataModels;
using System.Collections.Generic;

namespace HumanResources.Services.Interfaces
{
    public interface IHumanResourceService
    {
        HumanResource Create(HumanResource humanResource);
        int Delete(int employeeNumber);
        List<HumanResource> GetAllHumanResources();
        HumanResource GetHumanResource(int employeeNumber);
        HumanResource Update(HumanResource humanResource);
    }
}