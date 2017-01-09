using System;

namespace CommunityNetPortoAngular.Controllers
{
    public class ExperienceViewModel
    {
        public int? ID { get; set; }
        public string TagLine { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? Dob { get; set; }
    }
}