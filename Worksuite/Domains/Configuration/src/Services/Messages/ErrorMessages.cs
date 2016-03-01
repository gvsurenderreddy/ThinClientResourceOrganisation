namespace WorkSuite.Configuration.Service.Messages {

// Turned off XML comments warnings in this file as there is no value to the comments. 
#pragma warning disable 1591


    public class ErrorMessages {

        /// <summary>
        /// Messages for Force online
        /// </summary>
        public const string error_03_0010 = "Warning! The system can not be brought online because it has been set to Maintenance mode by another user. To override this please confirm this below then choose the force online button.";
        public const string error_00_0031 = "Please  confirm that you want to force the service online.";

        /// <summary>
        /// messages for Database setting
        /// </summary>
        public const string error_05_0004 = "Connection string for the WORKSuite service database.";
        public const string erroe_05_0011 = "A maintainance session needs to be active before the database settings can be edited.";
        public const string error_00_0032 = "Please enter a connection string.";
        public const string error_00_0045 = "The database settings cannot be changed, because the connection string failed validation.";
        public const string error_04_0013 = "You have successfully edited the connection string.";
        public const string error_04_0001 = "Warning! The details you entered could not be saved. Please correct them as indicated below then save again.";

        /// <summary>
        /// Messages for Static content
        /// </summary>
        public const string error_00_0038 = "The URL cannot be changed because the location cannot be validated.";
        public const string error_05_0012 = "A maintenance session needs to be active before the static content can be edited.";
        public const string error_05_0005 = "Url for the root of WORKSuite web applications static content (.js, .css).";
        public const string error_00_0034= "Please enter a URL .";
        public const string error_04_0016= "You have successfully updated the static content location URL.";
        public const string error_03_0013 = "Warning! The details you entered could not be saved. Please correct them as indicated below then save again.";
        
        /// <summary>
        /// Messages for Help
        /// </summary>
        public const string error_05_0013= "URL for the online help documentation.";
        public const string error_05_0014= "A maintenance session needs to be active before the help location URL can be edited.";
        public const string error_00_0047= "Please enter a URL .";
        public const string error_00_0048= "The URL cannot be changed because the location cannot be validated.";
        public const string error_04_0022= "You have successfully updated the help location URL.";
        public const string error_03_0018= "Warning! The details you entered could not be saved. Please correct them as indicated below then save again.";
    
       

    }
#pragma warning restore 1591
}