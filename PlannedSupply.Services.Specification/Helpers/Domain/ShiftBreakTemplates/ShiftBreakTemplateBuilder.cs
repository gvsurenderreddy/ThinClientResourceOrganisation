using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.Breaks;
using WTS.WorkSuite.PlannedSupply.BreakTemplates;

namespace WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.BreakTemplates
{
    /// <summary>
    ///     Builder for shift breakk template
    /// </summary>
    public class BreakTemplateBuilder
                    : IEntityBuilder<BreakTemplate>
    {
        /// <summary>
        ///     Returns the shift breakk template.
        /// </summary>
        public BreakTemplate entity
        {
            get { return _break_template; }
        }

        /// <summary>
        ///     A template name for a shift breakk template can be set.
        /// </summary>
        /// <param name="the_value">
        ///     The value of the shift breakk template
        /// </param>
        /// <returns>
        ///     Returns the builder itself so that this method can be uses as part of fluent interface.
        /// </returns>
        public BreakTemplateBuilder template_name(string the_value)
        {
            _break_template.template_name = the_value;

            return this;
        }

        /// <summary>
        ///     Is hidden status for a shift breakk template can be set.
        /// </summary>
        /// <param name="the_value">
        ///     Determines whether the shift breakk template is hidden or not.
        /// </param>
        /// <returns>
        ///     Returns the builder itself so that this method can be uses as part of fluent interface.
        /// </returns>
        public BreakTemplateBuilder is_hidden(bool the_value)
        {
            _break_template.is_hidden = the_value;

            return this;
        }

        /// <summary>
        ///     Breakk to be added.
        /// </summary>
        /// <param name="the_value"></param>
        /// <returns></returns>
        public BreakTemplateBuilder add_break(Break the_value)
        {
            _break_template.all_breaks.Add(the_value);

            return this;
        }

        /// <summary>
        ///     Initialises a new instance of 'BreakTemplateBuilder'
        /// </summary>
        /// <param name="the_break_template">
        ///     With the shift breakk template
        /// </param>
        public BreakTemplateBuilder(BreakTemplate the_break_template)
        {
            Guard.IsNotNull(the_break_template, "the_break_template");

            _break_template = new BreakTemplate
            {
                id = the_break_template.id,
                template_name = the_break_template.template_name
            };
        }

        private BreakTemplate _break_template;
    }
}