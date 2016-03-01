using System.Reflection;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Tables.Fields.DisplayPolicy
{
    public class DefaultAlwaySayYesPolicy<S> : IShouldBeDisplayedOnTable<S>
    {

        public bool decide_for(PropertyInfo context)
        {
            return true;
        }
      
    }
}