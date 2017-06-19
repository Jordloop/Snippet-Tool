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


    //GetAll()
    public static List<Tag> GetAll()
    {
      List<Tag> allTags = new List<Tag>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM tag;", conn );
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


  }
}
