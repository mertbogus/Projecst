using EntityLayer.Concrete;

namespace Projects.Models
{
    public class SectionDetailModel
    {
        public int Id { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
    }
}
