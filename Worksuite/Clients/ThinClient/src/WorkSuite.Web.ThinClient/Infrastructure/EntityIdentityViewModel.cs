using System.Collections.Generic;
using WorkSuite.Library.Asp.Net.Mvc.Server.Framework.ViewModels;

namespace WTS.WorkSuite.Web.ThinClient.Infrastructure
{
    public class EntityIdentityViewModel<T>
    {
        public T identity { get; set; }
        public IEnumerable<IsAViewElement> view_elements { get; set; }
    }
}