using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public static class ModelBuilderExtensions
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musolli>().HasData(

              new Musolli
              {
                  Id = 1,
                  Name = "Jahid",
                  Department = Dept.Master_Bari
              }


              );


        }
    }
}
