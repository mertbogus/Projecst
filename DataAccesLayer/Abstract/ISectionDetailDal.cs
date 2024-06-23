using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface ISectionDetailDal : IGenericDal<SectionDetail>
    {
        public List<SectionDetail> GetByProjectId(int ProjectId);
        public SectionDetail GetById(int id);

    }
}
