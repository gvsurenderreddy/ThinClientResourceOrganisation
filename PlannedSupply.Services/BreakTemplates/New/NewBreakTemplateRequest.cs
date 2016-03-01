namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.New
{
    /// <summary>
    ///     Request accepted by the add shift break template command.
    /// </summary>
    public class NewBreakTemplateRequest
    {
        public string template_name { get; set; }
        public bool is_hidden { get; set; }
    }
}