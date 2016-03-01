using System.Collections.Generic;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetById
{
    public class GetBreakTemplateByIdResponse
                        : BreakTemplateIdentity
    {
        public string template_name { get; set; }
        public bool is_hidden { get; set; }

        public IEnumerable<BreakDetails> all_breaks { get; set; }
    }
}