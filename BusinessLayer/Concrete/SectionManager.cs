using BusinessLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SectionManager : ISectionService
    {
        private readonly EfSectionDal sectionDal;

        public SectionManager(EfSectionDal sectionDal)
        {
            this.sectionDal = sectionDal;
        }

        public Section GetById(int id)
        {
            return sectionDal.GetById(id);
        }

        public List<Section> GetByProjectId(int projectId)
        {
           return sectionDal.GetByProjectId(projectId);
        }

        public void TAdd(Section t)
        {
            sectionDal.Insert(t);
        }

        public void TDelete(Section t)
        {
            sectionDal.Delete(t);
        }

        public List<Section> TGetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Section t)
        {
            sectionDal.Update(t);
        }
    }
}
