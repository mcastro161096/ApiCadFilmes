using ApiCadFilmes.Domain.Models.Entities;
using ApiCadFilmes.Domain.Models.IServices;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCadFilmes.Domain.Models.Validator
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
      
        public FilmeValidator()
        {
            RuleFor(x => x.Nome).NotNull().WithMessage("Nome não pode ser nulo").NotEmpty().WithMessage("Nome não pode ser vazio");
            RuleFor(x => x.GeneroId).NotNull().WithMessage("O id é obrigatório").NotEmpty().WithMessage("O id não pode ser vazio");   
        }
    }
}
