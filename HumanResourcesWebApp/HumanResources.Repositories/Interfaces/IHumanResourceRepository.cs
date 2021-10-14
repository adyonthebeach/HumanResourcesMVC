using HumanResources.DataModels;
using System.Collections.Generic;

namespace HumanResources.Repositories.Interfaces
{
    public interface IHumanResourceRepository
    {
        HumanResource Create(HumanResource humanResource);
        int Delete(int employeeNumber);
        List<HumanResource> GetAllHumanResources();
        HumanResource GetHumanResource(int employeeNumber);
        HumanResource Update(HumanResource humanResource);
    }
}