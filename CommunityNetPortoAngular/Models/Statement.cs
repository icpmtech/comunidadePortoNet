using System.ComponentModel.DataAnnotations;

namespace CommunityNetPortoAngular.Models
{

    public class Statement
    {
        public int ID { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Url")]
        public string Link { get; set; }
        [Display(Name = "Nome da pessoa/entidade")]
        public string Name { get; set; }
        [Display(Name = "Rótulo")]
        public string Tag { get; set; }
        [Display(Name = "Publicado")]
        public bool? Publish { get; set; }

        public ResumeUser ResumeUser { get; set; }
    }
}