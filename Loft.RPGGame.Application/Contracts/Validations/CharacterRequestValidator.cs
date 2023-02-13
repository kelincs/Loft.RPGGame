using FluentValidation;
using Loft.RPGGame.Application.Contracts.Request;

namespace Loft.RPGGame.Application.Contracts.Validations
{
    public class CharacterRequestValidator : AbstractValidator<CharacterRequest>
    {
        public CharacterRequestValidator() 
        {
            //Name - MaxLength: 15, Regex: Accepts only letters and underscore
            RuleFor(c => c.Name)
                .MaximumLength(15)
                .WithMessage("O nome não pode ter mais de 15 caracteres.")
                .Matches(@"^[A-Za-z_]+$")
                .WithMessage("O nome deve ser composto apenas de letras e underline (_).");           
            
        }  
    }
}
