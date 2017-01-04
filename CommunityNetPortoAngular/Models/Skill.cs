namespace CommunityNetPortoAngular.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ResumeUser ResumeUser { get; set; }
    }
}