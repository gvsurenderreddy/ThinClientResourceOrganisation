namespace WTS.WorkSuite.Persistence.EF.Domain.Allocation {

    using WTS.WorkSuite.Library.EntityFramework.Configuration;


    public class ModelBuilder 
                    : ModelConfigurationRegister {

        public ModelBuilder
                ( string schema ) {

            register( new OperationCalendars.ModelBuilder( schema ));
            register( new ShiftCalendars.ModelBuilder( schema ));
        }
    }
}