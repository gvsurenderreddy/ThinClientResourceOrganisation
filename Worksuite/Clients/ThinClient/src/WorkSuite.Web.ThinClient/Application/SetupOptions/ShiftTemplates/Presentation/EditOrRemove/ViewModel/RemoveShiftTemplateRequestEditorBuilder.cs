using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.ViewModel
{
    public class RemoveShiftTemplateRequestEditorBuilder
    {
        public IsAViewElement build(ShiftTemplateIdentity the_shift_template_identity)
        {
            return build_remove_request_editor( the_shift_template_identity );
        }

        private IsAViewElement build_remove_request_editor( ShiftTemplateIdentity shift_template_identity )
        {
            var remove_request = get_shift_template_remove_request( shift_template_identity );

            return _editor_builder
                            .build(remove_request)
                            ;
        }

        private RemoveShiftTemplateRequest get_shift_template_remove_request( ShiftTemplateIdentity shift_tempate_identity )
        {
            // Improve: We are not handling errors at this point we need to correct this once we have worked out the common error handling strategy

            return _remove_equest
                        .execute( shift_tempate_identity )
                        .result
                        ;
        }

        public RemoveShiftTemplateRequestEditorBuilder(IGetRemoveShiftTemplateRequest the_remove_request,
                                                       EditorBuilder<RemoveShiftTemplateRequest> the_editor_builder
                                                      )
        {
            _remove_equest = Guard.IsNotNull(the_remove_request, "the_remove_request");
            _editor_builder = Guard.IsNotNull(the_editor_builder, "the_editor_builder");
        }

        private readonly IGetRemoveShiftTemplateRequest _remove_equest;
        private readonly EditorBuilder<RemoveShiftTemplateRequest> _editor_builder;
    }
}