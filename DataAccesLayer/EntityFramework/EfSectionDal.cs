using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EfSectionDal : GenericRepository<Section>, ISectionDal
    {
        public Section GetById(int id)
        {

            var context = new Context();
            return context.Section.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Section> GetByProjectId(int ProjectId)
        {
            var context = new Context();
            return context.Section.Where(x => x.ProjectNewId == ProjectId).ToList();
        }
    }
}
