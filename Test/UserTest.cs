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
    public void Dispose()
    {
      EndUser.DeleteAll();
    }
  }
}
