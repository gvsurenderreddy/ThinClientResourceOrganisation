﻿using System.Web.Mvc;
using WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Remove;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.Web.ThinClient.Application.HR.ReferenceData.Relationships.Commands.Remove {

    public class RemoveRelationshipController
                    : Controller {

        public ActionResult SubmitRequest 
                                ( RemoveRelationshipRequest remove_request ) {
            // to do: validate the update_request that was built from the request.

            var remove_response = remove.execute( remove_request );

            Response.StatusCode = remove_response.has_errors ? 400 : 200;

            return Json( remove_response, JsonRequestBehavior.AllowGet );
        }


        public RemoveRelationshipController 
                    ( IRemoveRelationship remove_command ) {

            remove = Guard.IsNotNull( remove_command, "remove_command" );
        }

        private readonly IRemoveRelationship remove;
    }
}