using WTS.WorkSuite.Library.DomainTypes.Duration;
using WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New.GetCreateRequest;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Break.New
{
    public class GetNewBreakRequest
                    : IGetNewBreakRequest
    {
        public NewBreakRequest execute(BreakIdentity request)
        {
            return new NewBreakRequest
                            {
                                template_id = request.template_id,
                                off_set = new DurationRequest
                                                        {
                                                            hours = string.Empty,
                                                            minutes = string.Empty
                                                        },
                                duration = new DurationRequest
                                                    {
                                                        hours = string.Empty,
                                                        minutes = string.Empty
                                                    },
                                is_paid = false
                            };
        }
    }
}