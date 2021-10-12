using HumanResources.DataModels;
using System;

namespace HumanResources.DataModel.Builders
{
    public class RandomHumanResourceBuilder
    {
        public HumanResource Build()
        {
            var newHumanResource = new HumanResource()
            {
                FirstName = new RandomStringBuilder().SetMaxLength(50).Build(),
                LastName = new RandomStringBuilder().SetMaxLength(50).Build(),
                DateOfBirth = DateTime.Now,
                Department = new RandomStringBuilder().SetMaxLength(50).Build(),
                Email = new RandomStringBuilder().SetMaxLength(75).Build(),
                EmployeeNumber = (int)DateTime.Now.Ticks
            };

            return newHumanResource;
        }
    }
}
