﻿using Content.Services.HR.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.HR.HR.ReferenceData.Nationalities.Edit;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Nationalities.Presentation.Editor
{
    public class MetadataConfiguration
                        : EditorMetadataBuilder<UpdateNationalityRequest>
    {
        protected override void build_model_metadata(IEditorModelMetadataBuilder<UpdateNationalityRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(m => m.id + Resources.id)
                .title(Resources.title)
                ;
        }

        protected override void build_field_metadata(IEditorFieldsMetadataBuilder<UpdateNationalityRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(m => m.description)
                .id("description")
                .label("Nationality")
                .is_required(true)
                ;

            fields_metadata_builder
                .for_field(m => m.is_hidden)
                .id("is_hidden")
                .label("Hidden")
                .help(ValidationMessages.help_02_0012)
                ;

            fields_metadata_builder
                .for_field(m => m.id)
                .id("reference_id")
                .is_hidden()
                ;
        }

        protected override void build_action_metadata(IEditorActionsMetadataBuilder<UpdateNationalityRequest> actions_metadata_builder)
        {
            actions_metadata_builder
                .add_action<Save>()
                .call_to_action<PrimaryCallToAction>()
                .id(Commands.Update.Resources.id)
                .route_parameter_factory(m => new { m.id })
                ;

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action()
                ;
        }
    }
}