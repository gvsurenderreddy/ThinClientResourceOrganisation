namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit
{
    public class UpdateReferenceDataRequest 
                    : ReferenceDataIdentity {

        public string description { get; set; }
        public bool is_hidden { get; set; }
    }
}