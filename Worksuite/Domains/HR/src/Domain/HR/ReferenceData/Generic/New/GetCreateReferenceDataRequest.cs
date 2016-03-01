namespace WTS.WorkSuite.HR.HR.ReferenceData.Generic.New {

    /// <summary>
    ///     Standard implementation of a GetCreateRequest for reference data
    /// </summary>
    /// <typeparam name="R">
    ///     The create request type.
    /// </typeparam>
    /// <typeparam name="Q">
    ///     The response which must be a Response object with a response type that 
    /// is at descendent of the create request.
    /// </typeparam>
    public abstract class GetCreateReferenceDataRequest<R,Q> 
                                : IGetCreateReferenceDataRequest<R,Q> 
                        where R : CreateReferenceDataRequest, new()
                        where Q : GetCreateReferenceDataRequestResponse<R>, new( ) {


        public virtual Q create () {

            return new Q {

                result = new R {
                    description = string.Empty,
                    is_hidden = false,                    
                }
            };
        }
    }
}