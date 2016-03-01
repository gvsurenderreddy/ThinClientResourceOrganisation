using WorkSuite.Configuration.Persistence.Domain.Configuration;
using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Configuration.StaticContent {

    /// <summary>
    ///     Builder for StaticContent.
    /// </summary>
    public class StaticContentBuilder
                    : IEntityBuilder<StaticContents> {


        public StaticContentBuilder location_url
                                        ( string value )
        {

            entity.location_url = value;
            return this;
        }
                    

        /// <summary>
        ///     Gets the entity.
        /// </summary>
        /// <value>
        ///     The entity.
        /// </value>
        public StaticContents entity {

            get { return static_content; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticContentBuilder"/> class.
        /// </summary>
        /// <param name="the_static_content">The the_employee.</param>
        public StaticContentBuilder
                    ( StaticContents the_static_content ) {

                        static_content = Guard.IsNotNull(the_static_content , "the_static_content");
        }

        private readonly StaticContents static_content;

    }
}