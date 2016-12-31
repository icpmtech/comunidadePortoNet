
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CommunityNetPortoAngular.Models
{


    public class ArticleUser
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        [Display(Name = "Nome de artigo")]
        public string Name { get; set; }
        [Display(Name = "Imagem de apresentação de artigo")]
        public string ImageURL { get; set; }
        [Display(Name = "Titulo do artigo")]
        public string Title { get; set; }
        [Display(Name = "Cabeçalho do artigo")]
        public string Header { get; set; }
        [Display(Name = "Resumo do artigo")]
        public string Summary { get; set; }

        [Display(Name = "Rodapé do artigo")]
        public string Footer { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        [Display(Name = "Corpo do artigo")]
        public string Content { get; set; }
        public string[] Links { get; set; }
        public string[] Images { get; set; }
        public TimeSpan CreationDate { get; set; }
        [Display(Name = "Data de criação do artigo")]
        public DateTime? CreationDate_ { get; set; }
        public double Rating_ { get; set; }
        public int Rating { get; set; }
        public double Total { get;  set; }
        public int Vote { get;  set; }
    }
    public class ArticleRating
    {
        public ArticleUser ArticleID { get; set; }
        public int ID { get; set; }
        public int Rating { get; set; }
        public int TotalRaters { get; set; }
        public double AverageRating { get; set; }
    }
}