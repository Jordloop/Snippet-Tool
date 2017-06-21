using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SnippetTool
{
  public class Snippet
  {
    public string Description {get; set; }
    public string Text {get; set; }
    public DateTime Time {get; set; }
    public int Id {get; set; }

    public Snippet(string newDescription, string newText, DateTime newTime, int newId = 0  )
    {
      Text = newText;
      Description = newDescription;
      Time = newTime;
      Id = newId;
    }

//----Override Methods

//Equals()----
    public override bool Equals(System.Object otherSnippet )
    {
      if (!(otherSnippet is Snippet ))
      {
        return false;
      }
      else
      {
        Snippet newSnippet = (Snippet) otherSnippet;
        bool descriptionEquality = (this.Description == newSnippet.Description);
        bool textEquality = (this.Text == newSnippet.Text);
        bool timeEquality = (this.Time == newSnippet.Time);
        bool idEquality = (this.Id == newSnippet.Id);

        return (idEquality && textEquality && timeEquality && descriptionEquality  );
      }
    }
//GetHashCode()----
    public override int GetHashCode()
    {
      return this.Description.GetHashCode();
    }

//----Class Methods

//----GetAll()
    public static List<Snippet> GetAll()
    {
      List<Snippet> allSnippets = new List<Snippet>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM snippets;", conn );
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int snippetId = rdr.GetInt32(0 );
        string snippetDesctiption = rdr.GetString(1 );
        string snippetText = rdr.GetString(2 );
        DateTime snippetTimestamp = rdr.GetDateTime(3 );

        Snippet newSnippet = new Snippet(snippetDesctiption, snippetText, snippetTimestamp, snippetId );
        allSnippets.Add(newSnippet );
      }

      if (rdr != null )
      {
        rdr.Close();
      }
      if (conn != null )
      {
        conn.Close();
      }
      return allSnippets;
    }
//----ConvertSnippetText()
    public string ConvertSnippetText(string userInput)
    {
      // Console.WriteLine(userInput);
      string userInputConverted = userInput.Replace("33", "44");
      return userInputConverted;
    }
//----Save()
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO snippets (description, text, time ) OUTPUT INSERTED.id VALUES (@SnippetDesctiption, @SnippetText, @SnippetTimestamp );", conn );

      SqlParameter descriptionParameter = new SqlParameter("SnippetDesctiption", this.Description);

      SqlParameter textParameter = new SqlParameter("@SnippetText", this.Text);

      SqlParameter timestampParameter = new SqlParameter("@SnippetTimestamp", this.Time);

      cmd.Parameters.Add(descriptionParameter);
      cmd.Parameters.Add(textParameter);
      cmd.Parameters.Add(timestampParameter);

      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0 );
      }
      if(rdr != null )
      {
        rdr.Close();
      }
      if(conn != null )
      {
        conn.Close();
      }
    }

//----Find()
    public static Snippet Find(int id )
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM snippets WHERE id = @SnippetId;", conn );

      SqlParameter SnippetIdParameter = new SqlParameter("@SnippetId", id.ToString());

      cmd.Parameters.Add(SnippetIdParameter );

      SqlDataReader rdr = cmd.ExecuteReader();

      int foundSnippetId = 0;
      string foundSnippetDescription = null;
      string foundSnippetText = null;
      DateTime foundSnippetTime = default(DateTime);

      while(rdr.Read())
      {
        foundSnippetId = rdr.GetInt32(0 );
        foundSnippetDescription = rdr.GetString(1 );
        foundSnippetText = rdr.GetString(2 );
        foundSnippetTime = rdr.GetDateTime(3 );
      }
      Snippet foundSnippet = new Snippet(foundSnippetDescription, foundSnippetText, foundSnippetTime, foundSnippetId );

      if (rdr != null )
      {
        rdr.Close();
      }
      if (conn != null )
      {
        conn.Close();
      }
      return foundSnippet;
    }

//----AddTag()
    public void AddTag(Tag newTag)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO join_snippets_tags(id_snippet, id_tag) VALUES (@SnippetId, @TagId)", conn );

      SqlParameter TagIdParam = new SqlParameter("@TagId",newTag.Id);

      cmd.Parameters.Add(TagIdParam );

      SqlParameter SnippetIdParam = new SqlParameter("@SnippetId",this.Id);

      cmd.Parameters.Add(SnippetIdParam );

      cmd.ExecuteNonQuery();
      if(conn != null )
      {
        conn.Close();
      }
    }

//----GetTags()
    public List<Tag> GetTags()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT tags.* FROM snippets JOIN join_snippets_tags ON (snippets.id = join_snippets_tags.id_snippet) JOIN tags ON (tags.id = join_snippets_tags.id_tag) WHERE snippets.id = @SnippetId", conn );

      SqlParameter SnippetIdParam = new SqlParameter("@SnippetId",this.Id.ToString());

      cmd.Parameters.Add(SnippetIdParam);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Tag> tags = new List<Tag>{};

      while(rdr.Read())
      {
        int tagId = rdr.GetInt32(0);
        string tagText = rdr.GetString(1);

        Tag newTag = new Tag(tagText, tagId);
        tags.Add(newTag);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return tags;
    }
//----Update()
public void Update(string newText )
{
  SqlConnection conn = DB.Connection();
  conn.Open();

  SqlCommand cmd = new SqlCommand("UPDATE snippets SET text = @NewText OUTPUT INSERTED.text WHERE id = @SnippetId;", conn);

  SqlParameter newTextParameter = new SqlParameter("@NewText", newText);

  cmd.Parameters.Add(newTextParameter );

  SqlParameter snippetIdParameter = new SqlParameter("@SnippetId", this.Id);

  cmd.Parameters.Add(snippetIdParameter );

  SqlDataReader rdr = cmd.ExecuteReader();

  while(rdr.Read())
  {
    this.Text = rdr.GetString(0);
  }
  if(rdr != null )
  {
    rdr.Close();
  }
  if(conn != null )
  {
    conn.Close();
  }
}

//Search()----
    public static List<Snippet> SearchSnippetText(string searchText)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      searchText = '%' + searchText + '%';
      SqlCommand cmd = new SqlCommand("SELECT * FROM snippets WHERE  snippets.text LIKE @SearchText COLLATE Latin1_General_CS_AS", conn);

      SqlParameter textParameter = new SqlParameter("@SearchText", searchText);

      cmd.Parameters.Add(textParameter);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<Snippet> snippets = new List<Snippet>{};

      while(rdr.Read())
      {
        int snippetId = rdr.GetInt32(0);
        string snippetDesc = rdr.GetString(1);
        string snippetText = rdr.GetString(2);
        DateTime snippetDatetime = rdr.GetDateTime(3);

        Snippet newSnippet = new Snippet(snippetDesc, snippetText, snippetDatetime, snippetId);
        snippets.Add(newSnippet);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return snippets;
    }


//----Delete()
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM snippets WHERE id = @SnippetId;", conn );

      SqlParameter snippetIdParameter = new SqlParameter("@SnippetId", this.Id);

      cmd.Parameters.Add(snippetIdParameter );
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }

//----DeleteAll()
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM snippets", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
