using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface ISectionDal : IGenericDal<Section>
    {
        public List<Section> GetByProjectId(int ProjectId);
        public Section GetById(int id);

    }
}
