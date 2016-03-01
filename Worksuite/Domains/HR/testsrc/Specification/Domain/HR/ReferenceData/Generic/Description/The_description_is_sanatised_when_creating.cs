﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.New;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {


    public abstract class The_description_is_sanatised_when_creating<E,P,Q,C,F>
                            : HRResponseCommandSpecification<P, Q, F>
                    where E : ReferenceDataModel
                    where P : CreateReferenceDataRequest
                    where Q : CreateReferenceDataResponse
                    where C : ICreateReferenceData<P, Q>
                    where F : NewReferenceDataFixture<E,P,Q,C> {
         
        // we do not test nulls because the description is is a mandatory field.  


        [TestMethod]
        public void leading_whitespace_will_be_trimmed () {
            var original_request_desciption = fixture.request.description;

            fixture.request.description = white_space + fixture.request.description;
            
            // create a new title for the request
            fixture.execute_command();

            // expect the response to have an error 
            fixture.entity.description.Should().Be( original_request_desciption );
        }

        [TestMethod]
        public void trailing_whitespace_will_be_trimmed () {
            var original_request_desciption = fixture.request.description;

            fixture.request.description = fixture.request.description + white_space;
            
            // create a new title for the request
            fixture.execute_command();

            // expect the response to have an error 
            fixture.entity.description.Should().Be( original_request_desciption );
        }
        

        private const string white_space = "  \r\n\t";
    }


}