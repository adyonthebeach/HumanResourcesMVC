using System;

namespace HumanResources.DataModel.Builders
{
    public class RandomStatusBuilder
    {
        private string _excludedStatus;
        public string Build()
        {
            Random random = new Random();

            var statusId = random.Next(1, 3);

            return GetStatusFromStatusId(statusId);
        }

        public RandomStatusBuilder ExcludeStatus(string statusToExclude)
        {
            _excludedStatus = statusToExclude;
            return this;
        }

        private string GetStatusFromStatusId(int statusId)
        {
            if(statusId == 1)
            {
                return "Approved" != _excludedStatus ? "Approved" : "Pending";
            }

            if(statusId == 2)
            {
                return "Pending" != _excludedStatus ? "Pending" : "Disabled";
            }

            return "Disabled" != _excludedStatus ? "Disabled" : "Approved";
        }
    }
}
