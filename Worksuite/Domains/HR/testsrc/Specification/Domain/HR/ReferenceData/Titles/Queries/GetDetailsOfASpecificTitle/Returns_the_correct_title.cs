using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Queries;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Queries.GetDetailsOfASpecificReferenceData;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Titles;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Queries.GetDetailsOfASpecificTitle {
    
    [TestClass]
    public class Returns_the_correct_title
                    : Returns_the_correct_entity<Title,TitleBuilder,TitleDetails,GetDetailsOfASpecificTitleFixture>{}
}