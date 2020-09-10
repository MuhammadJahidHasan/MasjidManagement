using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasjidManagement.Models
{
    public class SQLMusolliRepo : IMusolliRepo
    {

        private readonly AppDbContext context;

        public SQLMusolliRepo(AppDbContext context)
        {
            this.context = context;
        }
        public Musolli Add(Musolli musolli)
        {
            var maxId = context.Musollies.Max(e => e.Id);
            if (maxId <1)
                musolli.Id = 1;
            else
                musolli.Id = maxId + 1;

            context.Musollies.Add(musolli);
            context.SaveChanges();
            return musolli;
        }

        public Musolli Delete(int id)
        {
            Musolli musolli = context.Musollies.Find(id);
            if (musolli != null)
            {
                context.Musollies.Remove(musolli);
                
                context.SaveChanges();
            }
            return musolli;
        }

        public IEnumerable<Musolli> GetAllMusolli()
        {
            return context.Musollies;
        }

        public Musolli GetMusolli(int id)
        {
            return context.Musollies.Find(id);
        }

        public Musolli Update(Musolli musolliChanges)
        {
            var musolli = context.Musollies.Attach(musolliChanges);
            musolli.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return musolliChanges;
        }
    }
}
