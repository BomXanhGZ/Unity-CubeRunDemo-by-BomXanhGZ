using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using UnityEngine;
using static GlobalSpace.GameUtilities;
using static StaticDBConstants;


public class DataBaseConnecter : MonoBehaviour
{
    [SerializeField] DataBaseCreator ref_DataBaseCreator;

    private static IDbConnection db_connecter_ { set; get; }
    public IDbConnection GetDB_Connect => db_connecter_;


    private void Start()
    {
        CheckIsNotNull(ref_DataBaseCreator, "ref_DataBaseCreator in DataBaseConnecter");
        
        string db_path = OpenDBFIle( CUBE_RUN_DB_FILE_NAME );        //Open DB File 
        ConnectToDataBase(db_path);                                                 //call connect data base func
    }

    string OpenDBFIle(string _file_name)
    {
        string db_path = Application.dataPath + "/DataBase/" + _file_name;           //real File path: (Application.persistentDataPath)
        Debug.Log("Database path: " + db_path);
        if (!File.Exists(db_path))                                                   //create file if not exists
        {
            ref_DataBaseCreator.CreateDBFile( db_path );
        }
                           
        return db_path;
    }

    void ConnectToDataBase(string _db_path)
    {
        try
        {
            db_connecter_ = new SqliteConnection("URI=file:" + _db_path);                     //connect data base
            db_connecter_.Open();
            Debug.Log("Database connected.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to open DB: " + e.Message);
        }
                                                           
    }

    private void OnDestroy()
    {
        if (db_connecter_ != null && db_connecter_.State != ConnectionState.Closed)                 //close data base
        {
            db_connecter_.Close();
            db_connecter_ = null;
            Debug.Log("Database connection closed.");
        }
    }
}

