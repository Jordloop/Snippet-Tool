using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace SnippetTool
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        List<Tag> allTags = Tag.GetAll();
        return View["tag_view.cshtml", allTags];
      };












    }
  }
}
