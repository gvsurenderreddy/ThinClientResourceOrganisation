namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Edit
{
    public class UpdateBreakTemplateRequest
                        : BreakTemplateIdentity
    {
        public string template_name { get; set; }
        public bool is_hidden { get; set; }
    }
}