using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public class Musolli
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Dept Department { get; set; }
        public List<AddMusolliAmount> ListAmount { get; set; }

    }
}
