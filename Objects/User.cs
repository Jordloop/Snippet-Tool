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

    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM end_user WHERE id = @UserId;", conn);
      SqlParameter uId = new SqlParameter("@UserId", this.Id);
      cmd.Parameters.Add(uId);
      cmd.ExecuteNonQuery();
      if(conn != null)
      {
        conn.Close();
      }
    }
    public void Update(string update)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("UPDATE end_user SET name = @NewName OUTPUT INSERTED.name WHERE id = @UserId;", conn);
      SqlParameter uName = new SqlParameter("@NewName", update);
      cmd.Parameters.Add(uName);
      SqlParameter uId = new SqlParameter("@UserId", this.Id.ToString());
      cmd.Parameters.Add(uId);
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        this.Name = rdr.GetString(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }
    public static EndUser Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("SELECT * FROM end_user WHERE id = @UserId;", conn);
      SqlParameter uId = new SqlParameter("@UserId", id.ToString());
      cmd.Parameters.Add(uId);
      SqlDataReader rdr = cmd.ExecuteReader();
      int foundId = 0;
      string foundName = null;
      string foundPassword = null;
      while(rdr.Read())
      {
        foundId = rdr.GetInt32(0);
        foundName = rdr.GetString(1);
        foundPassword = rdr.GetString(2);
      }
      EndUser foundUser = new EndUser(foundName, foundPassword, foundId);
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundUser;
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("INSERT INTO end_user (name, password) OUTPUT INSERTED.id VALUES (@UserName, @UserPassword);", conn);
      SqlParameter uName = new SqlParameter("@UserName", this.Name);
      cmd.Parameters.Add(uName);
      SqlParameter uPassword = new SqlParameter("@UserPassword", this.Password);
      cmd.Parameters.Add(uPassword);
      SqlDataReader rdr = cmd.ExecuteReader();
      while(rdr.Read())
      {
        this.Id = rdr.GetInt32(0);
      }
      if(rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
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
