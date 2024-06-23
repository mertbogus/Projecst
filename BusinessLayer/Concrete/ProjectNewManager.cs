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
	public class ProjectNewManager : IProjectNew
	{
		private readonly IProjectNewDal projectDal;

		public ProjectNewManager(IProjectNewDal projectDal)
        {
			this.projectDal = projectDal;
		}

        public ProjectNew GetById(int id)
        {
            return projectDal.GetById(id);
        }

        public void TAdd(ProjectNew t)
		{
			projectDal.Insert(t);
		}

		public void TDelete(ProjectNew t)
		{
			projectDal.Delete(t);
		}

		public List<ProjectNew> TGetList()
		{
			return projectDal.GetList();
		}

		public void Update(ProjectNew t)
		{
			projectDal.Update(t);
		}
	}
}
