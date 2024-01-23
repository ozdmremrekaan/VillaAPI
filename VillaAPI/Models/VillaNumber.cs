using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VillaAPI.Models
{
    public class VillaNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        public int VillaId { get; set; }
        public Villa Villa { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
