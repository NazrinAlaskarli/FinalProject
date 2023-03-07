﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstract
{
    public interface IDruggistRepository : IRepository<Druggist>
    {
        Druggist GetById(int id);
        Druggist GetByName(string name);
    }
}
