using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.Dto.VillaNumber
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
    }
}
