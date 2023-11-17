using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using InfoBovinosAPI.Controllers;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBovinosAPI.Tests.Controller
{
    public class AnimalControllerTests
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly AnimalMapper _mapper;
        private readonly IValidator<AnimalDTO> _animalValidator;
        public AnimalControllerTests()
        {
            _animalRepository = A.Fake<IAnimalRepository>();
            _mapper = A.Fake<AnimalMapper>();
            _animalValidator = A.Fake<IValidator<AnimalDTO>>();
        }

        [Fact]
        public void AnimalController_GetAnimales_ReturnOk()
        {
            var controller = new AnimalController(_animalRepository, _mapper, _animalValidator);

            
            var animals = new List<Animal> { 
                new Animal
            {
                Id = 1,
                Nombre = "Bella",
                FechaNacimiento = new DateTime(2019, 5, 10),
                Sexo = Enums.SexoEnum.Hembra,
                Precio = 500,
                Estado = Enums.EstadoEnum.Activo,
                Comentarios = "Amigable y activa",
                RazaId = 1 
            },
                new Animal
            {
                Id = 2,
                Nombre = "Fea",
                FechaNacimiento = new DateTime(2019, 5, 10),
                Sexo = Enums.SexoEnum.Hembra,
                Precio = 500,
                Estado = Enums.EstadoEnum.Inactivo,
                Comentarios = "Amigable, pero no activa",
                RazaId = 2 
            },
            };
            var animalDTOs = animals.Select(animal => new AnimalDTO {
                Id = animal.Id,
                Nombre = animal.Nombre,
                FechaNacimiento = animal.FechaNacimiento,
                Sexo = animal.Sexo.ToString(),
                Precio = animal.Precio,
                Estado = animal.Estado.ToString(),
                Comentarios = animal.Comentarios,
                RazaId = animal.RazaId,
            }).ToList();

            A.CallTo(() => _animalRepository.GetAnimales()).Returns(animals); 

            var result = controller.GetAnimales();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void AnimalController_CreateAnimal_ReturnOk()
        {
            var controller = new AnimalController(_animalRepository, _mapper, _animalValidator);

            var fakeAnimalDTO = new AnimalDTO
            {
                Id = 1000,
                Nombre = "Malo",
                FechaNacimiento = new DateTime(2019, 5, 10),
                Sexo = "Macho",
                Precio = 500,
                Estado = "Inactivo",
                Comentarios = "Ni amigable ni activo",
                RazaId = 2
            };

            A.CallTo(() => _animalValidator.Validate(fakeAnimalDTO)).Returns(new FluentValidation.Results.ValidationResult()); 

            A.CallTo(() => _animalRepository.CreateAnimal(A<Animal>.Ignored)).Returns(true); 

            
            var result = controller.CreateAnimal(fakeAnimalDTO);

            
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
