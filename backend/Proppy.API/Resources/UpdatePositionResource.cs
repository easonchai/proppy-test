using System.ComponentModel.DataAnnotations;

namespace Proppy.API.Resources 
{
    public class UpdatePositionResource
    {
        [Required]
        [MaxLength(20)]
        public string Description {get; set;}
    }
}