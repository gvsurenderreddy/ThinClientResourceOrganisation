using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.Entity;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent {

    public class StaticContentHelper
                    : EnityHelper<StaticContents, int, StaticContentBuilder,FakeStaticContentRepository> { }
}
