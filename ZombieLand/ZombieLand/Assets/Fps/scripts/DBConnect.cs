using Mono.Data.SqliteClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DBConnect : MonoBehaviour
{

    public InputField name;
    public InputField password;

    public InputField name1;
    public InputField password1;
    public bool istrue = false;
 
    public void Guest()
    {
        SceneManager.LoadScene(1);
    }
   public void Login()
    {
        GetUser(name1.text, password1.text);

    }
    public void TestMethod()
    {
        int testID = GetLastID();
        CreateUser(name.text,password.text);
    }

    void CreateUser(string userName, string password)
    {
        string dbName = "URI=file:" + Application.dataPath + "/Plugins/ZombiLand.sqlite";
        // Open the db connection.
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
   command.CommandText = "INSERT INTO USERS (primary_key, NAME, PASSWORD, POINT) VALUES (" + (GetLastID() + 1) + ", '" + userName + "', '" + password + "',0);";
   command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
    USERS GetUser(string userName, string password)
    {
        string dbName = "URI=file:" + Application.dataPath + "/Plugins/ZombiLand.sqlite";
        USERS user = null;
        try
        {
            using (var connection = new SqliteConnection(dbName))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM USERS WHERE NAME = '" + userName + "' AND PASSWORD = '" + password + "'";
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["NAME"].ToString() == userName && reader["PASSWORD"].ToString() == password) { 
                                user = new USERS();
                            user.ID = Convert.ToInt32(reader["primary_key"]);
                            user.NAME = reader["NAME"].ToString();
                            user.PASSWORD = reader["PASSWORD"].ToString();
                            user.POINT = Convert.ToInt32(reader["POINT"]);
                                SceneManager.LoadScene(1);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

        }
        catch (Exception ex)
        {

        }
        return user;
    }

 
    int GetLastID()
    {
        string dbName = "URI=file:" + Application.dataPath + "/Plugins/ZombiLand.sqlite";
        int returnID = 0;
        // Open the db connection.
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT MAX(primary_key) FROM USERS";
                var lastID = command.ExecuteScalar();
                if (lastID != null)
                    returnID = Convert.ToInt32(lastID);
            }
            connection.Close();
        }
        return returnID;
    }
}
public class USERS
{
    public int ID { get; set; }
    public string NAME { get; set; }
    public string PASSWORD { get; set; }
    public int POINT { get; set; }
    public USERS()
    {

    }
    public USERS(int id, string name, string password, int score)
    {
        this.POINT = score;
        this.NAME = name;
        this.ID = id;
        this.PASSWORD = password;
    }
}