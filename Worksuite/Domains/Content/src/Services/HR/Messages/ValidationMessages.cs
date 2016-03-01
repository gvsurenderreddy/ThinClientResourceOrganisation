/*
 * 18/11/2013 - From this day onwards we have decided to use the messages described in the WTS Sytle Guide (Solution -> Product -> WTS Style Guide.pptx document);
 * therefore in the future if a new message is required first add it to the Style guide with a name and the message
 * and then create a new constant with that name to use it in the code.
 * 
 * 06/12/2013 - Introduced four message types - Error, Warning, Help & Confirmation - with each type has its own region and 
 * within each region, add a message constant for a functionality, using a number specified in the WTS Style Guide.
 */

using Humanizer;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace Content.Services.HR.Messages
{
    public static class ValidationMessages
    {


        // ERROR MESSAGES
        #region Error Messages
        
        public static readonly string error_01_0001 = string.Format("Please use no more than {0} characters.", ValidationConstraints.max_text_field_length);
        public const string error_01_0002 = "Please only use  spaces, the characters ' & - the letters A-Z, and the numbers 0-9.";
        public const string error_00_0010 = "Please only use spaces, the symbols +() and the numbers 0-9.";
        public const string error_01_0003 = "This information is required.";

        // Address - number or name
        public const string error_00_0012 = "Please enter a house number or name.";        
        public const string error_00_0015 = "This house number or name and its matching postcode cannot be used because it has already been created. Please enter a different house number.";

        // Address - Postcode
        public const string error_00_0013 = "Please enter a postcode.";
        public static readonly string error_00_0014 = string.Format( "Please use no more then {0} characters not including spaces.", ValidationConstraints.max_text_field_length_for_post_code );
        public const string error_00_0016 = "This house number or name and its matching postcode cannot be used because it has already been created. Please enter a different postcode.";
        public const string error_00_0028 = "Please only use the letters A-Z, the numbers 0-9 and spaces.";


        // New Employee
        public const string error_01_0004 = "Please enter a Forename.";
        public const string error_01_0005 = "Please  enter a Surname.";
        public const string error_00_0023 = "Please enter an employee reference.";
        public const string error_00_0024 = "An employee with this reference already exists. Please enter a different reference.";

        public const string error_00_0017 = "Please enter a note.";

        // Duplicate Reference Data
        public const string error_00_0018 = "This entry already exists so cannot be used again. Please ensure it is unique.";

        // Picture
        public const string error_00_0019 = "Please  only choose a JPEG PNG GIF or Bitmap file format.";
        public const string error_00_0020 = "Please  choose a picture with a minimum size of 600 by 400 pixels.";

        //Documents
        public const string error_00_0029 = "Please  choose a file.";
        public const string error_00_0030 = "Please  enter a description.";
        
        //Skills
        public const string error_00_0027 = "This skill has already been used. Please enter a different skill.";

        // Employee Qualifications
        public const string error_00_0033 = "Please choose a qualification.";

        // Qualifications
        public const string error_00_0031 = "This qualification has already been assigned. Please select a different qualification.";

        //Emergency Contacts
        public const string error_01_0021 = "Please enter the name of a contact in case of an emergency.";
        public const string error_01_0022 = "Please enter the phone number of a contact in case of an emergency.";


        // date of birth
        public const string error_00_0008 = "The date you have entered is not complete. Please ensure all the fields are completed or leave them blank to omit the date.";
        public const string error_00_0007 = "Please only use the numbers 0-9 or if you have typed in the Month ensuring it is spelt correctly using the format (Day/Month/Year). Type in the full 4 digit year or use a 2 digit or less abbreviation only.";
        public const string error_00_0006 = "The date you have entered cannot be used. Please check it is a valid date using the format (Day/Month/Year).";
        public const string error_00_0009 = "The date you have entered cannot be used because it is in the future. Please use a date in the past.";

        // DateOfBirth
        public const string date_of_birth_is_incomplete =
            "The date you have entered is not complete. " +
            "Please ensure all the fields are completed or " +
            "leave them blank to omit the date.";

        public const string date_of_birth_is_invalid =
            "The date you have entered cannot be used. " +
            "Please check it is a valid date using the format (Day/Month/Year).";

        public const string date_of_birth_is_in_the_future =
            "The date you have entered cannot be used because it is in the future. " +
            "Please use a date in the past.";

        public const string date_of_birth_is_insane =
            "Please only use the numbers 0-9 or if you have typed in the Month ensuring it is spelt correctly. " +
            "Type in the full 4 digit year or use a 2 digit or less abbreviation only.";
        //Date of birth sanitisation error message 
        public static readonly  string error_050320151200 = string.Format("The date you have entered cannot be used. Please check it is a valid date using the format {0}.",ValidationConstraints.date_format);

        //Date of birth validation error message 
        public const string error_060320151023= "The date you have entered cannot be used because it is in the future. Please use a date in the past.";

        #endregion Error Messages


        // WARNINGS MESSAGES
        #region Warning Messages

        // Default
        public const string warning_03_0001 =
            "Warning! The details you entered could not be saved. Please correct them as indicated below then save again.";

        // Picture
        public const string warning_03_0004 =
            "Warning! The picture you have choosen could not be used. Please choose another picture as indicated below then save again.";

        // New Employee
        public const string warning_03_0003 =
            "Warning! The new employee could not be added. Please correct the details indicated below then save again.";

        // Edit employee
        public const string warning_03_0018 = "Warning! The employee you are trying to view is not available. They may have been removed or cannot be identified.";

        #endregion Warning Messages


        // HELP MESSAGES
        #region Help Messages

        // Picture
        public const string help_02_0004 =
            "Click the 'Browse' button to choose a picture. Accepted file formats are JPEG, PNG, GIF and Bitmap. ";

        public const string help_02_0005 =
            "Please choose a picture with a minimum size of 600 by 400 pixels. In a JPEG PNG GIF or Bitmap file format.";

        public const string help_02_0006 = "Relationships can be added, edited or removed from the 'setup menus' options on the home page.";

        // Employee Reference
        public const string help_02_0007 = "Please enter a unique employee reference.";


        //SKill
        public const string help_02_0008 = "Skills can be added, edited or removed from the 'setup menus' options on the home page.";
        
        public const string help_05_0003 =	"Skills can only be used once. They are stored in order of preference."; 

        public const string help_02_0009 = "Click the 'Browse' button to choose a document.";

        // Emergency Contact
        public const string help_02_0010 = "This is the primary phone number to use in an emergency.";

        public const string help_02_0011 =
            "This is an alternative phone number to use in an emergency if the primary phone number is not available.";

        // Reference Data 'Hidden' field help message
        public const string help_02_0012 =
            "Tick hidden to remove this item from all selectable options where it has not been previously selected.";

        #endregion Help Messages


        // CONFIRMATION MESSAGES
        #region Confirmation Messages

        public const string confirmation_04_0001 = "You have successfully saved your changes.";

        // Picture
        public const string confirmation_04_0007 = "You have successfully changed your picture.";

        //Document
        public const string confirmation_04_0008 = "You have successfully added a document.";

        // New Employee
        public const string confirmation_04_0004 = "You have successfully added a new employee.";
        public const string confirmation_04_0011 = "You have successfully removed your picture.";

        // Remove employee
        public const string confirmation_04_0003 = "You have successfully removed the employee.";        

        #endregion Confirmation Messages




        // update

        public const string update_was_successfull =
            confirmation_04_0001;

        public const string default_update_permission_not_granted =
            "Warning! The details you entered have not been saved. You are not authorised to edit these details.";

        // remove
        public const string remove_was_not_sccuessfull_hidden_instead =
            "Warning! You were unable to remove this item because it is in use. It has been changed to hidden instead.";

        public const string remove_was_successfull =
            "You have successfully removed the item.";

        // Employee
        public const string employee_not_found =
            "You can no longer view this employee because their records have been removed from the system.";

        // Person's name errors
        public const string persons_name_has_invalid_characters =
            "Please only use the letters A-Z, the numbers 0-9, spaces and the characters ' & -";

        public const string email_field_does_not_meet_pattern =
            "Please enter a valid email address. This must contain a minimum of a character then an @ sign then a character then a dot then a character e.g. Name@company.com";


        // Email
        public const string email_cannot_start_or_end_with_at_sign =
            "Email addresses cannot start or end with an @ sign. Please check the email address is correct.";

        public const string email_cannot_start_or_end_with_dot =
            "Email addresses cannot start or end with a dot. Please check the email address is correct.";

        public static readonly string max_number_of_characters_in_text_field_exceeded_email =
            string.Format("Please use no more than {0} characters.", ValidationConstraints.max_text_field_length_for_email);


        // Reference Data - Description
        public const string reference_data_description_is_mandatory =
            "Please enter a Description";

        public const string reference_data_entry_not_found =
            "You can no longer edit this entry because it has been removed from the system.";

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