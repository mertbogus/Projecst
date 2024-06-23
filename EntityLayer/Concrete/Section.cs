using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Section
    {
        public int Id { get; set; }
        public int ProjectNewId { get; set; }
        public ProjectNew ProjectNew { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public List<SectionDetail> SectionDetails { get; set; }
    }
}
