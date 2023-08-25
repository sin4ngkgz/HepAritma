using ETicaret.Model;
using FluentValidation;

namespace ETicaret.Api.Code.Validations
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(k => k.Email).EmailAddress().WithMessage("Hatalı email adresi girildi.");
            RuleFor(k => k.Password).Length(6,15).WithMessage("Şifre en fazla 15 en az 6 karakter olmalıdır.");

        }
    }
}
