using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Edit;
using WTS.WorkSuite.HR.HR.Employees.Addresses.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.New;
using WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Features.Update;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.Base;

namespace WTS.WorkSuite.HR.Services.Domain.HR.Employees.Addresses.Fields.Postcode {

    public class Postcode_is_converted_to_uppercase {

        [TestClass]
        public class verify_on_create
                        : HRActArrangeAssertResponseCommandSpecification<NewAddressRequest, NewAddressResponse, NewAddressFixture> {

            protected override void arrange ( ) {
                
                fixture.request.postcode = fixture.request.postcode.ToLower();
            }

            protected override void assert () {
                
                fixture.entity.postcode.Should().Be( fixture.entity.postcode.ToUpper() );
            }
        }


        [TestClass]
        public class verify_on_update
                        : HRActArrangeAssertResponseCommandSpecification<UpdateAddressRequest, UpdateAddressResponse, UpdateAddressFixture>
        {

            protected override void arrange ( ) {
                
                fixture.request.postcode = fixture.request.postcode.ToLower();
            }

            protected override void assert () {
                
                fixture.entity.postcode.Should().Be( fixture.entity.postcode.ToUpper() );
            }
        }

    }
}