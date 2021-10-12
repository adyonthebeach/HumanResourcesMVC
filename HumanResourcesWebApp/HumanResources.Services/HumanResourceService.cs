using HumanResources.DataModels;
using HumanResources.Repositories.Interfaces;
using HumanResources.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace HumanResources.Services
{
    public class HumanResourceService : IHumanResourceService
    {
        private readonly IHumanResourceRepository _humanResourceRepository;

        public HumanResourceService(IHumanResourceRepository humanResourceRepository)
        {
            _humanResourceRepository = humanResourceRepository;
        }

        public List<HumanResource> GetAllHumanResources()
        {
            return _humanResourceRepository.GetAllHumanResources();
        }

        public void Create(HumanResource humanResource)
        {
            _humanResourceRepository.Create(humanResource);
        }
    }
}
