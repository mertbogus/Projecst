using EntityLayer.Concrete;

namespace Projects.Models
{
    public class ProjectNewListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public AppUser Author { get; set; }
        public string? AuhtorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool OnlyLogin { get; set; }
        public List<Section> Sections { get; set; }
    }
}
