namespace WTS.WorkSuite.Library.DomainTypes.Primitives.Validation.Premises
{
    public class PersonsNameIsValid : IPremise
    {
        public bool holds(string value)
        {
            return StaticPremises.does_not_contains_characters_that_are_invalid_in_a_persons_name(value);
        }
    }
}
