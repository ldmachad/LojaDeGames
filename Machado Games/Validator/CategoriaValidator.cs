using FluentValidation;
using Machado_Games.Model;

namespace Machado_Games.Validator 
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {   
            RuleFor(t => t.Tipo)
                    .NotEmpty()
                    .MaximumLength(250);
        }
    }
}