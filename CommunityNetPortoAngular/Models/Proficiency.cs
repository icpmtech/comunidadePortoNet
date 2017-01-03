using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{
    public class Proficiency
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Valor")]
        public string Value { get; set; }
        public ResumeUser ResumeUser { get; set; }
    }
}