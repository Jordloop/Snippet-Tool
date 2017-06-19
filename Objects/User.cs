using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace SnippetTool
{
  public class EndUser
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public EndUser(string name, string password, int id = 0)
    {
      Id = id;
      Name = name;
      Password = password;
    }

    public static List<EndUser> GetAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM end_user;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();
      List<EndUser> allUsers = new List<EndUser> {};
      while(rdr.Read())
      {
        int uId = rdr.GetInt32(0);
        string uName = rdr.GetString(1);
        string uPassword = rdr.GetString(2);
        EndUser newUser = new EndUser(uName, uPassword, uId);
        allUsers.Add(newUser);
      }
      return allUsers;
    }
    public override bool Equals(System.Object otherEndUser)
    {
      if(!(otherEndUser is EndUser))
      {
        return false;
      }
      else
      {
        EndUser newEndUser = (EndUser) otherEndUser;
        bool idEquality = (this.Id == newEndUser.Id);
        bool nameEquality = (this.Name == newEndUser.Name);
        bool passwordEquality = (this.Password == newEndUser.Password);
        return (idEquality && nameEquality && passwordEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.Name.GetHashCode();
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM end_user;", conn);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }
  }
}
