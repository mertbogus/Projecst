using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SectionDetailManager : ISectionDetailService
    {
        private readonly ISectionDetailDal sectionDal;

        public SectionDetailManager(ISectionDetailDal sectionDal)
        {
            this.sectionDal = sectionDal;
        }

        public SectionDetail GetById(int id)
        {
           return sectionDal.GetById(id);
        }

        public List<SectionDetail> GetByProjectId(int projectId)
        {
            return sectionDal.GetByProjectId(projectId);
        }

        public void TAdd(SectionDetail t)
        {
            sectionDal.Insert(t);
        }

        public void TDelete(SectionDetail t)
        {
            sectionDal.Delete(t);
        }

        public List<SectionDetail> TGetList()
        {
            return sectionDal.GetList();
        }

        public void Update(SectionDetail t)
        {
            sectionDal.Update(t);
        }
    }
}
