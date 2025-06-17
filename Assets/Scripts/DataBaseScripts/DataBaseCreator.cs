

using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;
using static GameSettings.NameScenes;
using static StaticDBConstants;


public class DataBaseCreator : MonoBehaviour
{
    public void CreateDBFile(string _db_path)
    {
        Debug.Log(_db_path);
        try
        {
            using (IDbConnection db_conn = new SqliteConnection("URI=file:" + _db_path))        //Create File
            {
                db_conn.Open();                                                                 //Open File
                CreateTable(db_conn, CREATE_LEVEL_TABLE_COMMAND);                               //Create level state Table

                for (int l = 0; l <  ALL_LEVEL_NAME_ARRAY.Length; l++)
                {
                    InsertDataIntoTable(
                        db_conn,
                        CONTROLL_LEVEL_TABLE_NAME,
                        new string[] { IS_PASSED, SCORE },
                        new int[] { 0, 0 }  );
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    void CreateTable(IDbConnection _conn, string _cmd_text)
    {
        try
        {
            using (IDbCommand db_cmd = _conn.CreateCommand())                               //create command with DB_Connect
            {
                db_cmd.CommandText = _cmd_text;
                db_cmd.ExecuteNonQuery();                                                   //Execute cmd To create table
                Debug.Log("DB_FIle was created.");
            }
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }
    }

    void InsertDataIntoTable(IDbConnection _conn, string _table_name, string[] _columns_name, int[] _int_val /*, string[] _text_val = null*/)
    {
        string query = "INSERT INTO " + _table_name + " (" ;

        if( _columns_name == null || _int_val == null )
        {
            Debug.LogError("inserted data is null ");
            return;
        }

        if(_columns_name.Length != _int_val.Length )
        {
            Debug.LogError("inserted ArrayLength of data not the same");
            return;
        }

        for (int c = 0; c < _columns_name.Length; c++)              //handle columns name
        {
            query += _columns_name[c];

            if (c < _columns_name.Length - 1)
            {
                query += ", ";
            }
        }

        query += ") VALUES " + "(" ;

        for (int i = 0; i < _int_val.Length; i++)                   //handle inserted value
        {
            query += _int_val[i];

            if (i < _int_val.Length - 1)
            {
                query += ", ";
            }
        }

        query += ");" ;

        //==================================
        Debug.Log("command is: " + query);

        using( IDbCommand cmd = _conn.CreateCommand() )
        {
            try
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch(System.Exception e )
            {
                Debug.LogException(e);
            }
        }
    }
}
