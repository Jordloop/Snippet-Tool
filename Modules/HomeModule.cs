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

      Get["/snippet_view"] = _ => {
        List<Snippet> allSnippets = Snippet.GetAll;
        return View["snippet_view", allSnippets];
      };

      Post["/tag_new"] = _ = {
        Tag newTag = new Tag(Request.Form["tag-name"]);
        newTag.Save();
        List<Tag> allTags = Tag.GetAll();
        return View["tag_view.cshtml", allTags];
      };

      Post["/snippet_new"] = _ = {
        Snippet newSnippet = new Snippet(Request.Form["snippet-name"]);
        List<Snippet> allSnippets = Snippet.GetAll();
        return View["snippet_view", allSnippets];
      };

      Get["/tag/{id}"] = parameters => {
      };

      Get["/snippet/{id}"] = parameters => {
      };

      Get["/tag/{id}/update"] = parameters => {
      };

      Get["/snippet/{id}/update"] = parameters => {
      };

      Get["/tag/{id}/delete"] = parameters => {
      };

      Get["/snippet/{id}/delete"] = parameters => {
      };


    }
  }
}
