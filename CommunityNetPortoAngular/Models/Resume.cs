
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CommunityNetPortoAngular.Models
{


    public class ResumeUser
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }
        [Display(Name = "Telefone")]
        public string Phone { get; set; }
        [Display(Name = "Especialidade")]
        public string TagLine { get; set; }
        [Display(Name = "Portofolio WebSite")]
        public string PortfolioSite { get; set; }
        [Display(Name = "Linkedin")]
        public string Linkedin { get; set; }
        [Display(Name = "GitHub")]
        public string GitHub { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Imagem de apresentação")]
        public string ImageURL { get; set; }
        [Display(Name = "Resumo de carreira")]
        public string CareerProfile { get; set; }
        [Display(Name = "Perfil de Carreira")]
        public string Profile { get; set; }
        [Display(Name = "Experiências")]
        public List<Experience> Experiences { get; set; }
        [Display(Name = "Projetos")]
        public List<Project> Projects { get; set; }
        [Display(Name = "Skills")]
        public List<Skill> Skills { get; set; }
        public List<Proficiency> Proficiencies { get; set; }
        public List<Education> Educations { get; set; }
        public List<Interest> Languages { get; set; }
        public List<Interest> Interests { get; set; }
        public double Rating_ { get; set; }
        public int Rating { get; set; }
        public double Total { get;  set; }
        public int Vote { get;  set; }
    }
}