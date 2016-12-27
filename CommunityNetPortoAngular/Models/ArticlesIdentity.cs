
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CommunityNetPortoAngular.Models
{
    

    public class ArticleUser 
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Content { get; set; }
        public string[] Links { get; set; }
        public string[] Images { get; set; }
        public TimeSpan CreationDate { get; set; }
        public int Rating { get; set; }

    }
}