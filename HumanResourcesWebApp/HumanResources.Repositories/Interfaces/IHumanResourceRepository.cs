using HumanResources.DataModels;
using System.Collections.Generic;

namespace HumanResources.Repositories.Interfaces
{
    public interface IHumanResourceRepository
    {
        void Create(HumanResource humanResource);
        List<HumanResource> GetAllHumanResources();
    }
}