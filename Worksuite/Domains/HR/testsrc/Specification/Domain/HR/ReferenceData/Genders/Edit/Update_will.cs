using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Edit.Update;
using WTS.WorkSuite.HR.HR.ReferenceData.Genders.Events;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Edit;
using WTS.WorkSuite.HR.Services.Helpers.SpecificationTemplates.ForDomainLogic;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Genders.Edit {

    [TestClass]
    public class Update_will 
                    : CommandCommitedChangesSpecification<UpdateGenderRequest, UpdateGenderResponse, UpdateGenderFixture> {}




    [TestClass]
    public class command_will : ReferenceDataUpdatedEventSpecification<Gender,
                                                                        UpdateGenderRequest,
                                                                        UpdateGenderResponse,
                                                                        IUpdateGender,
                                                                        GenderUpdatedEvent,
                                                                        UpdateGenderEventFixture>
    {

    }


}