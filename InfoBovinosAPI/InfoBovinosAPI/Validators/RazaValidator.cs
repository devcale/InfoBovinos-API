using FluentValidation;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Validators
{
    public class RazaValidator : AbstractValidator<RazaDTO>
    {
        private readonly IRazaRepository _razaRepository;
        public RazaValidator(IRazaRepository razaRepository)
        {
            _razaRepository = razaRepository;

            RuleFor(a => a.Nombre)
                .Must(BeUniqueName).WithMessage("Ya existe un animal con ese nombre.")
                .NotEmpty().WithMessage("El nombre del animal es obligatorio.");
        }

        private bool BeUniqueName(string name)
        {
            return !_razaRepository.RazaExists(name);
        }
    }
}
