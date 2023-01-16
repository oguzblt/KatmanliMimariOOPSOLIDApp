using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage("Name is not null");
            RuleFor(x => x.DepartmentName).MinimumLength(3).WithMessage("Name is minimum 3 character");
            RuleFor(x => x.DepartmentName).MaximumLength(30).WithMessage("Name is maximum 30 character");
        }
    }
}
