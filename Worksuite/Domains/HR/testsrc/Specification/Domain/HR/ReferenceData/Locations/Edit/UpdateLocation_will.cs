using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Locations.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Locations.Edit
{
    [TestClass]
    public class UpdateLocation_will
                    : CommandCommitedChangesSpecification<UpdateLocationRequest,
                                                          UpdateLocationResponse,
                                                          UpdateLocationFixture
                                                         > { }

    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Location,
                                                                        UpdateLocationRequest,
                                                                        UpdateLocationResponse,
                                                                        IUpdateLocation,
                                                                        LocationUpdatedEvent,
                                                                        UpdateLocationEventFixture>
    {

    }
}