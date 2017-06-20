using System.Collections.Generic;
using System;
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
        List<Snippet> allSnippets = Snippet.GetAll();
        return View["snippet_view.cshtml", allSnippets];
      };

      Post["/tag_new"] = _ => {
        Tag newTag = new Tag(Request.Form["tag-text"]);
        newTag.Save();
        List<Tag> allTags = Tag.GetAll();
        return View["tag_view.cshtml", allTags];
      };
//-----------------------------
      Get["/snippet_create"] = _ =>
      {
        return View["snippet_create.cshtml"];
      };
//-----------------------------

      Post["/snippet_create"] = _ => {
        Snippet newSnippet = new Snippet(Request.Form["snippet-description"], Request.Form["snippet-text"], new DateTime(2000, 1, 1, 12, 00, 00));

        string testText = newSnippet.Text;
        Console.WriteLine("testText is {0}", testText);
        string x = newSnippet.ConvertSnippetText(testText);
        newSnippet.Text = x;
        newSnippet.Save();
        List<Snippet> allSnippets = Snippet.GetAll();
        return View["snippet_view.cshtml", allSnippets];
      };
//------------------------------

      Post["/user_create"] = _=>
      {
        EndUser newUser = new EndUser(Request.Form["user-name"], Request.Form["user-password"]);
        newUser.Save();
        return View["LOGINPAGE"];
      };

      Post["/user_login"] = _=>
      {
        bool loginAttempt = EndUser.LoginAttempt(Request.Form["user-name"], Request.Form["user-password"]);
        return View["loginsuccess.cshtml", loginAttempt];
      };
      // Get["/tag/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var SelectedTag = Tag.Find(parameters.id);
      //   var TagSnippets = SelectedTag.GetSnippets();
      //   model.Add("tag", SelectedTag);
      //   model.Add("snippet", TagSnippets);
      //   return View["tag_view.cshtml", model];
      // };
      //
      // Get["/snippet/{id}"] = parameters => {
      //   Dictionary<string, object> model = new Dictionary<string, object>();
      //   var SelectedSnippet = Snippet.Find(parameters.id);
      //   var SnippetTags = SelectedSnippet.GetTags();
      //   model.Add("snippet", SelectedSnippet);
      //   model.Add("tag", SnippetTags);
      //   return View["snippet_view.cshtml", model];
      // };
      //
      // Get["/tag/update/{id}"] = parameters => {
      //   Tag SelectedTag = new Tag.Find(parameters.id);
      //   return View["tag_update.cshtml", SelectedTag];
      // };
      //
      // Patch["/tag/update/{id}"] = parameters => {
      //   Tag SelectedTag = new Tag.Find(parameters.id);
      //   SelectedTag.Update(Request.Form["tag-text"]);
      //   return View["tag_view.cshtml", SelectedTag];
      // };
      //
      // Get["/snippet/update/{id}"] = parameters => {
      //   Snippet SelectedSnippet = new Snippet.Find(parameters.id);
      //   return View["tag_update.cshtml", SelectedTag];
      // };
      //
      // Patch["/tag/update/{id}"] = parameters => {
      //   Tag SelectedTag = new Tag.Find(parameters.id);
      //   SelectedTag.Update(Request.Form["snippet-text"], Request.Form["snippet-description"], Request.Form["snippet-time"]);
      //   return View["tag_view.cshtml", SelectedTag];
      // };
      //

      // Delete["/tag/delete/{id}"] = parameters => {
      // };
      // Delete["/snippet/delete/{id}"] = parameters => {
      // };

    }
  }
}
