using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Infrastructure;
using WTS.WorkSuite.HR.Framework.Models;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic;
using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.Domain.HR.ReferenceTemplate.Generic;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description {

    public abstract class The_description_is_sanatised_when_getting_an_update_request<E,R,Q,C> 
        : HRSpecification 
        where E : ReferenceDataModel, new() 
        where R : UpdateReferenceDataRequest
        where Q : GetUpdateReferenceDataRequestResponse<R> 
        where C : IGetUpdateReferenceDataRequest<R,Q> {


        [TestMethod]
        public void nulls_will_result_in_an_empty_string () {
            entity.description( null );
            
            update_request.result.description.Should().Be( string.Empty );
        }

        [TestMethod]
        public void leading_whitespace_will_be_trimmed () {
            entity.description( white_space + valid_string );
            
            update_request.result.description.Should().Be( valid_string );
        }


        [TestMethod]
        public void trailing_whitespace_will_be_trimmed () {
            entity.description( valid_string + white_space );
            
            update_request.result.description.Should().Be( valid_string );
        }

        [TestMethod]
        public void a_string_that_is_all_whitespace_will_result_in_an_empty_string () {
            entity.description( white_space );
            
            update_request.result.description.Should().Be( string.Empty );
        }

        private const string valid_string = "A valid string";
        private const string white_space = "  \r\n\t";

        protected override void test_setup () {
            command = DependencyResolver.resolve<C>();
            repository = DependencyResolver.resolve<IEntityRepository<E>>();
            entity = add_entity();
        }


        private ReferenceDataBuilder<E> add_entity () {

            var builder = new ReferenceDataBuilder<E>();

            repository.add( builder.entity );

            return builder;
        }

        private Response<R> update_request {

            get {
                return command.create( new ReferenceDataIdentity { id = entity.entity.id } );
            }
        }

        private IEntityRepository<E> repository;
        private C command;
        private ReferenceDataBuilder<E> entity;
    }
}