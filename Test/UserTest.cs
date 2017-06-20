using Xunit;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace SnippetTool
{
  [Collection("SnippetTool")]
  public class EndUserTest : IDisposable
  {
    public EndUserTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=snippet_tool_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void EmptyDB_0()
    {
      int result = EndUser.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Equal_ReturnsTrue_Bool()
    {
      EndUser oneUser = new EndUser("Jerry", "password");
      EndUser twoUser = new EndUser("Jerry", "password");
      Assert.Equal(oneUser, twoUser);
    }
    [Fact]
    public void Save_SavesToDB_Object()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      List<EndUser> allUsers = EndUser.GetAll();
      List<EndUser> result = new List<EndUser> {testUser};
      Assert.Equal(result, allUsers);
    }
    [Fact]
    public void Find_FindsUserInDB_Object()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      EndUser foundUser = EndUser.Find(testUser.Id);
      Assert.Equal(foundUser, testUser);
    }
    [Fact]
    public void Update_UpdatesUserInfoInDB_Object()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      string newName = "Gerry";
      testUser.Update(newName);
      string result = testUser.Name;
      Assert.Equal(result, newName);
    }
    [Fact]
    public void UpdatePassword_UpdatesPasswordInDB_Object()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      string newPassword = "12345";
      testUser.UpdatePassword(newPassword);
      string result = testUser.Password;
      Assert.Equal(result, newPassword);
    }
    [Fact]
    public void Delete_DeletesUserFromDB_Object()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      EndUser anotherUser = new EndUser("Rachel", "12345");
      anotherUser.Save();
      testUser.Delete();
      List<EndUser> allUsers = EndUser.GetAll();
      List<EndUser> result = new List<EndUser> {anotherUser};
      Assert.Equal(result, allUsers);
    }
    [Fact]
    public void AddSnippet_AddsSnippetToUser_Object()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00));
      testSnippet.Save();
      Snippet anotherSnippet = new Snippet("More Code", "y = 'Bar'", new DateTime(2017, 1, 01, 11, 55, 00));
      anotherSnippet.Save();
      testUser.AddSnippet(testSnippet);
      testUser.AddSnippet(anotherSnippet);
      List<Snippet> allUserSnippets = testUser.GetSnippets();
      List<Snippet> result = new List<Snippet> {testSnippet, anotherSnippet};
      Assert.Equal(result, allUserSnippets);
    }
    [Fact]
    public void GetSnippets_RetrievesUserSnippets_List()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00));
      testSnippet.Save();
      Snippet anotherSnippet = new Snippet("More Code", "y = 'Bar'", new DateTime(2017, 1, 01, 11, 55, 00));
      anotherSnippet.Save();
      testUser.AddSnippet(testSnippet);
      List<Snippet> allUserSnippets = testUser.GetSnippets();
      List<Snippet> result = new List<Snippet> {testSnippet};
      Assert.Equal(result, allUserSnippets);
    }
    [Fact]
    public void LoginAttempt_ReturnTrueIfSuccess_Bool()
    {
      EndUser testUser = new EndUser("Jerry", "password");
      testUser.Save();
      bool result = EndUser.LoginAttempt("Jerry", "password");
      Assert.Equal(true, result);
    }
    public void Dispose()
    {
      EndUser.DeleteAll();
    }
  }
}
