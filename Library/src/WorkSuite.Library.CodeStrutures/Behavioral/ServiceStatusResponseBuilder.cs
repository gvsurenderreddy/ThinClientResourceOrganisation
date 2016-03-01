using System.Linq;
using System.Collections.Generic;

namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public class ServiceStatusResponseBuilder<Q> where Q : ServiceStatusResponse, new()
    {
        public ServiceStatusResponseBuilder<Q> add_status<T>() where T : IServiceStatus, new()
        {
            add_status(new T());
            return this;
        }

        public ServiceStatusResponseBuilder<Q> add_status(IServiceStatus status_to_add)
        {
            Guard.IsNotNull(status_to_add, "status_to_add");

            service_statuses.Add(status_to_add);
            return this;
        }

        public ServiceStatusResponseBuilder<Q> add_statuses(IEnumerable<IServiceStatus> statuses_to_add)
        {

            Guard.IsNotNull(statuses_to_add, "statuses_to_add");

            foreach (var status in statuses_to_add)
            {
                add_status(status);
            }
            return this;
        }

        public bool has_errors
        {
            get { return service_statuses.has_errors(); }
        }


        public virtual Q build()
        {
            return new Q
            {
                service_statuses = service_statuses
            };
        }


        private readonly List<IServiceStatus> service_statuses = new List<IServiceStatus>();
    }

    public class ServiceStatusResponseBuilder<R, Q>
                   : ServiceStatusResponseBuilder<Q>
           where Q : ServiceStatusResponse<R>, new()
    {

        public void set_response
                        (R the_response)
        {

            Guard.IsNotNull(the_response, "the_response");

            response = the_response;
        }

        public override Q build()
        {

            Guard.IsNotNull(response, "response");

            var result = base.build();
            result.result = response;

            return result;
        }

        private R response;
    }
}
