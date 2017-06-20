using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SnippetTool
{
  public class Tag
  {
    public string Text {get; set; }
    public int Id {get; set; }

    public Tag(string newText, int newId = 0 )
    {
      Text = newText;
      Id = newId;
    }
//----Override Methods

//Equals()----
    public override bool Equals(System.Object otherTag )
    {
      if (!(otherTag is Tag ))
      {
        return false;
      }
      else
      {
        Tag newTag = (Tag) otherTag;
        bool idEquality = (this.Id == newTag.Id);
        bool textEquality = (this.Text == newTag.Text);

        return (idEquality && textEquality );
      }
    }
//GetHashCode----
    public override int GetHashCode()
    {
      return this.Text.GetHashCode();
    }
//----Class Methods

//GetAll()----
    public static List<Tag> GetAll()
    {
      List<Tag> allTags = new List<Tag>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tags;", conn );
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int tagId = rdr.GetInt32(0 );
        string tagName = rdr.GetString(1 );

        Tag newTag = new Tag(tagName, tagId );
        allTags.Add(newTag );
      }

      if (rdr != null )
      {
        rdr.Close();
      }
      if (conn != null )
      {
        conn.Close();
      }
      return allTags;
    }


//Save()----
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO tags (text ) OUTPUT INSERTED.id VALUES (@TagText );", conn );

      SqlParameter textParameter = new SqlParameter("@TagText", this.Text);

      cmd.Parameters.Add(textParameter);

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
//Find()----
    public static Tag Find(int id )
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tags WHERE id = @TagId;", conn );

      SqlParameter tagIdParameter = new SqlParameter("@TagId", id.ToString());

      cmd.Parameters.Add(tagIdParameter );

      SqlDataReader rdr = cmd.ExecuteReader();

      int foundTagId = 0;
      string foundTagText = null;

      while(rdr.Read())
      {
        foundTagId = rdr.GetInt32(0 );
        foundTagText = rdr.GetString(1 );
      }
      Tag foundTag = new Tag(foundTagText, foundTagId );

      if (rdr != null )
      {
        rdr.Close();
      }
      if (conn != null )
      {
        conn.Close();
      }
      return foundTag;
    }

//AddSnippet()----
    public void AddSnippet(Snippet newSnippet)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO join_snippets_tags(id_snippet, id_tag) VALUES (@SnippetId, @TagId)", conn );

      SqlParameter SnippetIdParam = new SqlParameter("@SnippetId", newSnippet.Id );

      cmd.Parameters.Add(SnippetIdParam );

      SqlParameter TagIdParam = new SqlParameter("@TagId", this.Id);

      cmd.Parameters.Add(TagIdParam );

      cmd.ExecuteNonQuery();
      if(conn != null )
      {
        conn.Close();
      }
    }

//GetSnippets()----
    public List<Snippet> GetSnippets()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT snippets.* FROM tags JOIN join_snippets_tags ON (tags.id = join_snippets_tags.id_tag) JOIN snippets ON (snippets.id = join_snippets_tags.id_snippet) WHERE tags.id = @TagId", conn );

      SqlParameter TagIdParam = new SqlParameter("@TagId", this.Id.ToString());

      cmd.Parameters.Add(TagIdParam);

      SqlDataReader rdr = cmd.ExecuteReader();

      List<Snippet> snippets = new List<Snippet>{};

      while(rdr.Read())
      {
        int snippetId = rdr.GetInt32(0);
        string snippetDescription = rdr.GetString(1);
        string snippetText = rdr.GetString(2);
        DateTime snippetTime = rdr.GetDateTime(3);

        Snippet newSnippet = new Snippet(snippetDescription, snippetText, snippetTime, snippetId );
        snippets.Add(newSnippet);
      }

      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return snippets;
    }

//Update()----
    public void Update(string newText )
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE tags SET text = @NewText OUTPUT INSERTED.text WHERE id = @TagId;", conn);

      SqlParameter newTextParameter = new SqlParameter("@NewText", newText);

      cmd.Parameters.Add(newTextParameter );

      SqlParameter tagIdParameter = new SqlParameter("@TagId", this.Id);

      cmd.Parameters.Add(tagIdParameter );

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


//Delete()----
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM tags WHERE id = @TagId;", conn );

      SqlParameter tagIdParameter = new SqlParameter("@TagId", this.Id);

      cmd.Parameters.Add(tagIdParameter );
      cmd.ExecuteNonQuery();

      if(conn != null)
      {
        conn.Close();
      }
    }
//DeleteAll()----
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM tags", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }

  }
}
