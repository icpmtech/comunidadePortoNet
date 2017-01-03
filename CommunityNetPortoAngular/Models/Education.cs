using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{
    public class Education
    {
        public int ID { get; set; }

        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Data")]
        public string Data { get; set; }
        public ResumeUser ResumeUser { get; set; }
    }
}