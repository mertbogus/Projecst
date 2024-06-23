using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubCategory
    {
        [Key]
        public int SCategoryID { get; set; }
        public string SCategoryName { get; set; } 

        public string SCategoryDesc { get; set; }

        public int CategoryID { get; set; }
    }
}
