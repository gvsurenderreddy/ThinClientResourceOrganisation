using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.Entity;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.Help
{
    public class HelpUrlHelper
                 : EnityHelper<HelpUrls, int, HelpUrlBuilder, FakeHelpUrlRepository> { }
}