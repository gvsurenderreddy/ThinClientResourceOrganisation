namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public class PermissionGranted<R> : IExecutePermission<R>{
        public bool IsGrantedFor(R request)
        {
            return true;
        }
    }
}