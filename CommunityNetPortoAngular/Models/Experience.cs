using System;
using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{
    public class Experience
    {
        public int ID { get; set; }
        [Display(Name = "Especialidade")]
        public string TagLine { get; set; }
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Data")]
        public string Data { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? Dob { get; set; }

        public ResumeUser ResumeUser { get; set; }
    }
}