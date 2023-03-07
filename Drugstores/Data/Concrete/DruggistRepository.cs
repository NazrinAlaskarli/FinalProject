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
    public class DruggistRepository : IDruggistRepository
    {
        static int id;
        public List<Druggist> GetAll()
        {
            return DbContext.Druggists;
        }
        public Druggist Get(int id)
        {
            return DbContext.Druggists.FirstOrDefault(d => d.Id == id);
        }
        public Druggist GetByName(string name)
        {
            return DbContext.Druggists.FirstOrDefault(d => d.Name.ToLower() == name.ToLower());
        }
        public Druggist GetById(int id)
        {
            return DbContext.Druggists.FirstOrDefault(d => d.Id == id);
        }
        public void Add(Druggist druggist)
        {
            id++;
            druggist.Id = id;
            DbContext.Druggists.Add(druggist);
        }
        public void Update(Druggist druggist)
        {
            var dbDruggists = DbContext.Druggists.FirstOrDefault(t => t.Id == t.Id);
            if (dbDruggists is not null)
            {
                dbDruggists.Surname = druggist.Surname;
                dbDruggists.Age = druggist.Age;
                dbDruggists.Experience = druggist.Experience;
                dbDruggists.Drugstore = druggist.Drugstore;

            }
        }
        public void Delete(Druggist druggist)
        {
            DbContext.Druggists.Remove(druggist);
        }
    }
}
