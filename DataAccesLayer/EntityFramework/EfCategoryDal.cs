using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using DataAccesLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public Category GetById(int id)
        {
            var context = new Context();
            return context.Categorys.Where(x => x.CategoryID == id).FirstOrDefault();
        }
    }
}
