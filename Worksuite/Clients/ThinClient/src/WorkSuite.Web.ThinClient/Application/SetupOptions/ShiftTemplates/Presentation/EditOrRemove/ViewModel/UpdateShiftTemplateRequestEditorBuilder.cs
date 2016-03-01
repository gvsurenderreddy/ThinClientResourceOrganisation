using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.Fields.LookupField;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetAllEligibleForShiftTemplate;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Edit;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.ShiftDetails.ShiftTemplateSummary;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.ViewModel
{
    public class UpdateShiftTemplateRequestEditorBuilder
    {
        public IsAViewElement build(ShiftTemplateIdentity the_shift_template_identity)
        {
            return build_update_request_editor(the_shift_template_identity);
        }

        private IsAViewElement build_update_request_editor( ShiftTemplateIdentity shift_template_identity )
        {
            // Improve: we are working at two level of abstraction with these two methods, get_shift_template_update_request returns 
            //          a service layer request where get_break_templates returns a collection of LookupValues which is a presentation
            //          layer concept.  This does not feel right.

            var update_request = get_shift_template_update_request(shift_template_identity);
            var break_templates = get_break_templates(shift_template_identity);

            return _editor_builder
                            .set_lookup_values(m => m.break_template_id, break_templates)
                            .build(update_request)
                            ;
        }

        private UpdateShiftTemplateRequest get_shift_template_update_request( ShiftTemplateIdentity shift_tempate_identity )
        {
            // Improve: We are not handling errors at this point we need to correct this once we have worked out the common error handling strategy

            return _shiftTemplateUpdateRequest
                        .execute(shift_tempate_identity)
                        .result;
        }


        private IEnumerable<LookupValue> get_break_templates( ShiftTemplateIdentity shift_tempate_identity )
        {
            return get_break_templates_eligible_for_shift_template
                        .execute(shift_tempate_identity)
                        .result
                        .Select(bt => new LookupValue
                        {
                            id = bt.template_id.ToString(CultureInfo.InvariantCulture),
                            description = bt.template_name,
                        });

        }

        public UpdateShiftTemplateRequestEditorBuilder(IGetShiftTemplateUpdateRequest the_shift_template_update_request,
                                                       IGetDetailsOfBreakTemplatesEligibleForShiftTemplate the_get_break_templates_eligible_for_shift_template,
                                                       EditorBuilder<UpdateShiftTemplateRequest> the_editor_builder
                                                      )
        {
            _shiftTemplateUpdateRequest = Guard.IsNotNull(the_shift_template_update_request, "the_shift_template_update_request");
            get_break_templates_eligible_for_shift_template = Guard.IsNotNull(the_get_break_templates_eligible_for_shift_template, "the_get_break_templates_eligible_for_shift_template");
            _editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");            
        }

        private readonly IGetShiftTemplateUpdateRequest _shiftTemplateUpdateRequest;
        private IGetDetailsOfBreakTemplatesEligibleForShiftTemplate get_break_templates_eligible_for_shift_template;
        private readonly EditorBuilder<UpdateShiftTemplateRequest> _editor_builder;
    }
}