using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mcw_Fnd.Services.Models;

namespace Mcw_Fnd.Web.ViewModels
{
    public class GardenAgentsViewModel
    {
        private readonly IList<RealEstateAgent> agents;

        public GardenAgentsViewModel(IList<RealEstateAgent> agents)
        {
            if (agents == null)
                throw new ArgumentNullException();

            this.agents = agents;
        }

        public IEnumerable<RealEstateAgent> TopGardenAgentsOrdered
            => agents.OrderByDescending(x => x.AmountOfHousesForSale).Take(10);
    }
}
