using Core.Entities;
using Data.Contexts;
using Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete
{
    public class OwnerRepository : IOwnerRepository
    {
        static int id;
        public List<Owner> GetAll()
        {

            return DbContext.Owners;
        }
        public Owner Get(int id)
        {
            return DbContext.Owners.FirstOrDefault(o => o.Id == id);
        }
        public void Create(Owner owner)
        {

        }
        public void Add(Owner owner)
        {
            id++;
            owner.Id = id;
            DbContext.Owners.Add(owner);
        }
        public void Update(Owner owner)
        {
            var dbOwners = DbContext.Owners.FirstOrDefault(o => o.Id == owner.Id);
            if (dbOwners is not null)
            {
                dbOwners.Surname = owner.Surname;
                dbOwners.Drugstores = owner.Drugstores;
               

            }
        }
        public void Delete(Owner owner)
        {
            DbContext.Owners.Remove(owner);
        }
    }
}
