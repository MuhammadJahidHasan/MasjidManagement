using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public class AddMusolliAmount
    {
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int Amount { get; set; }
        public Musolli Musolli { get; set; }
    }
}

