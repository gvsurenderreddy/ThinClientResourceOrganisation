using System;
using System.Linq;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate
{

    /// <summary>
    ///     Common question that may be asked about shift templates, that are answered via the repository.
    /// </summary>
    /// <remarks>
    ///     We have put this in the domain rathern than the persistence assembly because we are going to
    /// be using template identities as parameters.  Identities are defined in the service assembly which
    /// the persistence assembly does not reference so this seamed like the logical palce.  Plus the methods
    /// do contain bussiness logic.
    /// </remarks>
    public static class ShiftTemplateRepositoryExtensions {

        /// <summary>
        ///     Returns true there are no other templates in the repository that have the same name.
        /// We ignore culture and case when comparing the name
        /// </summary>
        /// <param name="repository">
        ///     Repository that holds the shift templates that we check. 
        /// </param>
        /// <param name="request"> 
        ///     Request with the name to check for and the id of the shift template that has the name. It is
        /// excluded from the search.
        /// </param>
        /// <returns>
        ///     true if there is a template with the same name
        /// </returns>
        public static bool name_is_unique
                            ( this IEntityRepository<ShiftTemplates.ShiftTemplate> repository 
                            , ShiftTemplateNameIsUniqueRequest request ) {

            Guard.IsNotNull( repository, "repository" );

            return !repository
                        .Entities
                        .Where( st => st.id != request.shift_template_id )
                        .Any( st => request.name.Equals( st.shift_title, StringComparison.InvariantCultureIgnoreCase ))
                        ;
        }
    }

    public class ShiftTemplateNameIsUniqueRequest
    {

        public int shift_template_id { get; private set; }
        public string name { get; private set; }


        public ShiftTemplateNameIsUniqueRequest
                (int shift_template_id
                , string name)
        {

            this.shift_template_id = shift_template_id;
            this.name = name;
        }
    }

}
