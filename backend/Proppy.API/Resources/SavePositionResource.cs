using System.ComponentModel.DataAnnotations;

namespace Proppy.API.Resources 
{
    public class SavePositionResource
    {
        [Required]
        [MaxLength(2)]
        public string Code {get; set;}

        [Required]
        [MaxLength(20)]
        public string Description {get; set;}
    }
}