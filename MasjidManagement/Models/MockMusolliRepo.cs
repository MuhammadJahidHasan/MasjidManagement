using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public class MockMusolliRepo : IMusolliRepo
    {
        private List<Musolli>  _musolliList;

        public MockMusolliRepo()
        {
            _musolliList = new List<Musolli>(){


                new Musolli() { Id=1,Name="Jahid",Department=Dept.Master_Bari},
                new Musolli() { Id=2,Name="Sharif",Department=Dept.Master_Bari},
                new Musolli() { Id=3,Name="Sakib",Department=Dept.Boro_Bari},
                new Musolli() { Id=4,Name="Ashik",Department=Dept.Akondo_Bari} 
            };
        }

        public Musolli Add(Musolli musolli)
        {
            if (musolli != null)
                musolli.Id = _musolliList.Max(e => e.Id) + 1;
            else
                musolli.Id = 1;
            _musolliList.Add(musolli);
            return musolli;
        }


        public Musolli Delete(int id)
        {
            Musolli musolli = _musolliList.FirstOrDefault(e => e.Id == id);

            if (musolli != null)
            {
                _musolliList.Remove(musolli);
            }
            return musolli;
        }


        public IEnumerable<Musolli> GetAllMusolli()
        {
            return _musolliList;
        }

        public Musolli GetMusolli(int id)
        {
            return _musolliList.FirstOrDefault(e => e.Id == id);
        }


        public Musolli Update(Musolli employeeChanges)
        {
            Musolli musolli = _musolliList.FirstOrDefault(e => e.Id == employeeChanges.Id);

            if (musolli != null)
            {
                musolli.Name = employeeChanges.Name;
                musolli.Department = employeeChanges.Department;
            }
            return musolli;
        }
    }
}
