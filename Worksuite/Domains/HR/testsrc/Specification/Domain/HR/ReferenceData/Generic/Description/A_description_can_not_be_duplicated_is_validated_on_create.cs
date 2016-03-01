using Content.Services.HR.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {

    public abstract class A_description_can_not_be_duplicated_is_validated_on_create<E,P,Q,C,F>
                            : HRResponseCommandSpecification<P, Q, F>
                    where E : ReferenceDataModel
                    where P : CreateReferenceDataRequest
                    where Q : CreateReferenceDataResponse
                    where C : ICreateReferenceData<P, Q>
                    where F : NewReferenceDataFixture<E,P,Q,C> {
         
        [TestMethod]
        public void verify_same_case_on_create () {
            // create a new title for the request
            fixture.execute_command();

            // create another new title for the request
            fixture.execute_command();

            // expect the response to have an error 
            fixture.response.has_errors.Should().BeTrue("An error is raised if there is a duplicate description.");

            fixture.response.messages
                                .Should()
                                .Contain(rm => rm.field_name == "description" && rm.message == ValidationMessages.error_00_0018)
                                ;
            fixture.response.messages
                                .Should()
                                .Contain(rm => rm.message == ValidationMessages.warning_03_0001)
                                ;
        }

        [TestMethod]
        public void verify_different_cases_on_create () {
            // create a new title for the request
            fixture.request.description.ToLower();
            fixture.execute_command();

            // create another new title for the request
            fixture.request.description.ToUpper();
            fixture.execute_command();

            // expect the response to have an error 
            fixture.response.has_errors.Should().BeTrue("An error is raised if there is a duplicate description.");
            fixture.response.messages
                                .Should()
                                .Contain(rm => rm.field_name == "description" && rm.message == ValidationMessages.error_00_0018)
                                ;
            fixture.response.messages
                                .Should()
                                .Contain(rm => rm.message == ValidationMessages.warning_03_0001)
                                ;
        }
    }
}