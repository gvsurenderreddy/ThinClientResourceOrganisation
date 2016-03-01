using WTS.WorkSuite.Persistence.Framework.Models;

namespace WTS.WorkSuite.Persistence.Domain.DocumentStore
{
    public class Image : BaseEntity<int>
   {
        public bool isDefault { get; set; }
        public virtual byte[] data { get; set; }
    }
}
