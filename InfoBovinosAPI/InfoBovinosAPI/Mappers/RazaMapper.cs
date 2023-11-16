﻿using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Mappers
{
    public class RazaMapper
    {
        public RazaDTO RazaToDTO(Raza raza)
        {
            return new RazaDTO
            {
                RazaId = raza.RazaId,
                Nombre = raza.Nombre,
            };
        }
    }
}
