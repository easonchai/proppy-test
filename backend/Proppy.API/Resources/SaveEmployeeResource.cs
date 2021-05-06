using System;
using System.ComponentModel.DataAnnotations;

namespace Proppy.API.Resources
{
    public class SaveEmployeeResource
    {
        [Required]
        [MaxLength(30)]
        public string Name {get; set;}

        [Required]
        [MaxLength(20)]
        public string Phone_No {get; set;}

        [Required]
        [MaxLength(30)]
        public string Email{get; set;}

        [Required]
        [MaxLength(1)]
        public string Gender {get; set;}

        [Required]
        [MaxLength(1)]
        public string Position_Code {get; set;}

        [Required]
        public DateTime DOB {get; set;} 

        [Required]
        [MaxLength(16)]
        public int Salary {get; set;}

        [Required]
        [MaxLength(1000)]
        public string Remarks {get; set;}

        [Required]
        [MaxLength(100)]
        public string Photo {get; set;}
    }
}