using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DDW.Core.Entities.Validation
{
    public class CategoryValidator: AbstractValidator<Category>
    {
        //private DataContext db = new DataContext();
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).Must(BeUniqueCategory).WithMessage("This category already exists");
        }

        private bool BeUniqueCategory(string category)
        {
            return true;
            //return db.Categories.FirstOrDefault(x => x.Cat == category) == null;
        }
    }
}
