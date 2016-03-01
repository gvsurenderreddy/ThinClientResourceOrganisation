﻿
using System;
using System.Linq;
using WorkSuite.Library.Service.Specification.Helpers.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral.Events;
using WTS.WorkSuite.SupplyShortage.Employee.Sickness.events;
using WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.listItems.Setup;

namespace WTS.WorkSuite.ThinClient.Query.Services.Application.HR.employee.Sickness.eventHandlers.sicknessCreated
{
    public class SicknessCreatedEventFixture
    {
        public void add_to_repository()
        {
            DateTime add_date = new DateTime(2015, 4, 1);
            sickness_list_view_helper.add().employee_id(1).sickness_date(add_date);
            sickness_list_view_helper.add().employee_id(1).sickness_date(add_date.AddDays(1));
        }

        public SicknessCreatedEvent CreateEvent()
        {
            return new SicknessCreatedEvent
            {
                employee_id = 1,
                sickness_date = new DateTime(2015, 4, 1)
            };
        }

        public bool changes_were_commited()
        {
            return unit_of_work.commit_was_called;
        }

        public int count_matching_events_in_repository(SicknessCreatedEvent created_event)
        {
            return
                sickness_list_view_helper.entities.Count(
                    h => h.employee_id == created_event.employee_id && h.sickness_date == created_event.sickness_date);
        }

        public SicknessCreatedEventFixture(SicknessListViewHelper sickness_list_view_helper 
                                         , FakeUnitOfWork unit_of_work
                                         , IEventSubscriber<SicknessCreatedEvent> sickness_created_event_handler)
        {
            this.sickness_list_view_helper =Guard.IsNotNull(sickness_list_view_helper, "sickness_list_view_helper");
            this.unit_of_work = Guard.IsNotNull(unit_of_work, "unit_of_work");
            this.sickness_created_event_handler = Guard.IsNotNull(sickness_created_event_handler, "sickness_created_event_handler");
        }

        private readonly SicknessListViewHelper sickness_list_view_helper;
        private readonly FakeUnitOfWork unit_of_work;
        public IEventSubscriber<SicknessCreatedEvent> sickness_created_event_handler { private set; get; }
    }
}
