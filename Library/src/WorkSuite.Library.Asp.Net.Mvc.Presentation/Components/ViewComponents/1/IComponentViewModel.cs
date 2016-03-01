using System;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.TileGrids._1;
using WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.Tiles._1;
using WTS.WorkSuite.Library.CodeStrutures.Behavioral;

namespace WorkSuite.Library.Asp.Net.Mvc.Presentation.Components.ViewComponents._1 {


    /// <summary>
    /// Marker interface that is use to a class commponents view model.  
    /// </summary>
    /// <remarks>
    /// This allows disparate components to be collected to gether, a mechanism of 
    /// achiveing this is needed when you have composite view which require a view 
    /// model to be a container for multiple different view models 
    /// </remarks>
    public interface IComponentViewModel {  }
}
