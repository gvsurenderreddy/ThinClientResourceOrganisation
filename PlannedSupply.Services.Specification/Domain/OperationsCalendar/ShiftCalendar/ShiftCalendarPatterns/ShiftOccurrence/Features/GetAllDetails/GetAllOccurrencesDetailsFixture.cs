using System;
using WorkSuite.Library.Service.Specification.Helpers.Request;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.DomainTypes.Colour;
using WTS.WorkSuite.Library.DomainTypes.Date;
using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.Library.DomainTypes.Time;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.AggregateRoot;
using WTS.WorkSuite.PlannedSupply.OperationsCalendar.ShiftCalendar.ShiftCalendarPattern.ShiftOccurrence.GetAllDetails;
using WTS.WorkSuite.PlannedSupply.Services.Helpers.Domain.PlannedSupply.OperationsCalendars.ShiftCalendars.ShiftCalendarPatterns.ShiftOccurrence;

namespace WTS.WorkSuite.PlannedSupply.Services.Domain.OperationsCalendar.ShiftCalendar.ShiftCalendarPatterns.ShiftOccurrence.Features.GetAllDetails
{
    public class GetAllOccurrencesDetailsFixture
    {

        public RgbColour seed_request_colour(byte R, byte G, byte B)
        {
            var colour = new RgbColour(R, B, G);

            var occurrence = get_shift_occurrence.execute(request);

            occurrence.time_allocation.colour = colour.ToString();

            return colour;
        }

        public string seed_request_duration(int number_of_seconds)
        {
            var occurrence = get_shift_occurrence.execute(request);

            occurrence.time_allocation.duration_in_seconds = number_of_seconds;

            var duration_string = number_of_seconds.to_duration_request().to_domain_format_string();

            return duration_string;
        }

        public string seed_request_title(string title)
        {
            var occurrence = get_shift_occurrence.execute(request);

            occurrence.time_allocation.title = title;

            return title;
        }

        public string seed_request_start_time(int start_time_in_seconds)
        {
            var occurrence = get_shift_occurrence.execute(request);

            occurrence.time_allocation.start_time_in_seconds_from_midnight = start_time_in_seconds;

            var start_time_string = start_time_in_seconds.ToTimeRequestFromSeconds().to_domain_string();

            return start_time_string;
        }

        public string seed_request_start_date(DateTime start_date)
        {
            var occurrence = get_shift_occurrence.execute(request);

            occurrence.start_date = start_date;

            var start_date_string = start_date.FormatForReport();
            return start_date_string;
        }


        public ShiftOccurrenceIdentity request { get; private set; }
        public Response<AllOccurrencesDetails> response { get; private set; }

        public void execute_query()
        {
            response = query.execute(request);
        }


        public GetAllOccurrencesDetailsFixture(IGetAllOccurrencesDetails the_query, 
                                                    IRequestHelper<ShiftOccurrenceIdentity> the_request_builder,
                                                    GetOccurrence the_get_shift_occurrence) 
        {
            query = Guard.IsNotNull(the_query, "the_query");
            request = Guard.IsNotNull(the_request_builder, "the_request_builder").given_a_valid_request( );
            get_shift_occurrence = Guard.IsNotNull(the_get_shift_occurrence, "the_get_shift_occurrence");
        }


        private readonly IGetAllOccurrencesDetails query;
        private readonly GetOccurrence get_shift_occurrence;
    }
}