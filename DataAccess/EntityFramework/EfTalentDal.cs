﻿using DataAccess.Abstract;
using DataAccess.Concrete.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfTalentDal:GenericRepository<Talent>,ITalentDal
    {
    }
}