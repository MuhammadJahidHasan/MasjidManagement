using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public interface IMusolliRepo
    {

        Musolli GetMusolli(int id);
        IEnumerable<Musolli> GetAllMusolli();
        Musolli Add(Musolli musolli);
        //Musolli Update(Musolli employeeChanges);
        Musolli Delete(int id);
        Musolli Update(Musolli musolli);
    }
}
