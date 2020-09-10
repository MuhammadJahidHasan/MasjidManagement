using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public class MultipleViewModel
    {
        public Musolli Musolli { get; set; }
        public IEnumerable<AddMusolliAmount> AddMusolliAmount { get; set; }
    }
}
