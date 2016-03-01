using System;
using System.Collections.Generic;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Time.Periods;

namespace WTS.WorkSuite.Web.ThinClient.Components.ShiftTimeAllocationPalettes.Dynamic.StaticDefinitions.Model
{
    public class DynamicShiftTimeAllocationPaletteModelStaticDefinition<S>
    {
        public string title { get; set; }
        public Func<S, string> shift_title { get; set; }
        public Func<S, TimePeriod> time_period { get; set; }
        public Func<S, IEnumerable<ITimeAllocationBreak>> breaks { get; set; }
        public ICollection<string> classes { get; set; }
    }
}
