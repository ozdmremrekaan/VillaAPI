﻿using System.ComponentModel.DataAnnotations;

namespace VillaAPI.Models.Dto.VillaNumber
{
    public class VillaNumberCreateDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
