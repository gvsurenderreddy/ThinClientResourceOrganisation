namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Remove
{
    public class RemoveBreakTemplateRequest
                        : BreakTemplateIdentity
    {
        public string template_name { get; set; }
        public string hidden_status { get; set; }
    }
}