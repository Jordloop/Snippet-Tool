using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SnippetTool
{
  [Collection("SnippetTool")]
  public class SnippetTest
  // : IDisposable
  {
    public SnippetTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=snippet_tool_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_DatabaseIsEmpty_True()
    {
      //Arrange, Act
      int actual = Snippet.GetAll().Count;
      //Assert]
      Assert.Equal(0 ,actual);
    }


  }
}

