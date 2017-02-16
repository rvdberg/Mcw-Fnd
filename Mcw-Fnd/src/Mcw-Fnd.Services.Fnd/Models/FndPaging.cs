using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mcw_Fnd.Services.Fnd.Models
{
    public class FndPaging
    {
        public int AantalPaginas { get; set; }
        public int HuidigePagina { get; set; }
        public string VolgendeUrl { get; set; }
        public string VorigeUrl { get; set; }
    }
}
