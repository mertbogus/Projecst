using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;

namespace Projects.ViewComponents.Default
{
    internal class projectManager : ProjectManager
    {
        public projectManager(IProjectDal projectDal) : base(projectDal)
        {
        }
    }
}