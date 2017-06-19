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
      EndUser newUser = new EndUser("Jerry", "password");
      newUser.Save();
      List<EndUser> allUsers = EndUser.GetAll();
      List<EndUser> result = new List<EndUser> {newUser};
      Assert.Equal(result, allUsers);
    }
    public void Dispose()
    {
      EndUser.DeleteAll();
    }
  }
}
