using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mcw_Fnd.Services;
using Mcw_Fnd.Services.Fnd;
using Mcw_Fnd.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mcw_Fnd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRealEstateAgentService realEstateAgentService;

        public HomeController(IRealEstateAgentService realEstateAgentService)
        {
            this.realEstateAgentService = realEstateAgentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> Agents()
        {
            var agents = await realEstateAgentService.GetRealEstateAgentsForCityAsync("Amsterdam");
            var vm = new AgentsViewModel(agents);

            return View(vm);
        }

        [ResponseCache(Duration = 300, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> GardenAgents()
        {
            var gardenAgents = await realEstateAgentService.GetRealEstateAgentsForCityWithGardenAsync("Amsterdam");
            var vm = new GardenAgentsViewModel(gardenAgents);

            return View(vm);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
