using System;

namespace WTS.WorkSuite.Library.DomainTypes.FreeText
{

    /// <summary>
    ///     Defines a property as being FreeText.  This is needed because we
    ///     could not inherit from the string class which would allow us to create 
    ///     a domain specific type for free text fields. 
    /// </summary>

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FreeTextAttribute : Attribute {}
}