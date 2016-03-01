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
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit {

    public abstract class GetUpdateReferenceDataRequest_will<E,R,Q,C> 
                            : HRSpecification 
                    where E : ReferenceDataModel, new() 
                    where R : UpdateReferenceDataRequest
                    where Q : GetUpdateReferenceDataRequestResponse<R> 
                    where C : IGetUpdateReferenceDataRequest<R,Q> {


        [TestMethod]
        public void return_an_update_request_for_the_specified_entity () {

            update_request.result.id.Should().Be( entity.entity.id );
        }

        [TestMethod]
        public void map_the_description_correctly () {

            entity
                .description( "Mr" )
                ;

            update_request.result.description.Should().Be( entity.entity.description );
        }

        [TestMethod]
        public void map_the_is_hidden_correctly () {

            entity
                .is_hidden( true )
                ;

            update_request.result.is_hidden.Should().Be( entity.entity.is_hidden );
        }

        [TestMethod]
        public void returns_an_error_if_the_entity_does_not_exist () {
            id = -1;

            update_request.has_errors.Should().BeTrue();
        }


        [TestMethod]
        public void returns_an_null_request_if_the_entity_does_not_exist () {
            id = -2;

            update_request.result.id.Should().Be( Null.Id );            
        }

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
                return command.create( new ReferenceDataIdentity { id = id ?? entity.entity.id } );
            }
        }

        private int? id { get; set; }

        private IEntityRepository<E> repository;
        private C command;
        private ReferenceDataBuilder<E> entity;
    }
}