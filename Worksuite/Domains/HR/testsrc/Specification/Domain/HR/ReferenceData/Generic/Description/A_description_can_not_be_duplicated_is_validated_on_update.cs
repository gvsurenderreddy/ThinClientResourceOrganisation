using Content.Services.HR.Messages;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {

    public abstract class A_description_can_not_be_duplicated_is_validated_on_update<E,P,Q,C,F>
                            : HRResponseCommandSpecification<P, Q, F>
                    where E : ReferenceDataModel, new()
                    where P : UpdateReferenceDataRequest
                    where Q : UpdateReferenceDataResponse
                    where C : IUpdateReferenceData<P, Q>
                    where F : UpdateRefereceDataFixture<E,P,Q,C>   {
         

        [TestMethod]
        public void verify_same_case_on_update () {
            // update the description to a description that already exists.
            fixture.request.description = builder.entity.description;

            // act
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
        public void verify_different_cases_on_update () {
            // set the entities description to upper case and then set the request to the same string in lower case
            // when the update command is applied this should be recognised as an error.
            builder.description( builder.entity.description.ToUpper() );
            fixture.request.description = builder.entity.description.ToLower();

            // act
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

        protected override void test_setup () {
            base.test_setup();

            var repository = DependencyResolver.resolve<IEntityRepository<E>>();
            builder = DependencyResolver.resolve<ReferenceDataBuilder<E>>();

            builder
                .description( fixture.request.description + "xx" )
                ;

            repository.add( builder.entity );
        }

        private ReferenceDataBuilder<E> builder;
    }
}