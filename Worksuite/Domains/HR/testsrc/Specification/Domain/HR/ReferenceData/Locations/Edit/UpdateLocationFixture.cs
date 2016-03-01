﻿using WorkSuite.Library.Persistence;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.Update;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Edit
{
    public class UpdateLocationFixture
                    : UpdateRefereceDataFixture<Location,
                                                UpdateLocationRequest,
                                                UpdateLocationResponse,
                                                IUpdateLocation
                                               >
    {
        public UpdateLocationFixture(IUpdateLocation the_command,
                                     IRequestHelper<UpdateLocationRequest> the_request_builder,
                                     IEntityRepository<Location> the_repository
                                    )
            : base(the_command,
                   the_request_builder,
                   the_repository
                  ) { }
    }
}