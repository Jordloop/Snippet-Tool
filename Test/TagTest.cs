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

    [Fact]
    public void AddSnippet_AddSnippetToOneTag_True()
    {
     //Arrange
     Tag testTag = new Tag("loop" );
     testTag.Save();

     Snippet firstSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
     firstSnippet.Save();
     Snippet secondSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
     secondSnippet.Save();
     //Act
     testTag.AddSnippet(firstSnippet );
     testTag.AddSnippet(secondSnippet );
     List<Snippet> result = testTag.GetSnippets();
     List<Snippet> testList = new List<Snippet>{firstSnippet, secondSnippet };
     //Assert
     Assert.Equal(testList, result );
    }

    [Fact]
    public void GetSnippets_ReturnsAllSnippetsFromOneTag_True()
    {
     //Arrange
     Tag testTag = new Tag("loop" );
     testTag.Save();
     Snippet firstSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
     firstSnippet.Save();
     Snippet secondSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
     secondSnippet.Save();
     //Act
     testTag.AddSnippet(firstSnippet );
     testTag.AddSnippet(secondSnippet );
     List<Snippet> testSnippets = testTag.GetSnippets();
     List<Snippet> contolSnippets = new List<Snippet>{firstSnippet, secondSnippet };
     //Assert
     Assert.Equal(contolSnippets, testSnippets );
    }

    [Fact]
    public void Update_UpdatesTagInDatabase_True()
    {
      //Arrange
      Tag testTag = new Tag("poop" );
      testTag.Save();
      string newTest = "loop";
      //Act
      testTag.Update(newTest );
      string result = testTag.Text;
      //Assert
      Assert.Equal(newTest, result );
    }

    [Fact]
    public void Delete_DeletesTagFromDatabase_True()
    {
      //Arrange
      Tag testTag1 = new Tag("loop" );
      testTag1.Save();
      Tag testTag2 = new Tag("dowd" );
      testTag2.Save();
      //Act
      testTag1.Delete();
      List<Tag> resultTagList = Tag.GetAll();
      List<Tag> testTagList = new List<Tag>{testTag2};
      //Assert
      Assert.Equal(testTagList, resultTagList );
    }


    public void Dispose()
    {
      Tag.DeleteAll();
      Snippet.DeleteAll();

    }

  }
}
