﻿using MagicVilla_Web.Models.Dto.Villa;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.Dto.VillaNumber
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDto Villa { get; set; }
    }
    
}
