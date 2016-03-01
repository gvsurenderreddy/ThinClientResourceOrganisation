
namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation.Premises
{
    public class TextFieldIsMandatory : IPremise
    {
        public bool holds(string value)
        {
            return StaticPremises.is_madatory(value);
        }
    }
}
