using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SnippetTool
{
  [Collection("SnippetTool")]
  public class SnippetTool : IDisposable
  {
    public SnippetToolTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=snippet_tool_test;Integrated Security=SSPI;";
    }

    public void GetAll_DatabaseIsEmpty_True()
    {
      //Arrange, Act
      int actucal = Snippet.GetAll().Count;
      //Assert]
      Assert.Equal(0 ,atcual);
    }


  }
}
