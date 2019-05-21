using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class User
  {
    private string _name;
    private string _gender;
    private int _id;

    public User(string name, string gender, int id = 0)
    {
      _name = name;
      _gender = gender;
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetGender()
    {
      return _gender;
    }
    public void SetGender(string newGender)
    {
      _gender = newGender;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO users (name, gender) VALUES (@userName, @userGender);";
      MySqlParameter userName = new MySqlParameter();
      userName.ParameterName = "@userName";
      userName.Value = this._name;
      cmd.Parameters.Add(userName);
      MySqlParameter userGender = new MySqlParameter();
      userGender.ParameterName = "@userGender";
      userGender.Value = this._gender;
      cmd.Parameters.Add(userGender);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close()
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.ExecuteNonQuery();
      conn.Close();
      if( conn != null )
      {
        conn.Dispose();
      }
    }

  }
}
