using WorkSuite.Library.Service.Specification.Helpers.Entity;
using WorkSuite.Library.Service.Specification.Helpers.IdentityProvider;
using WTS.WorkSuite.HR.Framework.Models;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic
{
    public class ReferenceDataBuilder<E>
                    : IEntityBuilder<E>
            where E : ReferenceDataModel, new()
    {
        public E entity { get; private set; }

        public ReferenceDataBuilder()
        {
            entity = new E();

            entity.id = next_id();
        }

        public ReferenceDataBuilder<E> is_hidden(bool value)
        {
            entity.is_hidden = value;
            return this;
        }

        public ReferenceDataBuilder<E> description(string value)
        {
            entity.description = value;

            return this;
        }

        private int next_id()
        {
            var identity_provider = new IntIdentityProvider<E>();

            return identity_provider.next();
        }
    }
}