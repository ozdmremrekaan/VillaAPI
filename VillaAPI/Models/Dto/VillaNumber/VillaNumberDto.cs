using System.ComponentModel.DataAnnotations;
using VillaAPI.Models.Dto.Villa;

namespace VillaAPI.Models.Dto.VillaNumber
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaId { get; set; }
        public VillaDto Villa { get; set; }
        public string SpecialDetails { get; set; }

    }
}
