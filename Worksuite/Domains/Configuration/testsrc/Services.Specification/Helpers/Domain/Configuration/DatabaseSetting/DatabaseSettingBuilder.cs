using System.Text;
using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.DatabaseSetting {

    /// <summary>
    ///     Builder for DatabaseSetting.
    /// </summary>
    public class DatabaseSettingBuilder
                    : IEntityBuilder<DatabaseSettings> {


        public DatabaseSettingBuilder connection_string
                                        ( string value )
        {

            entity.connection_string = value;
            return this;
        }
                    

        /// <summary>
        ///     Gets the entity.
        /// </summary>
        /// <value>
        ///     The entity.
        /// </value>
        public DatabaseSettings entity {

            get { return database_setting; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseSettingBuilder"/> class.
        /// </summary>
        /// <param name="the_database_setting">The the_employee.</param>
        public DatabaseSettingBuilder
                    ( DatabaseSettings the_database_setting ) {

                        database_setting = Guard.IsNotNull(the_database_setting, "the_database_setting");
        }

        private readonly DatabaseSettings database_setting;

    }
}