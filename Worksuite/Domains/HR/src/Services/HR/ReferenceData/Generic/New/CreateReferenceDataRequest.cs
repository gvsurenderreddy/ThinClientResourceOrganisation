namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New
{
    /// <summary>
    ///     Base create request for each class that all concrete reference data 
    /// types create class must inherit from if they are to use the templates  
    /// </summary>
    public abstract class CreateReferenceDataRequest {

        public string description { get; set; }
        public bool is_hidden { get; set; } 
    }
}