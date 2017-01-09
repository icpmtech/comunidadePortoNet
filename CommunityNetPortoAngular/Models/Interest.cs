using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{
    public class Interest
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public ResumeUser ResumeUser { get; set; }
    }
}