namespace WTS.WorkSuite.Library.DomainTypes.DefinitionList
{
    public class DefinitionListElement
    {
        public string title { get; private set; }

        public string definition { get; private set; }

        public DefinitionListElement(string the_title, string the_definition)
        {
            title = the_title;
            definition = the_definition;
        }
    }
}