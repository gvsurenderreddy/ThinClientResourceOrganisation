using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WorkSuite.Configuration.Persistence.Domain.Configuration;

namespace WorkSuite.Configuration.Service.Helpers.Domain.Management.ServiceStatus {
    
    public class FakeServiceStatusRepository 
                    : IServiceStatusRepository {


        public IQueryable<Persistence.Domain.Configuration.ServiceStatus> Entities {
                                            get {

                return entities.AsQueryable();
            }
        }

        public void add
                        ( Persistence.Domain.Configuration.ServiceStatus entity ) {
            
            entities.Add( entity );
            entity.id = get_next_id();
        }


        private int get_next_id () {
            return Interlocked.Increment( ref sequence );
        }

        private readonly List<Persistence.Domain.Configuration.ServiceStatus> entities = new List<Persistence.Domain.Configuration.ServiceStatus>();
        private static int sequence = 1;
    }
}