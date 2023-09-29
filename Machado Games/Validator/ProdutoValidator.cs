using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Machado_Games.Model;

namespace Machado_Games.Validator
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                    .NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(100);

            RuleFor(p => p.Descricao)
                    .NotEmpty()
                    .MinimumLength(10)
                    .MaximumLength(1000);

            RuleFor(p => p.Console)
                   .NotEmpty();

            RuleFor(p => p.DataLancamento)
                   .NotEmpty();

            RuleFor(p => p.Preco)
                   .NotNull()
                   .GreaterThan(0)
                   .PrecisionScale(20, 2, false);
        }
    }
}
