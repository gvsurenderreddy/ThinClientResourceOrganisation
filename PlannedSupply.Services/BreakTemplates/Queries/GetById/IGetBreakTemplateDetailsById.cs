using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WTS.WorkSuite.PlannedSupply.BreakTemplates.Queries.GetById
{
    public interface IGetBreakTemplateDetailsById
                            : IQuery<BreakTemplateIdentity, Response<GetBreakTemplateByIdResponse>> { }
}