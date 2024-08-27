using FluentValidation;
using VideoGamesCQRS.Data;

//Validation:1
namespace VideoGamesCQRS.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerCommandValidator()
        {
            RuleFor(v => v.Name)
             .NotEmpty()
             .MaximumLength(5);
        }
    }
}
