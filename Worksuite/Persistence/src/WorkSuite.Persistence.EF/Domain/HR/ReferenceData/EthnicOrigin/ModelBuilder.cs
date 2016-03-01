using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.EthnicOrigin
{
    public class ModelBuilder
                    : ModelConfiguration< WorkSuite.HR.HR.ReferenceData.EthnicOrigin >
    {
        public ModelBuilder( string schema )
        {
            Map( m => m.ToTable( "EthnicOrigin", schema ) );
        }
    }
}