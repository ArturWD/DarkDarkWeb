using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDW.Core.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        [Required(ErrorMessage = ("This field is required"))]
        [MaxLength(150)]
        [DisplayName("Resource Name")]
        public string ResourceName { get; set; }
        [Required(ErrorMessage = ("This field is required"))]
        //[RegularExpression(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Wrong format")]
        public string URL { get; set; }
        public DateTime RefreshDate { get; set; }
        public string Description { get; set; }
        public string Contacts { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        [Required(ErrorMessage = ("This field is required"))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
