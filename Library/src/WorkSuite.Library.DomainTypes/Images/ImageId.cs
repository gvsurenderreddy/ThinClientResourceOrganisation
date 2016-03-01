using System.Globalization;

namespace WTS.WorkSuite.Library.DomainTypes.Images
{
    public struct ImageId
    {
        readonly int value;

        public ImageId(int value)
        {
            this.value = value;
        }

        public static implicit operator ImageId(int b)
        {
            var d = new ImageId(b);

            return d;
        }

        public static implicit operator int(ImageId d)
        {
            return d.value;
        }

        public static implicit operator string(ImageId d)
        {
            return d.value.ToString(CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
