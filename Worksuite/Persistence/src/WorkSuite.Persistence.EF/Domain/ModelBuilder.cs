using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain {

    public class ModelBuilder
                    : ModelConfigurationRegister {

        public ModelBuilder() {

            register(new HR.ModelBuilder("HR"));
            register(new DocumentStore.ModelBuilder("DocumentStore"));
            register(new PlannedSupply.ModelBuilder("PlannedSupply"));
            register(new Audit.ModelBuilder("Audit"));
            register(new Allocation.ModelBuilder("Allocation"));
            register(new ThinClient.Query.ModelBuilder("ThinClient.Query"));
            register(new SupplyShortage.ModelBuilder("SupplyShortage"));
        }
    }
}