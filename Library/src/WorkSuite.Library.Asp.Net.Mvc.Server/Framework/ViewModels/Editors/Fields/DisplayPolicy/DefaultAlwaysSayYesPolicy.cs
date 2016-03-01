using System.Reflection;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors.Fields {

    public class DefaultAlwaysSayYesPolicy : IShouldBeDisplayedOnEditor {

        public bool decide_for ( PropertyInfo context ) {
            return true;
        }
    }
}