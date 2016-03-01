using WorkSuite.Library.Persistence;

namespace WTS.WorkSuite.HR.Framework.Models
{
    /// <summary>
    ///     Base class that contains all the field that a
    ///     standard reference data model will have
    /// </summary>
    public abstract class ReferenceDataModel : BaseEntity<int>
    {
        public string description { get; set; }

        public bool is_hidden { get; set; }
    }

    public static class ReferenceDataExtensionMethods
    {
        public static int? get_id_or_default_if_null(this ReferenceDataModel value)
        {
            return value != null ? value.id : new int?();
        }

        public static string get_description_or_default_if_null(this ReferenceDataModel value)
        {
            return value != null ? value.description : null;
        }
    }
}