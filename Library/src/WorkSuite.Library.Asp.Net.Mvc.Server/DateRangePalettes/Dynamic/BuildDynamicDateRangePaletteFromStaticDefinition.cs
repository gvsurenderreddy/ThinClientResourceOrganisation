using System;
using System.Linq;
using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Actions;
using WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic.StaticDefinitions.Model;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes;
using WTS.WorkSuite.Library.DomainTypes.Date;

namespace WorkSuite.Library.Asp.Net.Mvc.Server.DateRangePalettes.Dynamic
{
    public class BuildDynamicDateRangePaletteFromStaticDefinition<S>
    {
        public DateRangePalette build(S the_model)
        {
            model = Guard.IsNotNull(the_model, "the_model");

            return new DateRangePalette
            {
                title = model_definition.title.value_or_default(string.Empty)(the_model),
                calendar = build_calendar(),
                actions = action_definitions.Select(create_action).ToList(),
                selected_range = model_definition.selected_range(the_model)
            };
        }

        private DateRangeCalendar build_calendar()
        {
            return new DateRangeCalendar()
            {
                calendar_start_date = calendar_start_date,
                selected_start_date = selected_date,
                week_days = get_calendar_week_days(),
                dates = get_calendar_dates()
            };
        }

        private IEnumerable<string> get_calendar_week_days()
        {
            return new List<string>() { "M", "T", "W", "T", "F", "S", "S" };
        }

        private IEnumerable<IEnumerable<CalendarDate>> get_calendar_dates()
        {
            var start_date_of_week = calendar_start_date.FirstDayOfMonth().StartOfWeek(DayOfWeek.Monday);

            var dates = new List<IEnumerable<CalendarDate>>();


            for (int i = 0; i < 6; i++)
            {
                dates.Add(get_week_starting(start_date_of_week));
                start_date_of_week = start_date_of_week.AddDays(7);
            }

            return dates;
        }


        private IEnumerable<CalendarDate> get_week_starting(DateTime start_date)
        {
            var week = new List<CalendarDate>();

            for (var i = 0; i < 7; i++)
            {
                var date = start_date.AddDays(i);

                var calendar_date = new CalendarDate()
                {
                    date = date,
                    is_selected = date >= selected_date && date < selected_date.AddDays(number_of_days_in_range),
                    is_in_selected_month = date >= calendar_start_date.FirstDayOfMonth() && date <= calendar_start_date.LastDayOfMonth()
                };
                week.Add(calendar_date);
            }

            return week;
        }

        public BuildDynamicDateRangePaletteFromStaticDefinition(DynamicDateRangePaletteStaticDefinitionRepository<S> the_repository)
        {
            repository = Guard.IsNotNull(the_repository, "the_repository ");
        }

        private DynamicDateRangePaletteStaticDefinition<S> model_definition
        {
            get { return repository.definition; }
        }

        private IEnumerable<DynamicDateRangePaletteActionStaticDefinition<S>> action_definitions
        {
            get { return repository.actions; }
        }

        private readonly DynamicDateRangePaletteStaticDefinitionRepository<S> repository;

        private DateTime calendar_start_date
        {
            get
            {
                Guard.IsNotNull(model, "model");
                return model_definition.calendar_start_date(model);
            }
        }

        private DateTime selected_date
        {
            get
            {
                Guard.IsNotNull(model, "model");
                return model_definition.selected_start_date(model);
            }
        }

        private DateRangePaletteAction create_action(DynamicDateRangePaletteActionStaticDefinition<S> action_definition)
        {
            return new DateRangePaletteAction
            {
                title = action_definition.title(model),
                name = action_definition.name(model),
                classes = action_definition.classes.Select(class_definition => class_definition(model)).ToList()
            };
        }

        private int number_of_days_in_range
        {
            get
            {
                switch (model_definition.selected_range(model))
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

        private S model;
    }
}