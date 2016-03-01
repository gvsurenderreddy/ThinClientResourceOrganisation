using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.Help.Edit;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Configuration.Help.Edit
{
    public class GetUpdateHelpRequest
                 : IGetUpdateHelpRequest
    {
        public UpdateHelpRequest execute()
        {
            var help = repository
                .Entities
                .ToList()
                .DefaultIfEmpty(new HelpUrls() {location_url = string.Empty})
                .Last();
            return new UpdateHelpRequest()
            {
                location_url = help.location_url
            };
        }

        public GetUpdateHelpRequest(IEntityRepository<HelpUrls> _repository)
        {
            repository = Guard.IsNotNull(_repository, "_repository");
        }

        private readonly IEntityRepository<HelpUrls> repository;
    }
}