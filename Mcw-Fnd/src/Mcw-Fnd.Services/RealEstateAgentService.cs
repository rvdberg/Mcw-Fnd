using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mcw_Fnd.Services.Fnd;
using Mcw_Fnd.Services.Fnd.Models;
using Mcw_Fnd.Services.Models;

namespace Mcw_Fnd.Services
{
    public interface IRealEstateAgentService
    {
        Task<IList<RealEstateAgent>> GetRealEstateAgentsForCityAsync(string cityName);
        Task<IList<RealEstateAgent>> GetRealEstateAgentsForCityWithGardenAsync(string cityName);
    }

    public class RealEstateAgentService : IRealEstateAgentService
    {
        private readonly IFndService fndService;

        public RealEstateAgentService(IFndService fndService)
        {
            this.fndService = fndService;
        }

        public async Task<IList<RealEstateAgent>> GetRealEstateAgentsForCityAsync(string cityName)
        {
            var objects = await fndService.FindObjectsFromCity(cityName);

            var agents = GetRealEstateAgentsFromObjects(objects);

            return agents;
        }

        public async Task<IList<RealEstateAgent>> GetRealEstateAgentsForCityWithGardenAsync(string cityName)
        {
            var objects = await fndService.FindObjectsFromCityWithGarden(cityName);

            var agents = GetRealEstateAgentsFromObjects(objects);

            return agents;
        }

        private static IList<RealEstateAgent> GetRealEstateAgentsFromObjects(IEnumerable<FndObject> objects)
        {
            var groupedObjects = objects.GroupBy(x => x.MakelaarId);

            return (from groupedObject in groupedObjects
                    let amountOfObjects = groupedObject.Count()
                    let firstObject = groupedObject.First()
                    select new RealEstateAgent
                    {
                        Id = groupedObject.Key,
                        Name = firstObject.MakelaarNaam,
                        AmountOfHousesForSale = amountOfObjects
                    }).ToList();
        }
    }
}
