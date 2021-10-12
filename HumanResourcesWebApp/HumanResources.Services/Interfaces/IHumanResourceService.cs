using HumanResources.DataModels;
using System.Collections.Generic;

namespace HumanResources.Services.Interfaces
{
    public interface IHumanResourceService
    {
        List<HumanResource> GetAllHumanResources();
    }
}