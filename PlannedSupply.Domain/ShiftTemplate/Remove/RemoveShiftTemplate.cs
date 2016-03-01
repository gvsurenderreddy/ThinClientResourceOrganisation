using System.Linq;
using Content.Services.PlannedSupply.Messages;
using WorkSuite.Library.Persistence;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates;
using WTS.WorkSuite.PlannedSupply.ShiftTemplates.Remove;

namespace WTS.WorkSuite.PlannedSupply.ShiftTemplate.Remove
{
    public class RemoveShiftTemplate
                     : IRemoveShiftTemplate
    {
        public RemoveShiftTemplateResponse execute(ShiftTemplateIdentity the_shift_identity)
        {
            return this
                .set_request(the_shift_identity)
                .find_shifte()
                .remove_shift_template()
                .commite()
                .build_response();
        }

        private RemoveShiftTemplate set_request(ShiftTemplateIdentity shift_identity)
        {
            shift_template_identity = Guard.IsNotNull(shift_identity, "shift_identity");
            response_builder = new ResponseBuilder< RemoveShiftTemplateResponse>();
            return this;
        }

        private RemoveShiftTemplate find_shifte()
        {
            if (response_builder.has_errors) return this;
            Guard.IsNotNull(repository, "repository");
            Guard.IsNotNull(shift_template_identity, "shift_template_identity");
            entity = repository
                .Entities
                .SingleOrDefault(x => x.id == shift_template_identity.shift_template_id);
            
            return this;
        }

        private RemoveShiftTemplate remove_shift_template()
        {
            if (response_builder.has_errors) return this;
            repository.remove(entity);
            return this;
        }

        private RemoveShiftTemplate commite()
        {
            if (response_builder.has_errors) return this;
            unit_of_work.Commit();
           
            return this;
        }

        private RemoveShiftTemplateResponse build_response()
        {
            if (!response_builder.has_errors)
            {
                 response_builder.add_message(ConfirmationMessages.confirmation_04_0025);
            };
            return response_builder.build();
        }

        public RemoveShiftTemplate 
                                 (IUnitOfWork the_unit_of_work
                                 ,IEntityRepository<ShiftTemplates.ShiftTemplate> the_repository)
        {
            unit_of_work = Guard.IsNotNull(the_unit_of_work, "the_unit_of_work");
            repository = Guard.IsNotNull(the_repository, "the_repository");
        }

        private readonly IUnitOfWork unit_of_work;
        private readonly IEntityRepository<ShiftTemplates.ShiftTemplate> repository;
        private ResponseBuilder<RemoveShiftTemplateResponse> response_builder;
        private ShiftTemplates.ShiftTemplate entity;
        private ShiftTemplateIdentity shift_template_identity;

    }
}