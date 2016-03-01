using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.StaticContent.Edit;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Configuration.StaticContent.Edit
{
    public class GetUpdateStaticContentRequest 
                     : IGetUpdateStaticContentRequest
    {
        public UpdateStaticContentRequest execute()
        {
            var static_content = repository
                .Entities
                .ToList()
                .DefaultIfEmpty(new StaticContents{location_url = string.Empty})
                .Last();
            
            return new UpdateStaticContentRequest
            {
               location_url = static_content.location_url,
            };
        }

        public GetUpdateStaticContentRequest(IEntityRepository<StaticContents> _repository )
        {
            repository = Guard.IsNotNull(_repository, "_repository");
        }

        private readonly IEntityRepository<StaticContents> repository;
    }
}