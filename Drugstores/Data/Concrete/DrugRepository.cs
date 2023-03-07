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
    public class DrugRepository : IDrugRepository
    {
        static int id;
        public List<Drug> GetAll()
        {
            return DbContext.Drugs;
        }
        public Drug Get(int id)
        {
            return DbContext.Drugs.FirstOrDefault(d => d.Id == id);
        }
        public void Add(Drug drug)
        {

            id++;
            drug.Id = id;
            DbContext.Drugs.Add(drug);
        }
        public void Update(Drug drug)
        {
            var dbDrugs= DbContext.Drugs.FirstOrDefault(t => t.Id == t.Id);
            if (dbDrugs is not null)
            {
                dbDrugs.Price = drug.Price;
                dbDrugs.Count = drug.Count;
                dbDrugs.Drugstore = drug.Drugstore;
               
            }
        }
        public void Delete(Drug drug)
        {
            DbContext.Drugs.Remove(drug);
        }
    }
}
