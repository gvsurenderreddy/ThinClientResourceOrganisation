using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.Help;
using WorkSuite.Configuration.Service.Configuration.Help.GetCurrentHelpUrl;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Configuration.Help.GetCurrentHelpUrl
{
    public class GetCurrentHelpUrl : IGetCurrentHelpUrl
    {
        public GetCurrentHelpUrlResponse execute()
        {
            return this
                .load()
                .build_response();
        }

        private GetCurrentHelpUrl load()
        {
            entity = repository
                .Entities
                .ToList()
                .DefaultIfEmpty(new HelpUrls {id = -1, location_url = ""})
                .Aggregate(
                    (accumulator, projection) =>
                        accumulator == null || projection.id > accumulator.id ? projection : accumulator)
                ;
            return this;
        }

        private GetCurrentHelpUrlResponse build_response()
        {
            if (response_Builder.has_errors) return response_Builder.build();
            Guard.IsNotNull(entity, "entity");
            response_Builder.set_response(
                new HelpUrlDetails()
                {
                    location_url = entity.location_url
                }
                );
            return response_Builder.build();
        }

        public GetCurrentHelpUrl(IEntityRepository<HelpUrls> _repository)
        {
            repository = Guard.IsNotNull(_repository, "_repository");
        }

        private readonly IEntityRepository<HelpUrls> repository;
        private readonly ResponseBuilder<HelpUrlDetails,GetCurrentHelpUrlResponse> response_Builder
               =new ResponseBuilder<HelpUrlDetails, GetCurrentHelpUrlResponse>();
        private HelpUrls entity;
    }
}