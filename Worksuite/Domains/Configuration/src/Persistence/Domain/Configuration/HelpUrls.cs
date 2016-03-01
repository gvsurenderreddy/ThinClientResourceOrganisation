using WorkSuite.Library.Persistence;

namespace WorkSuite.Configuration.Persistence.Domain.Configuration
{
    public class HelpUrls
                 : BaseEntity<int>
    {
        public virtual string location_url { get; set; } 
    }
}