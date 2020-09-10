using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.ViewModels
{
    public class ViewEditAmount
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
