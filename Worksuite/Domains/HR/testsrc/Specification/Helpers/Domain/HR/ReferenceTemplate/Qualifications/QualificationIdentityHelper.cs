using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;

namespace WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Qualifications
{
    public class QualificationIdentityHelper
    {
        public ReferenceDataIdentity get_identity()
        {
            return new ReferenceDataIdentity
            {
                id = _qualification.id
            };
        }

        public QualificationIdentityHelper()
        {
            _qualification_helper = DependencyResolver.resolve<QualificationHelper>();

            _qualification = _qualification_helper.add().description("BA").entity;
        }

        private Qualification _qualification;
        private QualificationHelper _qualification_helper;
    }
}