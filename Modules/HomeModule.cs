using System.Collections.Generic;
using System.IO;
using System;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace SnippetTool
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
//CREATE USER
      Get["/user_create"] = _=>
      {
        return View["user_create.cshtml"];
      };
      Post["/user_create"] = _=>
      {
        EndUser newUser = new EndUser(Request.Form["user-name"], Request.Form["user-password"]);
        byte[] tmp = new byte[0];
        string hash = EndUser.PasswordHash(newUser.Password, tmp);
        newUser.Password = hash;
        newUser.Save();
        return View["user_login.cshtml"];
      };
//USER LOGIN
      Get["/"] = _=>
      {
        return View["user_login.cshtml"];
      };
      Post["/user_login"] = _=>
      {
        string unhashed = Request.Form["user-password"];
        byte[] tmp = new byte[0];
        string hash = EndUser.PasswordHash(unhashed, tmp);
        bool loginResult = EndUser.LoginAttempt(Request.Form["user-name"], hash);
        return View["loginsuccess.cshtml", loginResult];
      };
//ALL SNIPPETS
      Get["/snippet/view"] = _ => {
        List<Snippet> allSnippets = Snippet.GetAll();
        return View["snippet_view.cshtml", allSnippets];
      };
//SPECIFIC SNIPPET
//---VIEW SNIPPET
      Get["/snippet/{id}"] = param => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Snippet SelectedSnippet = Snippet.Find(param.id);
        List<Tag> SnippetTags = SelectedSnippet.GetTags();

        model.Add("snippet", SelectedSnippet);
        model.Add("tag", SnippetTags);
        return View["this_snippet.cshtml", model];
      };

      //----UPDATE SNUPPET

      Get["/snippet/{id}/update"] = param => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Snippet SelectedSnippet = Snippet.Find(param.id);


        model.Add("snippet", SelectedSnippet);
        return View["snippet_update.cshtml", model];
      };
      Patch["/snippet/{id}/update"] = param => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Snippet SelectedSnippet = Snippet.Find(param.id);
        DateTime SnippetDateTime = DateTime.Now;


        List<Tag> SnippetTags = SelectedSnippet.GetTags();

        SelectedSnippet.Update(Request.Form["snippet-text"], SnippetDateTime);

        model.Add("tag", SnippetTags);
        model.Add("snippet", SelectedSnippet);
        return View["this_snippet.cshtml", model];
      };

//----DELETE SNIPPET
      Get["/snippet/{id}/delete"] = param => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Snippet SelectedSnippet = Snippet.Find(param.id);
        List<Tag> SnippetTags = SelectedSnippet.GetTags();

        model.Add("tag", SnippetTags);
        model.Add("snippet", SelectedSnippet);
        return View["delete_confirm.cshtml", model];
      };
      Delete["/snippet/{id}/delete/"] = param => {
        Snippet selectedSnippet = Snippet.Find(param.id);
        selectedSnippet.Delete();
        return View["action_success.cshtml"];
      };
//----DOWNLOAD SNIPPET

      Get["/snippet/{id}/download"] = param =>
      {
        Snippet selectedSnippet = Snippet.Find(param.id);
        string snippetContent = selectedSnippet.Text;
        using (StreamWriter objWriter = new StreamWriter("snippetText"+param.id+".txt"))
        {
          objWriter.Write(snippetContent);
        }
        return View["action_success.cshtml"];
      };
//ADD TAG TO SNIPPET
      Post["/snippet/{id}/add_tag"] = param => {
        Dictionary<string, object> model = new Dictionary<string, object>{};
        Snippet SelectedSnippet = Snippet.Find(param.id);

        Tag newTag = new Tag(Request.Form["tag-text"]);
        newTag.Save();

        SelectedSnippet.AddTag(newTag);
        List<Tag> SnippetTags = SelectedSnippet.GetTags();

        model.Add("snippet", SelectedSnippet);
        model.Add("tag", SnippetTags);
        return View["this_snippet.cshtml", model];
      };
//CREATE SNIPPET
      Get["/snippet/create"] = _ =>
      {
        return View["snippet_create.cshtml"];
      };
      Post["/snippet/create"] = _ => {
        DateTime snippetDateTime = DateTime.Now;
        Snippet newSnippet = new Snippet(Request.Form["snippet-description"], Request.Form["snippet-text"], snippetDateTime);

        newSnippet.Save();
        List<Snippet> allSnippets = Snippet.GetAll();
        return View["snippet_view.cshtml", allSnippets];
      };
//SearchSnippet
      Get["/search/snippets"] = _ => {
        List<Snippet> allSnippets = new List<Snippet>{};
        return View["search_snippet.cshtml", allSnippets];
      };
      Post["/search/snippets"] = _ => {
        List<Snippet> allSnippets = Snippet.SearchSnippetText(Request.Form["search-string"]);
        return View["search_snippet.cshtml", allSnippets];
      };
//SearchTag
      Get["/search/tags"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>{};

        List<Tag> allTags = Tag.GetAll();
        List<Snippet> searchedSnippets = new List<Snippet>{};

        model.Add("searched", searchedSnippets);
        model.Add("Tags", allTags);

        return View["search_tag.cshtml", model];
      };
      Post["/search/tags"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>{};

        List<Tag> allTags = Tag.GetAll();
        List<Snippet> searchedSnippets = Tag.SearchSnippetsByTag(Request.Form["tag-id"]);

        model.Add("searched", searchedSnippets);
        model.Add("Tags", allTags);

        return View["search_tag.cshtml", model];
      };

    }
  }
}
