using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SnippetTool
{
  [Collection("SnippetTool")]
  public class SnippetTest : IDisposable
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

    [Fact]
    public void Equals_ObjectsAreTheSame_True()
    {
      //Arrange, Act
      Snippet firstSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
      Snippet secondSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
      //Assert
      Assert.Equal(firstSnippet, secondSnippet );
    }

    [Fact]
    public void Save_SnippetToDatabase_True()
    {
      //Arrange
      Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00));
      //Act
      testSnippet.Save();
      List<Snippet> result = Snippet.GetAll();
      List<Snippet> testList = new List<Snippet>{testSnippet };
      //Assert
      Assert.Equal(testList, result );
    }

    [Fact]
    public void Find_FindsSnippetInDatabase_True()
    {
      //Arrange
      Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00));
      testSnippet.Save();
      //Act
      Snippet foundSnippet = Snippet.Find(testSnippet.Id );
      //Assert
      Assert.Equal(testSnippet, foundSnippet );
    }

    public void Dispose()
    {
      Snippet.DeleteAll();
    }

  }
}
