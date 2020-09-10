using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.View_Models
{
    public class ViewAddAmount
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int   Amount { get; set; }
    }
}
