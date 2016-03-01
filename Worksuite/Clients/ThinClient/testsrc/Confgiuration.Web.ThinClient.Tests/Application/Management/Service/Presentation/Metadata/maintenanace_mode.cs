using Confgiuration.Web.ThinClient.Tests.Application.Management.Service.Presentation.Helpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.ServiceStates;
using WorkSuite.Confgiuration.Web.ThinClient.Application.Management.Service.Status.Presentation;

namespace Confgiuration.Web.ThinClient.Tests.Application.Management.Service.Presentation.Metadata {

    [TestClass]
    public class maintenance_mode {

        //  done: border class is maintenance
        //  todo: description is Online
        //  todo: description class is online

        [TestMethod]
        public void border_class ( ) {          
 
            query.execute().border_class.Should().Be( "maintenance" );
        }


        [TestMethod]
        public void description () {
            
            query.execute(  ).description.Should(  ).Be( "Maintenance mode" );
        }

        [TestMethod]
        public void description_class () {
            
            query.execute(  ).description_class.Should(  ).Be( "maintenance" );
        }


        [TestInitialize]
        public void before_each_test () {
            service_layer = new FakeServiceLayerGetServiceStatus();
            service_layer.status = new ServiceIsInMaintenanceMode();

            query = new GetServiceStatusPresentationMetadata( service_layer );            
        }

        FakeServiceLayerGetServiceStatus service_layer;
        GetServiceStatusPresentationMetadata query;

    }
}