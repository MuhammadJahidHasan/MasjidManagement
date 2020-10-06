using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public class AddMusolliAmount
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}

