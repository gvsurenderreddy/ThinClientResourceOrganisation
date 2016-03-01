namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Primitives.UserActions
{
    /// <summary>
    ///     Settings that can be used to set the common
    /// properties of an action.  This is used where you
    /// have a common action in multiple places e.g. every
    /// editor has a save and cancel action which we want to
    /// look the same.
    /// </summary>
    public abstract class CommonActionDefinition
    {
        public abstract string title { get; }

        public abstract string action_class { get; }

        public abstract string action_name { get; }
    }
}