using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.ViewModelBuilder;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.EditOrRemove.ViewModel
{
    public class EditOrRemoveShiftTemplateDetailsViewModelBuilder
    {

        public AViewModelBuilder For(ShiftTemplateIdentity shift_template)
        {
            return this
                    .set_template( shift_template )
                    .add_update_request_editor_to_view_model()
                    .add_remove_request_editor_to_view_model()
                    .build_view_model()
                    ;
        }

        private EditOrRemoveShiftTemplateDetailsViewModelBuilder set_template
                                                                    ( ShiftTemplateIdentity shift_template_identity )
        {
            this.shift_template_identity = shift_template_identity;

            return this;
        }


        private EditOrRemoveShiftTemplateDetailsViewModelBuilder add_update_request_editor_to_view_model() 
        {
            Guard.IsNotNull( shift_template_identity, "shift_template_identity" );

            view_model_builder.add_view_element( _update_request_editor_builder.build( shift_template_identity ) );

            return this;
        }

        private EditOrRemoveShiftTemplateDetailsViewModelBuilder add_remove_request_editor_to_view_model ()
        {
            Guard.IsNotNull(shift_template_identity, "shift_template_identity");

            view_model_builder.add_view_element( _remove_request_editor_builder.build( shift_template_identity ) );

            return this;

        }

        private AViewModelBuilder build_view_model()
        {
            return view_model_builder;
        }

        public EditOrRemoveShiftTemplateDetailsViewModelBuilder
                                  (AViewModelBuilder the_view_model_builder
                                  , UpdateShiftTemplateRequestEditorBuilder the_update_request_editor_builder
                                  , RemoveShiftTemplateRequestEditorBuilder the_remove_request_editor_builder)
        {

            view_model_builder = Guard.IsNotNull(the_view_model_builder, "the_view_model_builder");
            _update_request_editor_builder = Guard.IsNotNull(the_update_request_editor_builder, "the_update_request_editor_builder");
            _remove_request_editor_builder = Guard.IsNotNull(the_remove_request_editor_builder, "the_remove_request_editor_builder");
        }


        private readonly AViewModelBuilder view_model_builder;
        private readonly UpdateShiftTemplateRequestEditorBuilder _update_request_editor_builder;
        private readonly RemoveShiftTemplateRequestEditorBuilder _remove_request_editor_builder;
        private ShiftTemplateIdentity shift_template_identity;
    }
}