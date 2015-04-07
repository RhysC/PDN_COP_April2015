using FluentValidation;

namespace SimplerWay.Models
{
    public class CreateEmployee
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(create => create.Name)
                .NotEmpty()
                .WithMessage("Employees must have names");
            RuleFor(create => create.Email)
                .NotEmpty()
                .WithMessage("Employees must have email addresses");
        }
    }
}