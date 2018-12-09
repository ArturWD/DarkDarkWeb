using DDW.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDW.Core.ViewModels
{
    public class ResourceCategoriesListViewt
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Resource> Resources { get; set; }
    }
}
