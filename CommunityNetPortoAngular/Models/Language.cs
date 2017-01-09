using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{

    public class Language
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        public string Value { get; set; }
        public ResumeUser ResumeUser { get; set; }
    }
}