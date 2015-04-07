using FluentValidation;

namespace SimplerWay.Models
{
    public class UpdateEmployeeName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateEmployeeNameValidator : AbstractValidator<UpdateEmployeeName>
    {
        public UpdateEmployeeNameValidator()
        {
            RuleFor(create => create.Name)
                .NotEmpty()
                .WithMessage("Employees must have names");
        }
    }
}