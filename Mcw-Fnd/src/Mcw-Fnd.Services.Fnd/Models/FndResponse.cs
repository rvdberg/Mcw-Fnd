using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mcw_Fnd.Services.Fnd.Models
{
    public class FndResponse
    {
        public FndMetadata Metadata { get; set; }

        public List<FndObject> Objects { get; set; }

        public int TotaalAantalObjecten { get; set; }

        public FndPaging Paging { get; set; }
    }
}
