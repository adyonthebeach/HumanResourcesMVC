using HumanResources.DataModels;
using System.Collections.Generic;

namespace HumanResources.Repositories.Interfaces
{
    public interface IHumanResourceRepository
    {
        List<HumanResource> GetAllHumanResources();
    }
}