using System.Web.Mvc;
using WTS.WorkSuite.Core.DomainIdentity;
using WTS.WorkSuite.HR.HR.Employees;
using WTS.WorkSuite.HR.HR.Employees.Addresses.Details;
using WTS.WorkSuite.HR.HR.Employees.Addresses.GetAll;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.Employees.Addresses.Presentation.List
{
    public class AddressListPresenter : Presenter
    {
          public ActionResult List ( EmployeeIdentity employee ) {

            var addresses = get_all.execute( employee );
            var view_model = list_builder.build( addresses.result, () => new { employee.employee_id } );

            return View( @"~\Views\Shared\Views\DetailsList.cshtml", view_model );
        }


          public AddressListPresenter
            ( IGetAllAddresses get_all_query
            , DetailsListBuilder<AddressDetails> the_list_builder ) {

            Guard.IsNotNull( get_all_query, "get_all_query" );
            Guard.IsNotNull( the_list_builder, "the_list_builder" );

            get_all = get_all_query;
            list_builder = the_list_builder;
        }

        private readonly IGetAllAddresses get_all;
        private readonly DetailsListBuilder<AddressDetails> list_builder;
         
    }
}