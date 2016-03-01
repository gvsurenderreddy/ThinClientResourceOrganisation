namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation.Premises
{
    public class TextFieldIsWithinDefaultNumberOfCharacters : IPremise
    {
        public bool holds(string value)
        {
            return StaticPremises.does_not_exceed_the_maximum_number_of_characters_for_a_text_field(value);
        }
    }
}
