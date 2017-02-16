using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mcw_Fnd.Services.Models;

namespace Mcw_Fnd.Web.ViewModels
{
    public class AgentsViewModel
    {
        private readonly IList<RealEstateAgent> agents;

        public AgentsViewModel(IList<RealEstateAgent> agents)
        {
            if (agents == null)
                throw new ArgumentNullException();

            this.agents = agents;
        }

        public IEnumerable<RealEstateAgent> TopAgentsOrdered
            => agents.OrderByDescending(x => x.AmountOfHousesForSale).Take(10);
    }
}
