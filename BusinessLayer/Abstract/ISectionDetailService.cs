using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISectionDetailService : IGenericService<SectionDetail>
	{
		public List<SectionDetail> GetByProjectId(int projectId);
		public SectionDetail GetById(int id);
	}
}
