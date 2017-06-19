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

//GetAll()
    public static List<Snippet> GetAll()
    {
      List<Snippet> allSnippets = new List<Snippet>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM snippet;", conn );
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

    
  }
}
