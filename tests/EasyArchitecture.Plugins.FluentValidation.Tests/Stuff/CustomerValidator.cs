using EasyArchitecture.Plugins.Tests.Validation.Stuff;
using FluentValidation;

namespace EasyArchitecture.Plugins.FluentValidation.Tests.Stuff
{
    public class DogValidator : AbstractValidator<Mouse>
    {
        public DogValidator()
        {
            RuleFor(d => d.Age).LessThan(10).WithMessage("There's no dog so old");
        }
    }
}