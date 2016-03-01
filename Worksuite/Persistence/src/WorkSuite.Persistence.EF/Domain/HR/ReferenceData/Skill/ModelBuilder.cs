using WTS.WorkSuite.Library.EntityFramework.Configuration;

namespace WTS.WorkSuite.Persistence.EF.Domain.HR.ReferenceData.Skill
{
    public class ModelBuilder
                        :   ModelConfiguration<WorkSuite.HR.HR.ReferenceData.Skill>
    {
        public ModelBuilder( string schema )
        {
            Map( m => m.ToTable( "Skill", schema ) );
        }
    }
}