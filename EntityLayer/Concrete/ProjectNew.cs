using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class ProjectNew
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
       
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool OnlyLogin { get; set; }
        public List<Section> Sections { get; set; }
    }
}
