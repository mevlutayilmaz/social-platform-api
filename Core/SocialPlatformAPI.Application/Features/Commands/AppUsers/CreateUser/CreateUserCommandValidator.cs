using FluentValidation;

namespace SocialPlatformAPI.Application.Features.Commands.AppUsers.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("Username cannot be empty!")
                .MinimumLength(4)
                .WithMessage("Username must be at least 4 characters long!")
                .MaximumLength(20)
                .WithMessage("Username cannot exceed 20 characters!")
                .Matches("^[a-zA-Z0-9]*$")
                .WithMessage("Username can only contain letters and numbers!");

            RuleFor(u => u.NameSurname)
                .NotEmpty()
                .WithMessage("NameSurname cannot be empty!")
                .MinimumLength(4)
                .WithMessage("NameSurname must be at least 4 characters long!")
                .MaximumLength(50)
                .WithMessage("NameSurname cannot exceed 50 characters!")
                .Matches("^[a-zA-Z ]*$")
                .WithMessage("NameSurname can only contain letters and spaces!");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty!")
                .MaximumLength(50)
                .WithMessage("Password cannot exceed 50 characters!")
                .Equal(u => u.PasswordConfirm)
                .WithMessage("Passwords do not match!");

            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email cannot be empty!")
                .EmailAddress()
                .WithMessage("Invalid email format!")
                .MaximumLength(100)
                .WithMessage("Email cannot exceed 100 characters!");
        }
    }
}
