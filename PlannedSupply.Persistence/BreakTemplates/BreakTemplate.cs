using System.Collections.Generic;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.PlannedSupply.Breaks;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates
{
    public class BreakTemplate
                    : BaseEntity<int>
    {
        public virtual string template_name { get; set; }

        public bool is_hidden { get; set; }

        public virtual ICollection<Break> all_breaks
        {
            get { return _all_breaks ?? (_all_breaks = new HashSet<Break>()); }
            set { _all_breaks = value; }
        }

        private ICollection<Break> _all_breaks;
    }
}