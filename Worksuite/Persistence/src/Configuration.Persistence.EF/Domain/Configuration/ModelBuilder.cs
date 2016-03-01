using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace Configuration.Persistence.EF.Domain.Configuration
{
    public class ModelBuilder:ModelConfigurationRegister
    {
        public ModelBuilder(string schem)
        {
           register(new DatabaseSetting.ModelBuilder(schem));
           register(new StaticContent.ModelBuilder(schem));
           register(new HelpUrl.ModelBuilder(schem));
        }
    }
}