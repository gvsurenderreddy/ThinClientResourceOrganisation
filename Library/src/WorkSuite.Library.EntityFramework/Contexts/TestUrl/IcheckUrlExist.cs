namespace WTS.WorkSuite.Library.EntityFramework.Contexts.TestUrl
{
    public interface IcheckUrlExist
    {
        IsUrlExistReponse verify 
                        (string location_url);
    }
}