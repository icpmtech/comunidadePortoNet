using System;

namespace CommunityNetPortoAngular.Models
{
    public class EducationViewModel
    {
        public int? ID { get; set; }


        public string Title { get; set; }

        public string Description { get; set; }

        public string Data { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? Dob { get; set; }
    }
}