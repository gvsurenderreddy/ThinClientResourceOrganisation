using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Asp.Net.Mvc.Server.ColourPickerPalettes.Dynamic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Metadata.Static;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ActionDefinitions.Editor;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.New;

namespace WTS.WorkSuite.Web.ThinClient.Application.SetupOptions.ShiftTemplates.Presentation.New.Editor
{
    public class MetadataConfiguration
            : EditorMetadataBuilder<NewShiftTemplatesRequest>
    {
        protected override void build_model_metadata
                                   (IEditorModelMetadataBuilder<NewShiftTemplatesRequest> model_metadata_builder)
        {
            model_metadata_builder
                .id(Resources.id)
                .title(Resources.title);
        }

        protected override void build_field_metadata
                                  (IEditorFieldsMetadataBuilder<NewShiftTemplatesRequest> fields_metadata_builder)
        {
            fields_metadata_builder
                .for_field(x => x.shift_title)
                .id("shift_title")
                .is_required(true)
                .label("Name");

            fields_metadata_builder
                .for_field(x => x.colour)
                .id("colour")
                .label("Colour")
                .colour_picker_palette(m => new ColourPickerPaletteBuilder()
                                                                        .set_colour_value(m.colour)
                                                                        .build(NewShiftTemplateColourPaletteJson)
                                        )
                ;

            fields_metadata_builder
                    .for_field(x => x.start_time)
                    .id("start_time")
                    .is_required(true)
                    .help(HelperMessage.help_02_0019)
                    .label("Start time");

            fields_metadata_builder
                   .for_field(x => x.duration)
                   .id("duration_time")
                   .is_required(true)
                   .help(HelperMessage.help_02_0020)
                   .label("Duration");

            fields_metadata_builder
                .for_field(bt => bt.break_template_id)
                .id("break_template_id")
                .label("Break template")
                .is_lookup()
                .help(HelperMessage.help_02_0025)
                ;
        }

        protected override void build_action_metadata
                                  (IEditorActionsMetadataBuilder<NewShiftTemplatesRequest> actions_metadata_builder)
        {
            actions_metadata_builder
               .add_action<Save>()
               .call_to_action<PrimaryCallToAction>()
               .id(Commands.New.Command.Create.Resources.id)
               .route_parameter_factory(m => new { });

            actions_metadata_builder
                .add_action<Cancel>()
                .call_to_action<SecondaryCallToAction>()
                .is_not_a_routed_action();
        }

        private const string NewShiftTemplateColourPaletteJson = "{ " +
                                                       "close_button_title: \"close\", " +

                                                       "current_colour_value: \"rgb(0,238,143)\", " +

                                                       "accellerator_colour_values: [" +

                                                            "\"rgb(204, 51, 0)\", \"rgb(255, 172, 0)\", \"rgb(0, 0, 0)\", \"rgb(64, 64, 64)\", " +

                                                            "\"rgb(128, 128, 128)\", \"rgb(192, 192, 192)\", \"rgb(220, 220, 220)\", \"rgb(255, 255, 255)\"" +

                                                        "], " +

                                                       "palette_entries: [" +

                                                           "{ title: \"0:00 - 1:00\", colour_values: [\"rgb(153,38,0)\", \"rgb(204,51,0)\", \"rgb(255,179,153)\", \"rgb(255,240,235)\"] }, " +

                                                           "{ title: \"1:00 - 2:00\", colour_values: [\"rgb(150,60,0)\", \"rgb(204,82,0)\", \"rgb(255,192,150)\", \"rgb(255,242,233)\"] }, " +

                                                           "{ title: \"2:00 - 3:00\", colour_values: [\"rgb(148,81,0)\", \"rgb(204,112,0)\", \"rgb(255,207,148)\", \"rgb(255,245,232)\"] }, " +

                                                           "{ title: \"3:00 - 4:00\", colour_values: [\"rgb(145,102,0)\", \"rgb(204,143,0)\", \"rgb(255,222,145)\", \"rgb(255,248,231)\"] }, " +

                                                           "{ title: \"4:00 - 5:00\", colour_values: [\"rgb(143,121,0)\", \"rgb(204,173,0)\", \"rgb(255,238,143)\", \"rgb(255,251,230)\"] }, " +

                                                           "{ title: \"5:00 - 6:00\", colour_values: [\"rgb(140,140,0)\", \"rgb(204,204,0)\", \"rgb(255,255,140)\", \"rgb(255,255,228)\"] }, " +

                                                           "{ title: \"6:00 - 7:00\", colour_values: [\"rgb(117,138,0)\", \"rgb(173,204,0)\", \"rgb(237,255,138)\", \"rgb(251,255,227)\"] }, " +

                                                           "{ title: \"7:00 - 8:00\", colour_values: [\"rgb(95,135,0)\", \"rgb(143,204,0)\", \"rgb(219,255,135)\", \"rgb(246,255,226)\"] }, " +

                                                           "{ title: \"8:00 - 9:00\", colour_values: [\"rgb(73,133,0)\", \"rgb(112,204,0)\", \"rgb(200,255,133)\", \"rgb(241,255,224)\"] }, " +

                                                           "{ title: \"9:00 - 10:00\", colour_values: [\"rgb(52,130,0)\", \"rgb(82,204,0)\", \"rgb(180,255,130)\", \"rgb(236,255,223)\"] }, " +

                                                           "{ title: \"10:00 - 11:00\", colour_values: [\"rgb(32,128,0)\", \"rgb(51,204,0)\", \"rgb(159,255,128)\", \"rgb(230,255,222)\"] }, " +

                                                           "{ title: \"11:00 - 12:00\", colour_values: [\"rgb(12,125,0)\", \"rgb(20,204,0)\", \"rgb(138,255,125)\", \"rgb(224,255,221)\"] }, " +

                                                           "{ title: \"12:00 - 13:00\", colour_values: [\"rgb(0,122,6)\", \"rgb(0,204,10)\", \"rgb(122,255,129)\", \"rgb(219,255,221)\"] }, " +

                                                           "{ title: \"13:00 - 14:00\", colour_values: [\"rgb(0,120,24)\", \"rgb(0,204,41)\", \"rgb(120,255,147)\", \"rgb(218,255,225)\"] }, " +

                                                           "{ title: \"14:00 - 15:00\", colour_values: [\"rgb(0,117,41)\", \"rgb(0,204,71)\", \"rgb(117,255,165)\", \"rgb(217,255,230)\"] }, " +

                                                           "{ title: \"15:00 - 16:00\", colour_values: [\"rgb(0,115,57)\", \"rgb(0,204,102)\", \"rgb(115,255,185)\", \"rgb(215,255,235)\"] }, " +

                                                           "{ title: \"16:00 - 17:00\", colour_values: [\"rgb(0,112,73)\", \"rgb(0,204,133)\", \"rgb(112,255,205)\", \"rgb(214,255,241)\"] }, " +

                                                           "{ title: \"17:00 - 18:00\", colour_values: [\"rgb(0,110,88)\", \"rgb(0,204,163)\", \"rgb(110,255,226)\", \"rgb(213,255,247)\"] }, " +

                                                           "{ title: \"18:00 - 19:00\", colour_values: [\"rgb(0,107,102)\", \"rgb(0,204,194)\", \"rgb(107,255,248)\", \"rgb(212,255,253)\"] }, " +

                                                           "{ title: \"19:00 - 20:00\", colour_values: [\"rgb(0,94,105)\", \"rgb(0,184,204)\", \"rgb(105,240,255)\", \"rgb(210,251,255)\"] }, " +

                                                           "{ title: \"20:00 - 21:00\", colour_values: [\"rgb(0,77,102)\", \"rgb(0,153,204)\", \"rgb(102,217,255)\", \"rgb(209,244,255)\"] }, " +

                                                           "{ title: \"21:00 - 22:00\", colour_values: [\"rgb(0,60,99)\", \"rgb(0,122,204)\", \"rgb(99,193,255)\", \"rgb(208,236,255)\"] }, " +

                                                           "{ title: \"22:00 - 23:00\", colour_values: [\"rgb(0,44,97)\", \"rgb(0,92,204)\", \"rgb(97,168,255)\", \"rgb(207,228,255)\"] }, " +

                                                           "{ title: \"23:00 - 24:00\", colour_values: [\"rgb(0,28,94)\", \"rgb(0,61,204)\", \"rgb(94,143,255)\", \"rgb(205,220,255)\"] }, " +

                                                        "]" +

                                               " }";
    }
}