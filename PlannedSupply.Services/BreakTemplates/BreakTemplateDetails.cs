using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes.DefinitionList;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates
{
    public class BreakTemplateDetails
                        : BreakTemplateIdentity
    {
        /// <summary>
        ///     Gets or sets shift break template name.
        /// </summary>
        public string template_name { get; set; }

        /// <summary>
        ///     Gets or sets total of all shift break durations for a shift break template.
        ///         This is will be used to display a shift break template in a lister.
        /// </summary>
        public string total_break_duration { get; set; }

        /// <summary>
        ///     Gets or sets all break details in a specific format for a shift break template.
        ///         This is will be used to display a shift break template in a lister.
        /// </summary>
        public IEnumerable<DefinitionListElement> break_details { get; set; }

        /// <summary>
        ///     Gets or sets  the list of all shift breaks belongs to a shift break template.
        /// </summary>
        public IEnumerable<BreakDetails> all_breaks_details { get; set; }

        /// <summary>
        ///     Gets or sets  the list of all shift templates associated to a shift break template.
        ///         This is will be used to display associated shift templates in shift break templates lister.
        /// </summary>
        public IEnumerable<DefinitionListElement> all_associated_shift_templates { get; set; }

        /// <summary>
        ///     Gets or sets  the hidden property of a shift break template.
        /// </summary>
        public bool is_hidden { get; set; }

        /// <summary>
        ///     Gets or sets  the hidden property of a shift break template for display purpose.
        /// </summary>
        public string hidden_status { get; set; }
    }
}