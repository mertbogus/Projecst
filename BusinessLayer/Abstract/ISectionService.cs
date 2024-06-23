﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ISectionService : IGenericService<Section>
	{
		public List<Section> GetByProjectId(int projectId);
		public Section GetById(int id);
	}
}
