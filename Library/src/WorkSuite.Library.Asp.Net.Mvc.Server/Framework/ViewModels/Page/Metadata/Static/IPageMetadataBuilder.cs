using System.Web.Mvc;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels.Page.Metadata.Static {

    public interface IPageMetadataBuilder {

        void build
                ( IDependencyResolver resolver );
    }
}
