using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mcw_Fnd.Services.Fnd.Models
{
    public class FndObject
    {
        public Guid Id { get; set; }

        public string Woonplaats { get; set; }

        public int MakelaarId { get; set; }
        public string MakelaarNaam { get; set; }


    }
}
