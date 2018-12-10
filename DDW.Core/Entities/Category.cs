using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDW.Core.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = ("This field is required"))]
        [DisplayName("Category Name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0}'s length should be between {2} and {1}.")]
        public string CategoryName { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
