using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help
{
    public class HelpUrlBuilder
                 : IEntityBuilder<HelpUrls>
    {
        public HelpUrlBuilder location_url
                                 (string value)
        {
            entity.location_url = value;
            return this;
        }

        public HelpUrls entity
        {
            get { return help_url; }
        }

        public HelpUrlBuilder(HelpUrls _help_url)
        {
            help_url = Guard.IsNotNull(_help_url, "help_url");
        }

        private readonly HelpUrls help_url;
    }
}