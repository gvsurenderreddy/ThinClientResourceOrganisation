using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Events;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit
{
    public abstract class ReferenceDataUpdatedEventSpecification<E,P,Q,C,V,F> : HRResponseCommandSpecification<P,Q,F>
                        where E : ReferenceDataModel
                        where P : UpdateReferenceDataRequest
                        where Q : UpdateReferenceDataResponse
                        where V : ReferenceDataUpdatedEvent
                        where C : IUpdateReferenceData<P, Q>
                        where F : UpdateReferenceDataEventFixture<E,P,Q,C,V>

    {
        [TestMethod]
        public void will_raise_an_updated_event()
        {

            fixture.execute_command();

            fixture
                .get_updated_event()
                .Match(

                    has_value:
                        created_event => Assert.IsTrue(true), // event was created

                    nothing:
                        Assert.Fail // event was not created
                );
        }
    }
}
