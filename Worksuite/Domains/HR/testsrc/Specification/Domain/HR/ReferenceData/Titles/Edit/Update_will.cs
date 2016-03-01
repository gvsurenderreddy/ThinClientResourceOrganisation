using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit {

    [TestClass]
    public class Update_will 
                    : CommandCommitedChangesSpecification<UpdateTitleRequest, UpdateTitleResponse, UpdateTitleFixture> {}

    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Title,
                                                                        UpdateTitleRequest,
                                                                        UpdateTitleResponse,
                                                                        IUpdateTitle,
                                                                        TitleUpdatedEvent,
                                                                        UpdateTitleEventFixture>
    {

    }

}