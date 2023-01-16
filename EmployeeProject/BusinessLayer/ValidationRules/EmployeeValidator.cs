using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.EmployeeName).NotEmpty().WithMessage("Name is not null");
            RuleFor(x => x.isActive).NotEmpty().WithMessage("isActive is not null");
            RuleFor(x => x.EmployeeAge).NotNull().WithMessage("Age is not null");
        }
    }
}
