using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.DetailsLists;
using WorkSuite.Library.Asp.Net.Mvc.Server.Infrastructure.ControllerFactory;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Presentation.List
{
    public class RelationshipListPresenter
                    : Presenter
    {

        public ActionResult List()
        {
            var relationships = get_all.execute();
            var view_model = list_builder.build(relationships.result);

            return View(@"~\Views\Shared\Views\DetailsList.cshtml", view_model);
        }


        public RelationshipListPresenter
                    (IGetDetailsOfAllRelationships get_all_query
                    , DetailsListBuilder<RelationshipDetails> the_list_builder)
        {

            get_all = Guard.IsNotNull(get_all_query, "get_all_query");
            list_builder = Guard.IsNotNull(the_list_builder, "the_list_builder");

        }

        private readonly IGetDetailsOfAllRelationships get_all;
        private readonly DetailsListBuilder<RelationshipDetails> list_builder;
    }
}