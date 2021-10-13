using System;

namespace HumanResources.DataModel.Builders
{
    public class RandomStatusBuilder
    {
        public string Build()
        {
            Random random = new Random();

            var statusId = random.Next(1, 3);

            return GetStatusFromStatusId(statusId);
        }

        private string GetStatusFromStatusId(int statusId)
        {
            if(statusId == 1)
            {
                return "Approved";
            }

            if(statusId == 2)
            {
                return "Pending";
            }

            return "Disabled";
        }
    }
}
