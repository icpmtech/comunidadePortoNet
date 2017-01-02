using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{


    public class SuggestionViewModel
    {
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Endereço de E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Messagem")]
        [Required]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Tipo de Messagem")]
        public string TypeMessage { get; set; }
    }
}
