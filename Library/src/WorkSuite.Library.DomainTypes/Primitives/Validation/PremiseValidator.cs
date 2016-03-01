using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation
{
    public class PremiseValidator
    {
        public PremiseValidator for_field(string the_value)
        {
            value = the_value;

            return this;
        }

        public PremiseValidator verify<T>(IPremise the_premise) where T : IServiceStatus, new()
        {
            if (!the_premise.holds(value))
            {
                add_status<T>();
            }
            return this;
        }

        public PremiseValidator premise_holds<T>(bool premise_holds) where T : IServiceStatus, new()
        {
            if (!premise_holds)
            {
                add_status<T>();
            }

            return this;
        }

        public IEnumerable<IServiceStatus> get_statuses()
        {
            return service_statuses;
        }

        private void add_status<T>() where T : IServiceStatus, new()
        {
            service_statuses.Add(new T());
        }


        private readonly IList<IServiceStatus> service_statuses = new List<IServiceStatus>();

        private string value;
    }

    public interface IPremise
    {
        bool holds(string value);
    }
}
