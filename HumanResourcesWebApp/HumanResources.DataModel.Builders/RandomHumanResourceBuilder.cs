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
                FirstName = new RandomStringBuilder().SetMaxLength(100).Build(),
                LastName = new RandomStringBuilder().SetMaxLength(100).Build(),
                DateOfBirth = DateTime.Now,
                Department = new RandomStringBuilder().SetMaxLength(100).Build(),
                Email = new RandomStringBuilder().SetMaxLength(200).Build(),
                Status = new RandomStatusBuilder().Build()
            };

            return newHumanResource;
        }
    }
}
