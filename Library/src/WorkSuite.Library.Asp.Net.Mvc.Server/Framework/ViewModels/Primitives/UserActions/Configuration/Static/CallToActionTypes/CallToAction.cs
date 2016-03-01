namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions.Configuration.Static.CallToActionTypes
{
    public abstract class CallToAction
    {
        public abstract string action_class { get; }

        public override string ToString()
        {
            return action_class;
        }
    }
}