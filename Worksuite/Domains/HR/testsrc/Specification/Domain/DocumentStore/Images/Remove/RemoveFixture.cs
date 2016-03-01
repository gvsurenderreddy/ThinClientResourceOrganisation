using WTS.WorkSuite.Service.DocumentStore.Images;
using WTS.WorkSuite.Service.DocumentStore.Images.Remove;
using WTS.WorkSuite.Service.Helpers.Framework.Request;
using WTS.WorkSuite.Service.Helpers.Framework.Specifications.ForResponseCommands;

namespace WTS.WorkSuite.Service.Domain.DocumentStore.Images.Remove {

    public class RemoveFixture 
                    : ResponseCommandFixture<ImageIdentity,RemoveImageResponse,IRemoveImage> {

        public RemoveFixture
                       ( IRemoveImage the_command
                       , IRequestBuilder<ImageIdentity> the_request_builder ) 
                : base ( the_command
                       , the_request_builder ) { }


    }
}
