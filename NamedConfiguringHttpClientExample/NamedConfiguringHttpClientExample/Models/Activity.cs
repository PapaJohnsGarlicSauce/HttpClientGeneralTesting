namespace NamedConfiguringHttpClientExample.Models
{
    public sealed class Activity
    {
        public string Description { get; set; }

        public float Accessibility { get; set; }

        public ActivityType Type { get; set; }

        public int Participants { get; set; }

        public float Price { get; set; }

        public long Key { get; set; }
    }
}
