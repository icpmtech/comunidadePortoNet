using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CommunityNetPortoAngular.Models
{
    public class Offer
    {
        public int ID { get; set; }
        [Display(Name = "Cargo")]
        public string Title { get; set; }
        [Display(Name = "Número de Referência")]
        public string NumberReference { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Display(Name = "Local de Trabalho")]
        public string LocalJob { get; set; }
        [Display(Name = "Tipo de contrato")]
        public string Type { get; set; }

        [Display(Name = "Link")]
        public string Link { get; set; }
        [Display(Name = "Imagem")]
        public string ImageUrl { get; set; }

        [Display(Name = "Activa")]
        public bool? Active { get; set; }

        public ResumeUser ResumeUser { get; set; }
    }
}