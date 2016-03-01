using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.GetCurrentDatabaseSetting;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Configuration.DatabaseSetting.GetCurrentDatabaseSetting
{
    public class GetCurrentDatabaseSetting : IGetCurrentDatabaseSetting
    {
        public GetCurrentDatabaseSettingResponse execute()
        {
            return this
                .load()
                .Build_response();
        }

        private GetCurrentDatabaseSetting load()
        {
            if (response_Builder.has_errors) return this;
            entity = database_settings_repository
                .Entities
                .ToList()
                .DefaultIfEmpty(new DatabaseSettings { id = -1, connection_string = "" })
                .Aggregate((accumulator, projection) => accumulator == null || projection.id > accumulator.id ? projection : accumulator)
                ;
            return this;
        }

        private GetCurrentDatabaseSettingResponse Build_response()
        {
            if (response_Builder.has_errors) return response_Builder.build();
            
            Guard.IsNotNull(entity, "entity");
            
            response_Builder.set_response(new DatabaseSettingDetails
            {
                connection_string = entity.connection_string
            });

            return response_Builder.build();
        }

        public GetCurrentDatabaseSetting
                 (  IEntityRepository<DatabaseSettings> the_database_settings_repository ) {

            database_settings_repository  = Guard.IsNotNull( the_database_settings_repository ,"the_database_settings_repository ");
        }

        private readonly IEntityRepository<DatabaseSettings> database_settings_repository;
        private readonly ResponseBuilder<DatabaseSettingDetails,GetCurrentDatabaseSettingResponse> response_Builder=
            new ResponseBuilder<DatabaseSettingDetails, GetCurrentDatabaseSettingResponse>();
        private DatabaseSettings entity;
    }
}