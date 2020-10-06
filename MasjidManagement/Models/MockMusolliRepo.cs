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


                 new Musolli() { Id=1,Name="Jahid",Department=Dept.Master_Bari,
                ListAmount=new List<AddMusolliAmount>(){
                new AddMusolliAmount(){Date="10 Jan 2020", Amount=200 },
                new AddMusolliAmount(){Date="15 Aug 2019", Amount=500 }

                }

                 },


                new Musolli() { Id=2,Name="Sharif",Department=Dept.Master_Bari,
                ListAmount=new List<AddMusolliAmount>(){
                new AddMusolliAmount(){Date="20 Feb 1920", Amount=720 },
                 new AddMusolliAmount(){Date="22 Mar 1999", Amount=999 }
                } 
                
                },


                new Musolli() { Id=3,Name="Sakib",Department=Dept.Boro_Bari,
                ListAmount=new List<AddMusolliAmount>(){
                new AddMusolliAmount(){Date="20 Apr 2012", Amount=720 },
                 new AddMusolliAmount(){Date="22 May 2010", Amount=999 }
                }

                },
                new Musolli() { Id=2,Name="Sharif",Department=Dept.Master_Bari,
                ListAmount=new List<AddMusolliAmount>(){
                new AddMusolliAmount(){Date="20 Jun 2015", Amount=720 },
                 new AddMusolliAmount(){Date="22 Sep 2018", Amount=999 }
                }

                }
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

        public Musolli AddAmount(AddMusolliAmount addmusolliamount, int id)
        {
            Musolli musolli = _musolliList.FirstOrDefault(e => e.Id == id);
            musolli.ListAmount.Add(addmusolliamount);
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

        public Musolli UpdateAmount(Musolli employeeChanges, int id)
        {
            Musolli musolli = _musolliList.FirstOrDefault(e => e.Id == employeeChanges.Id);

            if (musolli != null)
            {
                musolli.ListAmount[id].Date = employeeChanges.ListAmount[id].Date;
                musolli.ListAmount[id].Amount = employeeChanges.ListAmount[id].Amount;
            }
            return musolli;
        }


    }
}
