using System.Collections.Generic;
using System.Linq;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public class ServiceStatusResponse
    {
        public IEnumerable<IServiceStatus> service_statuses { get; set; }
    }

    public class ServiceStatusResponse<Q> : ServiceStatusResponse
    {
        public Q result { get; set; }
    }

    public abstract class AServiceErrorStatus : IServiceStatus { }

    public interface IServiceStatus { /*Service status response marker interface*/}


    public static class ServiceStatusResponseExtensions
    {
        public static bool has_errors(this ServiceStatusResponse response)
        {
            Guard.IsNotNull(response, "response");

            return response.service_statuses.has_errors();
        }

        public static bool has_errors(this IEnumerable<IServiceStatus> service_statuses)
        {
            Guard.IsNotNull(service_statuses, "service_statuses");

            return service_statuses.Any(s => s.GetType().BaseType == typeof(AServiceErrorStatus));
        }

        public static bool has_status<T>(this ServiceStatusResponse response) where T : IServiceStatus, new()
        {
            Guard.IsNotNull(response, "response");

            return response.service_statuses.has_status<T>();
        }

        public static bool has_status<T>(this IEnumerable<IServiceStatus> service_statuses) where T : IServiceStatus, new()
        {
            Guard.IsNotNull(service_statuses, "service_statuses");

            return service_statuses.Any(s => s.GetType() == typeof(T));
        }
    }
}
