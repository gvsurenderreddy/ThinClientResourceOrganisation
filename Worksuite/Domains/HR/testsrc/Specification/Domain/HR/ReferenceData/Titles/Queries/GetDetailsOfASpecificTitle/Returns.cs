using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Persistence.Domain.HR.ReferenceData;
using WTS.WorkSuite.Service.HR.ReferenceData.Generic;
using WTS.WorkSuite.Service.HR.ReferenceData.Titles;
using WTS.WorkSuite.Service.HR.ReferenceData.Titles.GetById;
using WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Generic.GetById;
using WTS.WorkSuite.Service.Specification.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.Service.Specification.Domain.HR.ReferenceData.Titles.GetById {

    [TestClass]
    public class Returns
                    : Returns<ReferenceDataIdentity, Details, IGetTitlesById, Title, TitleBuilder, FakeTitleRepository, TitleHelper> {

    }
}