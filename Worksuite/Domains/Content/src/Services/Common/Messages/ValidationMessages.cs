using Humanizer;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace Content.Services.Common.Messages
{
    public static class ValidationMessages
    {

        // ERROR MESSAGES

        // Reorder
        public const string error_03_0007 = "Please only assign numbers to items in orderable list that are greater than zero.";
        public const string error_03_0008 = "Please only assign numbers to items in orderable list that are between 1 and the total number of items.";


        // WARNINGS MESSAGES

        // Reorder
        public const string default_reorder_permission_not_granted =
            "Warning! The details you entered have not been saved. You are not authorised to reorder these details.";



        // CONFIRMATION MESSAGES

        // Reorder
        public static string reorder_was_successfull(int previous_position, int new_position)
        {
            return string.Format("You have successfully moved an item from the {0} to the {1} position.", previous_position.Ordinalize(), new_position.Ordinalize());
        }       


        public static ResponseMessage AsValidationMessage(this string message, string for_field)
        {

            return new ResponseMessage
            {
                field_name = for_field,
                message = message,
            };
        }

    }
}