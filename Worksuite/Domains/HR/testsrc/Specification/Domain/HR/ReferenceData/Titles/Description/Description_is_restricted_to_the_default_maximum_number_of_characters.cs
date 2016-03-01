using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.HR.HR.ReferenceData;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.HR.ReferenceData.Titles.New;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Generic.Description;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Edit;
using WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.New;

namespace WTS.WorkSuite.HR.Services.Domain.HR.ReferenceData.Titles.Description
{
    public class Description_is_restricted_to_the_default_maximum_number_of_characters
    {
        [TestClass]
        public class verify_on_create
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_create<  Title,
                                                                                                            CreateTitleRequest,
                                                                                                            CreateTitleResponse,
                                                                                                            ICreateTitle,
                                                                                                            NewTitleFixture
                                                                                                         > { }


        [TestClass]
        public class verify_on_update
                        : Description_is_restricted_to_the_default_maximum_number_of_characters_on_update<  Title,
                                                                                                            UpdateTitleRequest,
                                                                                                            UpdateTitleResponse,
                                                                                                            IUpdateTitle,
                                                                                                            UpdateTitleFixture
                                                                                                         > { }
    }
}