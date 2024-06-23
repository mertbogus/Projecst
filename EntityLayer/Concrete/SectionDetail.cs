using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SectionDetail
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
    }
}
