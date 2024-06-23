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
    public class EfSectionDetailDal : GenericRepository<SectionDetail>, ISectionDetailDal
    {

        public SectionDetail GetById(int id)
        {
            var context = new Context();
            return context.SectionDetail.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<SectionDetail> GetByProjectId(int ProjectId)
        {
            var context = new Context();
            return context.SectionDetail.Where(x => x.SectionId == ProjectId).ToList();
        }
    }
}
