using System.Linq;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Configuration.Service.Configuration.DatabaseSettings.Edit;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Configuration.Service.Messages;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Sanitisation;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;
using WTS.WorkSuite.Library.EntityFramework.Contexts.TestConnections;

namespace WorkSuite.Configuration.Domain.Configuration.DatabaseSetting.Edit
{

    public class UpdateDatabaseSettings
                       : IUpdateDatabaseSettings
    {
        public UpdateDatabaseSettingsResponse execute
                                          (UpdateDatabaseSettingRequest the_request)
        {
            return this
                .set_request(the_request)
                .sanatise_request()
                .validate()
                .add()
                .commit()
                .build_response();

        }

        private UpdateDatabaseSettings set_request
                                       ( UpdateDatabaseSettingRequest the_request )
        {
            request = Guard.IsNotNull(the_request, "the_request");
            return this;
        }

        private UpdateDatabaseSettings sanatise_request()
        {
            if (response_builder.has_errors) return this;

            Guard.IsNotNull(request, "request");

            request=new UpdateDatabaseSettingRequest
            {
               connection_string = request.connection_string.normalise_for_persistence()
            };
            return this;
        }

        private UpdateDatabaseSettings validate()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(request, "request");

            var database_connection_test_response = database_connection_test.verify(request.connection_string);
            var field = validator.field("connection_string");
            field.is_madatory(request.connection_string, ErrorMessages.error_00_0032)
                .premise_holds(
                    validator.errors.Any() ||
                    database_connection_test_response.status !=
                    DatabaseConnectionTestResponse.FailedToEstablishConnection, ErrorMessages.error_00_0045);

            response_builder.add_errors(validator.errors);

            if (response_builder.has_errors)
            {
                response_builder.add_error(ErrorMessages.error_04_0001);
            }
            return this;
        }

        private UpdateDatabaseSettings add()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");
            repository.add(new DatabaseSettings
            {
                connection_string = request.connection_string
            });
            return this;
        }

        private UpdateDatabaseSettings commit()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");

            unit_of_work.Commit();
            response_builder.add_message(ErrorMessages.error_04_0013);

            return this;
        }

        private UpdateDatabaseSettingsResponse build_response()
        {
            return response_builder.build();
        }

        public UpdateDatabaseSettings(IEntityRepository<DatabaseSettings> _repository
                                     , IUnitOfWork _Unit_Of_Work
                                     , Validator _validator
                                    , ICanConnectToDatabase the_database_connection_test)
        {
            repository = Guard.IsNotNull(_repository, "_repository");
            unit_of_work = Guard.IsNotNull(_Unit_Of_Work, "_Unit_Of_Work");
            validator = Guard.IsNotNull(_validator, "_validator");
            database_connection_test = Guard.IsNotNull(the_database_connection_test, "the_database_connection_test");
        }

        private readonly IEntityRepository<DatabaseSettings> repository;
        private readonly IUnitOfWork unit_of_work;
        private readonly Validator validator;
        private readonly ICanConnectToDatabase database_connection_test;
        private readonly ResponseBuilder<UpdateDatabaseSettingsResponse> response_builder=
            new ResponseBuilder<UpdateDatabaseSettingsResponse>();
        private UpdateDatabaseSettingRequest request;
    }
}