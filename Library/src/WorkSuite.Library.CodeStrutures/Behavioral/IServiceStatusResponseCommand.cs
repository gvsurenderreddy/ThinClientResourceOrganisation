namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public interface IServiceStatusResponseCommand<Q>
                        : ICommand<Q>
                where Q : ServiceStatusResponse { }


    public interface IServiceStatusResponseCommand<P, Q>
                        : ICommand<P, Q>
                where Q : ServiceStatusResponse { }
}
