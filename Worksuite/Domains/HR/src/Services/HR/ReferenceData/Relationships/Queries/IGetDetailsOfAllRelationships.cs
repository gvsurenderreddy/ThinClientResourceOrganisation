using WTS.WorkSuite.HR.HR.ReferenceData.Generic.Queries;

namespace WTS.WorkSuite.HR.HR.ReferenceData.Relationships.Queries
{
    /// <summary>
    ///     Get the full details of all relationships in the system
    /// </summary>
    public interface IGetDetailsOfAllRelationships
                        : IGetDetailsOfAllReferenceData<RelationshipDetails> { }
}