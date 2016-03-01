namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels {

    /// <summary>
    ///     Null implementation of a <see cref="IsAViewElement"/>. It is
    /// intended that this will cause nothing to be rendered an example of
    /// where it is uses is the editor builder will check whether the
    /// user has permission to actually perform the edit, if they do
    /// not then it will return a NullViewElement rather than return
    /// a null. 
    /// </summary>
    public class ANullViewElement 
                    : IsAViewElement {}
}