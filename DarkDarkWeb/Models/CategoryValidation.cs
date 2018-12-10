using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDW.Core.Entities;
using DDW.DataAccess.SQL;
using FluentValidation;

namespace DarkDarkWeb.Models
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public DataContext db = new DataContext();
        public CategoryValidation()
        {
            RuleFor(x => x.CategoryName).Must(BeUniqueCategory).WithMessage("This category already exists");
        }

        private bool BeUniqueCategory(string category)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryName == category) == null;
        }
    }
}