﻿using WTS.WorkSuite.Library.DomainTypes.Duration;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.Edit
{
    public class UpdateBreakRequest
                    : BreakIdentity
    {
        public DurationRequest off_set { get; set; }

        public DurationRequest duration { get; set; }

        public bool is_paid { get; set; }

        public string current_priority { get; set; }
    }
}