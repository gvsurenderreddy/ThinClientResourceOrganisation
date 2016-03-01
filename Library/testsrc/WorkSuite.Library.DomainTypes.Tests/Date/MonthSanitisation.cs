using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Date.Validators.IsADate.GregorianCalendar;

namespace WTS.WorkSuite.Library.DomainTypes.Tests.Date
{
    
    public class MonthSanitisation
    {
        [TestClass]
        public class MonthMustBeNumericOrAValidMonthName
                                       : CheckSanitisationForGregorianCalendarSpecification
        {


            public class MonthName
            {
                [TestClass]
                public class January : MonthNameIsRecognised<JanuarySpecification> { }

                public class JanuarySpecification
                                : MonthNameSpecification
                {

                    public override string month { get { return "january"; } }
                    public override int value { get { return 1; } }
                }

                [TestClass]
                public class February : MonthNameIsRecognised<FebruarySpecification> { }

                public class FebruarySpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "february"; }
                    }

                    public override int value
                    {
                        get { return 2; }
                    }
                }


                [TestClass]
                public class March : MonthNameIsRecognised<MarchSpecification> { }

                public class MarchSpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "march"; }
                    }

                    public override int value
                    {
                        get { return 3; }
                    }
                }

                [TestClass]
                public class April : MonthNameIsRecognised<AprilSpecification> { }

                public class AprilSpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "april"; }
                    }

                    public override int value
                    {
                        get { return 4; }
                    }
                }

                [TestClass]
                public class May : MonthNameIsRecognised<MaySpecification> { }

                public class MaySpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "may"; }
                    }

                    public override int value
                    {
                        get { return 5; }
                    }
                }

                [TestClass]
                public class June : MonthNameIsRecognised<JuneSpecification> { }

                public class JuneSpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "june"; }
                    }

                    public override int value
                    {
                        get { return 6; }
                    }
                }

                [TestClass]
                public class July : MonthNameIsRecognised<JulySpecification> { }

                public class JulySpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "july"; }
                    }

                    public override int value
                    {
                        get { return 7; }
                    }
                }

                [TestClass]
                public class August : MonthNameIsRecognised<AugustSpecification> { }

                public class AugustSpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "august"; }
                    }

                    public override int value
                    {
                        get { return 8; }
                    }
                }

                [TestClass]
                public class September : MonthNameIsRecognised<SeptemberSpecification> { }

                public class SeptemberSpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "september"; }
                    }

                    public override int value
                    {
                        get { return 9; }
                    }
                }

                [TestClass]
                public class October : MonthNameIsRecognised<OctoberSpecification> { }

                public class OctoberSpecification
                                : MonthNameSpecification
                {


                    public override string month
                    {
                        get { return "october"; }
                    }

                    public override int value
                    {
                        get { return 10; }
                    }
                }

                [TestClass]
                public class November : MonthNameIsRecognised<NovemberSpecification> { }

                public class NovemberSpecification
                                : MonthNameSpecification
                {


                    public override string month
                    {
                        get { return "november"; }
                    }

                    public override int value
                    {
                        get { return 11; }
                    }
                }

                [TestClass]
                public class December : MonthNameIsRecognised<DecemberSpecification> { }

                public class DecemberSpecification
                                : MonthNameSpecification
                {

                    public override string month
                    {
                        get { return "december"; }
                    }

                    public override int value
                    {
                        get { return 12; }
                    }
                }


                public abstract class MonthNameSpecification {

                            public abstract string month { get; }
                            public abstract int value { get;  } 
                    }

                public abstract class MonthNameIsRecognised<T>
                                                     : CheckSanitisationForGregorianCalendarSpecification
                                             where T : MonthNameSpecification, new()
                {
                    [TestMethod]
                    public void month_is_recognised_by_the_first_three_characters()
                    {
                        var request = valid_date_request.ToDateRequest();

                        request.month = parameters.month.Substring(0, 3);


                        gregorian_calendar_sanitisation.execute(request)
                            .Match(

                                  is_valid:
                                    date => (date).month.Should().Be(parameters.value),

                                is_not_valid:
                                    errors => new GregorianCalendarSanitisationResult.Error()

                            );
                    }


                    [TestMethod]
                    public void month_is_recognised_by_its_full_name()
                    {
                        var request = valid_date_request.ToDateRequest();
                   
                        request.month = parameters.month;
                   
                        gregorian_calendar_sanitisation
                            .execute(request)
                            .Match(
                   
                                is_valid:
                                    date => (date).month.Should().Be(parameters.value),
                   
                                is_not_valid:
                                   errors => new GregorianCalendarSanitisationResult.Error()
                            );
                    }

                    [TestMethod]
                    public void month_is_recognised_by_its_full_name_in_uppercase()
                    {
                        var request = valid_date_request.ToDateRequest();
                    
                        request.month = parameters.month.ToUpper();
                    
                        gregorian_calendar_sanitisation
                            .execute(request)
                            .Match(
                    
                                is_valid:
                                    date => (date).month.Should().Be(parameters.value),
                    
                                is_not_valid:
                                    errors => new GregorianCalendarSanitisationResult.Error()
                    
                            );
                    }

                    [TestMethod]
                    public void month_is_recognised_by_the_first_three_characters_in_uppercase()
                    {
                        var request = valid_date_request.ToDateRequest();
                   
                        request.month = parameters.month.Substring(0, 3);
                   
                        gregorian_calendar_sanitisation
                            .execute(request)
                            .Match(
                   
                                is_valid:
                                    date => (date).month.Should().Be(parameters.value),
                   
                                is_not_valid:
                                   errors =>Assert.Fail()
                            );
                    }

                    [TestMethod]
                    public void month_is_not_recognised_if_less_than_three_characters()
                    {
                        var request = valid_date_request.ToDateRequest();
                    
                        request.month = parameters.month.Substring(0, 2);
                    
                        gregorian_calendar_sanitisation
                            .execute(request)
                            .Match(
                    
                                is_valid:
                                    date => Assert.Fail("Incorrectly identified month from substring, we should only indentify if it is three characters or more."),
                    
                                is_not_valid:
                                    errors => new GregorianCalendarSanitisationResult.Error()
                            );
                    }


                    public override void set_up()
                    {
                        base.set_up();

                        parameters = new T();
                    }

                    T parameters { get; set; }

                }
            }
        }

         
    }
}