using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectdal;

        public ProjectManager(IProjectDal projectDal)
        {
                _projectdal = projectDal;
        }
        public void TAdd(Project t)
        {
            _projectdal.Insert(t);
        }

        public void TDelete(Project t)
        {
            _projectdal.Delete(t);
        }

        public List<Project> TGetList()
        {
           return _projectdal.GetList();
        }

        public void Update(Project t)
        {
            _projectdal.Update(t);
        }
    }
}
