namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Editors {

    public class DefaultAlwaySayYesPolicy<S> : IShouldBeDisplayed<S> {

        public bool decide_for ( S context ) {
            return true;
        }
    }
}