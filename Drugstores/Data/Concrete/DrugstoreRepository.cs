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
    public class DrugstoreRepository : IDrugstoreRepository
    {
        static int id;
        public List<Drugstore> GetAll()
        {
            return DbContext.Drugstores;
        }
        public Drugstore Get(int id)
        {
            return DbContext.Drugstores.FirstOrDefault(d => d.Id == id);
        }
        public void Add(Drugstore drugstore)
        {
            id++;
            drugstore.Id = id;
            DbContext.Drugstores.Add(drugstore);
        }
        public void Update(Drugstore drugstore)
        {
            var dbDrugstores = DbContext.Drugstores.FirstOrDefault(d => d.Id == d.Id);
            if (dbDrugstores is not null)
            {
                dbDrugstores.Address = drugstore.Address;
                dbDrugstores.ContactNumber = drugstore.ContactNumber;
                dbDrugstores.Email = drugstore.Email;
                dbDrugstores.Druggists = drugstore.Druggists;
                dbDrugstores.Owner= drugstore.Owner;    
                dbDrugstores.Drugs = drugstore.Drugs;

            }
        }
        public void Delete(Drugstore drugstore)
        {
            DbContext.Drugstores.Remove(drugstore);
        }
        public bool IsDuplicatedEmail(string email)
        {
            return DbContext.Drugstores.Any(e => e.Email == email);
        }
    }

}
