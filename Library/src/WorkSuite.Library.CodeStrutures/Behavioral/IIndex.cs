
namespace WTS.WorkSuite.Library.CodeStrutures.Behavioral
{
    public interface IIndex<in k, v>
    {
        Maybe<v> lookup(k key);
    }
}
