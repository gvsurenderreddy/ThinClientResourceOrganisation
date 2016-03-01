using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.StaticContent;
using WorkSuite.Configuration.Service.Configuration.StaticContent.GetCurrentStaticContent;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Configuration.StaticContent.GetCurrentStaticContent
{
    public class GetCurrentStaticContent:IGetCurrentStaticContent
    {
        public GetCurrentStaticContentResponse execute()
        {

            return this
                    .load()
                    .build_response()
                    ;
        }

        private GetCurrentStaticContent load()
        {
            if (response_builder.has_errors) return this;

          
           entity = repository
                        .Entities
                        .ToList()
                        .DefaultIfEmpty(new StaticContents { id = -1, location_url = "" })
                        .Aggregate((accumulator, projection) => accumulator == null || projection.id > accumulator.id ? projection : accumulator)
                        ;                    
            return this;
        }

        private GetCurrentStaticContentResponse build_response()
        {
            if (response_builder.has_errors) return response_builder.build();

            Guard.IsNotNull( entity, "entity" );

            response_builder.set_response(

                new StaticContentDetails {
                    location_url = entity.location_url,
                }
            );
            
            return response_builder.build();
        }

        public GetCurrentStaticContent(IEntityRepository<StaticContents> _repository)
        {
            repository = Guard.IsNotNull(_repository, "the_content_static_repository ");
        }

        private readonly IEntityRepository<StaticContents> repository;
        private readonly ResponseBuilder<StaticContentDetails,GetCurrentStaticContentResponse> response_builder
            = new ResponseBuilder<StaticContentDetails, GetCurrentStaticContentResponse>();

        private StaticContents entity;
    }
}