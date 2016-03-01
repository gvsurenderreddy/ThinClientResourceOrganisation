using System.Collections.Generic;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;
using WTS.WorkSuite.Service.DocumentStore.Images.New;

namespace WTS.WorkSuite.Domain.DocumentStore.Images.New
{
    public interface INewImageValidator
    {
        IEnumerable<ResponseMessage> validateImage(NewImageRequest request);  
    }
}
