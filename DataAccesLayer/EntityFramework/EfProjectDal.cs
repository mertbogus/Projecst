using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfProjectNewDal : GenericRepository<ProjectNew>, IProjectNewDal
    {

        public EfProjectNewDal()
        {
        }
        public ProjectNew GetById(int id)
        {
            var context = new Context();
            return context.ProjectNew.Include(x =>x.Category).Include(x => x.Sections).ThenInclude(x => x.SectionDetails).Where(x =>x.Id ==id).FirstOrDefault();
        }
    }
}
