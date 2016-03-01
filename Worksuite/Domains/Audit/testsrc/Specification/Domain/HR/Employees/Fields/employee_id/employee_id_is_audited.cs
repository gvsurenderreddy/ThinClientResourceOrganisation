using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Audit.Domain.HR.Employees.Events.Created;

namespace WTS.WorkSuite.Audit.Domain.HR.Employees.Fields.employee_id {

    public class employee_id_is_audited {
         
        // in the employee record for identification purpose
        //    done: on create
        //    on update

         
        public class in_the_employee_record_for_identification_purposes {

            [TestClass]
            public class on_employee_created 
                            : EmployeeCreatedEventSpecification {

                [TestMethod]
                public void the_employee_id_witten_to_the_employee_audit_recdord () {                    
                    var created_event =   fixture.create_event(  );

                    fixture.event_handler.handle( created_event );

                    fixture.all_employee_audit_trails.Should(  ).Contain( at => at.employee_id == created_event.employee_id );
                }
            }
        } 
    }

}