using System.Data.Entity;
using WTS.WorkSuite.Library.CodeStrutures.Structural;

namespace WTS.WorkSuite.Library.EntityFramework.Configuration {

    public class ModelConfigurationRegister : ConfigurationRegister<DbModelBuilder,IModelConfiguration>, IModelConfiguration { }

}