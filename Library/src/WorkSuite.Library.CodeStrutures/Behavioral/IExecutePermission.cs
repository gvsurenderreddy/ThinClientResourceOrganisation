namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public interface IExecutePermission<R>
    {
        bool IsGrantedFor(  R request  ); 
    }
}