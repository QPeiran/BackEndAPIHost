using System.ComponentModel.DataAnnotations;

namespace BackEndAPIHost.DTOs
{
    public class CommandUpdateDTO
    {
        [Required]
        [MaxLength(250)] //add such annotation attributes will return api call a 400 error if client did not provide a proper input; returning 500 if without annotations 
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}