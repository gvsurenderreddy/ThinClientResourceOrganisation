namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.Events
{
    public abstract class ReferenceDataUpdatedEvent : ReferenceDataIdentity
    {
        public string description { get; set; }
    }
}
