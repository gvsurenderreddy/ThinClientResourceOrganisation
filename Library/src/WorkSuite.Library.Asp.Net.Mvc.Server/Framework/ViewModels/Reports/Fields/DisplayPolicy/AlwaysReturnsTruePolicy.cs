using System.Reflection;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Reports.Fields.DisplayPolicy
{
    public class AlwaysReturnsTruePolicy<S> : IShouldBeDisplayedOnReport<S> {

        public bool decide_for ( PropertyInfo property ) {

            // to do: (WPM)  This policy need to be removed and use the always return true policy instead

            return true;
        }

    }
}