using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{
    public class Project
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Name { get; set; }
        public ResumeUser ResumeUser { get; set; }
    }
}