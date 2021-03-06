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

    [Fact]
    public void AddTag_AddTagToOneSnippet_True()
    {
     //Arrange
     Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
     testSnippet.Save();

     Tag firstTag = new Tag("loop" );
     firstTag.Save();
     Tag secondTag = new Tag("dowd" );
     secondTag.Save();
     //Act
     testSnippet.AddTag(firstTag );
     testSnippet.AddTag(secondTag );
     List<Tag> result = testSnippet.GetTags();
     List<Tag> testList = new List<Tag>{firstTag, secondTag };
     //Assert
     Assert.Equal(testList, result );
    }

    [Fact]
    public void GetTags_ReturnsAllTagsFromOneSnippet_True()
    {
     //Arrange
     Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00) );
     testSnippet.Save();
     Tag firstTag = new Tag("loop" );
     firstTag.Save();
     Tag secondTag = new Tag("loop" );
     secondTag.Save();
     //Act
     testSnippet.AddTag(firstTag );
     testSnippet.AddTag(secondTag );
     List<Tag> testTags = testSnippet.GetTags();
     List<Tag> controlTags = new List<Tag>{firstTag, secondTag };
     //Assert
     Assert.Equal(controlTags, testTags );
    }

    [Fact]
    public void Update_UpdatesSnippetInDatabase_True()
    {
      //Arrange
      Snippet testSnippet = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00));
      testSnippet.Save();
      string newTest = "y = 'Mii'";
      DateTime SnippetDateTime = DateTime.Now;

      //Act
      testSnippet.Update(newTest, SnippetDateTime);
      string result = testSnippet.Text;
      //Assert
      Assert.Equal(newTest, result);
    }

    [Fact]
    public void Search_SearchSnippetText_True()
    {
      Snippet testSnippet = new Snippet("desc1", "x = 'Foo'", new DateTime(2000, 01, 01));
      testSnippet.Save();

      Snippet controlSnippet = new Snippet("desc2", "y = 'Foo'", new DateTime(1999, 01, 01));
      controlSnippet.Save();

      Snippet testCaseSensSnippet = new Snippet("desc3", "x = 'foo'", new DateTime  (1950, 01, 01));
      testCaseSensSnippet.Save();

      List<Snippet> testList = Snippet.SearchSnippetText("Foo");
      List<Snippet> expectedList = new List<Snippet>{testSnippet, controlSnippet};

      bool testTrue = (testList.Contains(testSnippet) && testList.Contains(controlSnippet));
      bool controlTrue = (expectedList.Contains(testSnippet) && expectedList.Contains(controlSnippet));

      Assert.Equal(testTrue, controlTrue);
    }

    [Fact]
    public void Delete_DeletesSnippetFromDatabase_True()
    {
      //Arrange
      Snippet testSnippet1 = new Snippet("Some Code", "x = 'Foo'", new DateTime(2017, 6, 19, 12, 55, 00));
      testSnippet1.Save();
      Snippet testSnippet2 = new Snippet("Other Code", "x = 'Zoo'", new DateTime(2017, 7, 19, 12, 55, 00) );
      testSnippet2.Save();
      //Act
      testSnippet1.Delete();
      List<Snippet> resultSnippetList = Snippet.GetAll();
      List<Snippet> testSnippetList = new List<Snippet>{testSnippet2};
      //Assert
      Assert.Equal(testSnippetList, resultSnippetList );
    }


    public void Dispose()
    {
      Snippet.DeleteAll();
      Tag.DeleteAll();
    }

  }
}
