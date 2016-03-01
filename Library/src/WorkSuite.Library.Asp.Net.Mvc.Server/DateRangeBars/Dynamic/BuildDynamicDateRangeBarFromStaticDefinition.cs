using System;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic.StaticDefinitions;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangeBars.Dynamic
{
    //Improve: Use string builder for better performance
    public class BuildDynamicDateRangeBarFromStaticDefinition<S>
    {
        public DateRangeBar build(S the_model)
        {
            return set_model(the_model)
                        .build_bar();
        }

        private BuildDynamicDateRangeBarFromStaticDefinition<S> set_model(S the_model)
        {
            model = Guard.IsNotNull(the_model, "the_model");
            return this;
        }

        private DateRangeBar build_bar()
        {
            return new DateRangeBar
            {
                date_range_string = build_date_range_string(definition.start_date(model))
            };
        }


        private string build_date_range_string(DateTime the_start_date)
        {
            start_date = the_start_date;
            end_date = the_start_date.AddDays(number_of_days_in_range - 1);

            DateRangeSpan.Boundary(start_date, end_date, within_month, crosses_month, crosses_year);

            return date_range_string;
        }

        private void within_month()
        {
            date_range_string = start_day + hyphen + end_day + same_month + same_year;
        }

        private void crosses_month()
        {
            date_range_string = start_day + start_month + hyphen + end_day + end_month + same_year;
        }

        private void crosses_year()
        {
            date_range_string = start_day + start_month + start_year + hyphen + end_day + end_month + end_year;
        }

        private string start_day
        {
            get { return start_date.ToString("d "); }
        }

        private string start_month
        {
            get { return start_date.ToString("MMMM "); }
        }

        private string start_year
        {
            get { return start_date.ToString("yyyy "); }
        }

        private string end_day
        {
            get { return end_date.ToString("d "); }
        }

        private string end_month
        {
            get { return end_date.ToString("MMMM "); }
        }

        private string end_year
        {
            get { return end_date.ToString("yyyy"); }
        }

        private string same_month
        {
            get { return start_date.ToString("MMMM "); }
        }

        private string same_year
        {
            get { return start_date.ToString("yyyy"); }
        }

        private string hyphen
        {
            get { return "- "; }
        }

        private int number_of_days_in_range
        {
            get
            {
                switch (definition.selected_range(model))
                {
                    case ShiftCalendarRange.FourWeek:
                        return 28;
                    case ShiftCalendarRange.Week:
                        return 7;
                    default:
                        return 7;
                }
            }
        }

        public BuildDynamicDateRangeBarFromStaticDefinition(DynamicDateRangeBarStaticDefinitionRepository<S> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository ");
            date_range_string = "";
        }

        private DynamicDateRangeBarStaticDefinition<S> definition
        {
            get { return repository.definition; }
        }

        private readonly DynamicDateRangeBarStaticDefinitionRepository<S> repository;


        private DateTime start_date;
        private DateTime end_date;
        private string date_range_string;
        private S model;
    }
}