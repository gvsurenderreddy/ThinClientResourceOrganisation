using System;
using WTS.WorkSuite.Core.DomainIdentity;

namespace WTS.WorkSuite.HR.HR.Employees.EmployeePersonalDetails.Events
{
    public class EmployeePersonalDetailsUpdatedEvent
                    : EmployeeIdentity
    {
        public string forename { get; set; }

        public string surname { get; set; }

        public string othername { get; set; }

        public string place_of_birth { get; set; }

        public int? title_id { get; set; }

        public string title_description { get; set; }

        public int? gender_id { get; set; }

        public string gender_description { get; set; }

        public int? marital_status_id { get; set; }

        public string marital_status_description { get; set; }

        public int? nationality_id { get; set; }

        public string nationality_description { get; set; }

        public int? ethnic_origin_id { get; set; }

        public string ethnic_origin_description { get; set; }

        public DateTime? date_of_birth { get; set; }
    }
}