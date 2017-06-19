using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Snippet
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"]
      };

      Get[""]

    }
  }
}
