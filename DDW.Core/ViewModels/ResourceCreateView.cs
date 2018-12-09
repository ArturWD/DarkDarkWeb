using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDW.Core.ViewModels
{
    public class ResourceCreateView
    {
        [Required(ErrorMessage = ("This field is required"))]
        [MaxLength(150)]
        [DisplayName("Resource Name")]
        public string ResourceName { get; set; }
        [Required(ErrorMessage = ("This field is required"))]
        public string URL { get; set; }
        public string Description { get; set; }
        public string Contacts { get; set; }
        public string Keywords { get; set; }
        [Required(ErrorMessage = ("This field is required"))]
        public int CategoryId { get; set; }
    }
}
