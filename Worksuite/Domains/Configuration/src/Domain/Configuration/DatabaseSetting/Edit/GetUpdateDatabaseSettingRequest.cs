using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Domain.Configuration.DatabaseSetting.Edit
{
    public class GetUpdateDatabaseSettingRequest:IGetUpdateRequest
    {
        public UpdateDatabaseSettingRequest execute()
        {
            var database_setting = repository
                .Entities
                .ToList()
                .DefaultIfEmpty( new DatabaseSettings { connection_string = string.Empty } )
                .Last();

            return new UpdateDatabaseSettingRequest()
            {
               connection_string = database_setting.connection_string,
            };
        }

        public GetUpdateDatabaseSettingRequest(IEntityRepository<DatabaseSettings> _repository)
        {
            repository = Guard.IsNotNull(_repository, "_repository");
        }
        private readonly IEntityRepository<DatabaseSettings> repository;
    }
}