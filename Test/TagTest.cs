using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SnippetTool
{
  [Collection("SnippetTool")]
  public class TagTest : IDisposable
  {
    public TagTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=snippet_tool_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void GetAll_DatabaseIsEmpty_True()
    {
      //Arrange, Act
      int actual = Tag.GetAll().Count;
      //Assert]
      Assert.Equal(0 ,actual);
    }

    [Fact]
    public void Equals_ObjectsAreTheSame_True()
    {
      //Arrange, Act
      Tag firstTag = new Tag("loop" );
      Tag secondTag = new Tag("loop" );
      //Assert
      Assert.Equal(firstTag, secondTag );
    }

    [Fact]
    public void Save_TagToDatabase_True()
    {
      //Arrange
      Tag testTag = new Tag("loop" );
      //Act
      testTag.Save();
      List<Tag> result = Tag.GetAll();
      List<Tag> testList = new List<Tag>{testTag };
      //Assert
      Assert.Equal(testList, result );
    }

    [Fact]
    public void Find_FindsTagInDatabase_True()
    {
      //Arrange
      Tag testTag = new Tag("loop");
      testTag.Save();
      //Act
      Tag foundTag = Tag.Find(testTag.Id );
      //Assert
      Assert.Equal(testTag, foundTag );
    }

    public void Dispose()
    {
      Tag.DeleteAll();
    }

  }
}
