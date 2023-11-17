using FluentValidation;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Enums;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Validators
{
    public class AnimalValidator : AbstractValidator<AnimalDTO>
    {
        private readonly IRazaRepository _razaRepository;
        private readonly IAnimalRepository _animalRepository;
        public AnimalValidator(IRazaRepository razaRepository, IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
            _razaRepository = razaRepository;

            RuleFor(a => a.Nombre)
                .Must(BeUniqueName).WithMessage("Ya existe un animal con ese nombre.")
                .NotEmpty().WithMessage("El nombre del animal es obligatorio.");

            RuleFor(a => a.FechaNacimiento)
            .NotEmpty().WithMessage("Se requiere especificar una fecha de nacimiento.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("La fecha de nacimiento no puede ser en el futuro.");

            RuleFor(a => a.Precio)
                .GreaterThan(0).WithMessage("El precio del animal debe ser mayor a 0.");

            RuleFor(a => a.Estado)
                .Must(BeValidEstado).WithMessage("El estado del animal debe ser Activo o Inactivo");

            RuleFor(a => a.Sexo)
                .Must(BeValidSexo).WithMessage("El sexo del animal debe ser Macho o Hembra");

            RuleFor(a => a.RazaId)
                .NotNull().WithMessage("El animal debe tener una raza asociada")
                .Must(BeValidRazaId).WithMessage("El id de la raza no corresponde a una raza existente");
        }

        private bool BeValidRazaId(int razaId)
        {
            return _razaRepository.RazaExists(razaId);
        }

        private bool BeUniqueName(string name)
        {
            return !_animalRepository.AnimalExists(name);
        }

        private bool BeValidEstado(string estado)
        {
            return string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(estado, "Inactivo", StringComparison.OrdinalIgnoreCase);
        }

        private bool BeValidSexo(string sexo)
        {
            // Compare the Estado value ignoring case
            return string.Equals(sexo, "Macho", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(sexo, "Hembra", StringComparison.OrdinalIgnoreCase);
        }

    }
}
