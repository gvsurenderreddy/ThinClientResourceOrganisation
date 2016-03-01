using System.Globalization;

namespace WTS.WorkSuite.Library.DomainTypes.Documents
{
    public struct DocumentId
    {
        readonly int value;

        public DocumentId(int value)
        {
            this.value = value;
        }

        public static implicit operator DocumentId(int b)
        {
            var d = new DocumentId(b);

            return d;
        }

        public static implicit operator int(DocumentId d)
        {
            return d.value;
        }

        public static implicit operator string(DocumentId d)
        {
            return d.value.ToString(CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
