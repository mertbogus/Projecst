using EntityLayer.Concrete;

namespace Projects.Models
{
    public class SectionModel
    {
        public int Id { get; set; }
        public int ProjectNewId { get; set; }
        public ProjectNew ProjectNew { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
    }
}
