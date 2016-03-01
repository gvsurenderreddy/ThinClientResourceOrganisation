using System.Collections.Generic;
using System.Linq;
using Content.Services.HR.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.Events;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.Library.DomainTypes.DefaultValues;
using WTS.WorkSuite.Library.DomainTypes.Primitives.Validation;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeeQualifications.New
{
    public class NewEmployeeQualification
                        : INewEmployeeQualification
    {
        public NewEmployeeQualificationResponse execute( NewEmployeeQualificationRequest new_employee_qualification_request )
        {
            return this
                .set_request(new_employee_qualification_request)
                .find_employee()
                .find_qualification()
                .validate_request()
                .create_employee_qualification()
                .commit()
                .publish_qualification_created_event()
                .build_response()
                ;
        }

        private NewEmployeeQualification set_request(NewEmployeeQualificationRequest the_new_employee_qualification_request)
        {
            _new_employee_qualification_request = Guard.IsNotNull( the_new_employee_qualification_request,
                "the_new_employee_qualification_request" );

            _response_builder.set_response(
                new EmployeeQualificationIdentity
                {
                    employee_id = _new_employee_qualification_request.employee_id,
                    employee_qualification_id = Null.Id
                }
                );

            return this;
        }

        private NewEmployeeQualification find_employee()
        {
            if ( _response_builder.has_errors ) return this;

            Guard.IsNotNull( _new_employee_qualification_request, "_new_employee_qualification_request" );

            _employee = _employee_repository
                                .Entities
                                .Single(e => e.id == _new_employee_qualification_request.employee_id)
                                ;

            return this;
        }

        private NewEmployeeQualification find_qualification()
        {
            if ( _response_builder.has_errors ) return this;

            Guard.IsNotNull( _new_employee_qualification_request, "_new_employee_qualification_request" );

            _qualification = _qualification_repository
                                    .Entities
                                    .SingleOrDefault( q => q.id == _new_employee_qualification_request.qualification_id && !q.is_hidden )
                                    ;

            return this;

        }

        private NewEmployeeQualification validate_request()
        {
            if ( _response_builder.has_errors ) return this;

            Guard.IsNotNull( _new_employee_qualification_request, "_new_employee_qualification_request" );
            Guard.IsNotNull( _employee, "_employee" );

            if ( _qualification == null && _new_employee_qualification_request.qualification_id > 0 )
            {
                _validator
                    .field( "qualification_id" )
                    .premise_holds( false, "Please select a qualification that is not hidden" )
                    ;
            }
            else if (  _qualification == null )
            {
                _validator
                    .field( "qualification_id" )
                    .premise_holds( false, ValidationMessages.error_00_0033 )
                    ;
            }

            if ( _employee.EmployeeQualifications.Any( eq => eq.qualification != null && eq.qualification.id == _new_employee_qualification_request.qualification_id ) )
            {
                _validator
                    .field( "qualification_id" )
                    .premise_holds( false, ValidationMessages.error_00_0031 )
                    ;

                _response_builder.add_errors( _validator.errors );

                return this;
            }

            _response_builder.add_errors( _validator.errors );

            return this;
        }

        private NewEmployeeQualification create_employee_qualification()
        {
            if (_response_builder.has_errors) return this;

            Guard.IsNotNull( _employee, "_employee" );
            Guard.IsNotNull( _qualification, "_qualification" );

            _employee_qualification = new EmployeeQualification
            {
                qualification = _qualification
            };

            _employee
                .EmployeeQualifications
                .Add( _employee_qualification )
                ;

            return this;
        }

        private NewEmployeeQualification commit()
        {
            if ( _response_builder.has_errors ) return this;

            _unit_of_work.Commit();

            return this;
        }

        public NewEmployeeQualification publish_qualification_created_event()
        {
            if (_response_builder.has_errors) return this;

            Guard.IsNotNull(_employee, "_employee");
            Guard.IsNotNull(_employee_qualification, "_employee_qualification");
            Guard.IsNotNull(_employee_qualification.qualification, "_employee_qualification.qualification");

            _event_publisher_qualification_created.publish(new EmployeeQualificationCreatedEvent
            {
                employee_id = _employee.id,
                employee_qualification_id = _employee_qualification.qualification.id,
                employee_qualification_description =  _employee_qualification.qualification.description
            });

            return this;
        }

        private NewEmployeeQualificationResponse build_response()
        {
            if (!_response_builder.has_errors)
            {
                var confirmation_message = new List<string> { ConfirmationMessages.confirmation_04_0015 };
                _response_builder.add_messages( confirmation_message );
                _response_builder.set_response(new EmployeeQualificationIdentity { employee_id = _new_employee_qualification_request.employee_id, employee_qualification_id = _employee_qualification.id } );
            }
            else
            {
                _response_builder.add_errors( new List< string > {
                    ValidationMessages.warning_03_0001,
                });
            }

            return _response_builder.build();            
        }

        public NewEmployeeQualification(    IEntityRepository<Employee> the_employee_repository,
                                            IEntityRepository<Qualification> the_qualification_repository,
                                            IUnitOfWork the_unit_of_work,
                                            Validator the_validator,
                                            IEventPublisher<EmployeeQualificationCreatedEvent> the_event_publisher_qualification_created
                                       )
        {
            _employee_repository        = Guard.IsNotNull( the_employee_repository, "the_employee_repository" );
            _qualification_repository   = Guard.IsNotNull( the_qualification_repository, "the_qualification_repository" );
            _unit_of_work               = Guard.IsNotNull( the_unit_of_work, "the_unit_of_work" );
            _validator                  = Guard.IsNotNull( the_validator, "the_validator" );
            _event_publisher_qualification_created = Guard.IsNotNull(the_event_publisher_qualification_created,
                                                                     "the_event_publisher_qualification_created"
                                                                    );
        }

        private readonly IEntityRepository< Employee > _employee_repository;
        private readonly IEntityRepository< Qualification > _qualification_repository;
        private readonly IUnitOfWork _unit_of_work;
        private readonly Validator _validator;
        private readonly IEventPublisher<EmployeeQualificationCreatedEvent> _event_publisher_qualification_created;

        private Employee _employee;
        private Qualification _qualification;
        private EmployeeQualification _employee_qualification;
        private NewEmployeeQualificationRequest _new_employee_qualification_request;
        private readonly ResponseBuilder< EmployeeQualificationIdentity, NewEmployeeQualificationResponse > _response_builder =
            new ResponseBuilder< EmployeeQualificationIdentity, NewEmployeeQualificationResponse >();
    }
}