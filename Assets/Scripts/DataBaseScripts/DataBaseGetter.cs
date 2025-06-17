using System.Collections;
using System;
using System.Data;
using UnityEngine;
using static GlobalSpace.GameUtilities;
using static StaticDBConstants;
using static StaticDBConstants.LevelField;


public class DataBaseGetter : MonoBehaviour
{
    [SerializeField] DataBaseData ref_DataBaseData;
    [SerializeField] DataBaseConnecter ref_DataBaseConnecter;


    private void Start()
    {
        CheckIsNotNull(ref_DataBaseData, "ref_DataBaseData in DataBaseGetter");
        CheckIsNotNull(ref_DataBaseConnecter, "ref_DataBaseConnecter in DataBaseGetter");

        StartCoroutine( WaitOneFrameForGetData() );
    }

    IEnumerator WaitOneFrameForGetData()
    {
        yield return null;
        LoadDataFromDataBase(CONTROLL_LEVEL_TABLE_NAME);
    }

    void LoadDataFromDataBase(string _table_name)
    {
        string query = "SELECT * FROM " + _table_name + ";";      //query text
        IDbConnection ref_DbConn = null;                                        //local reference connect

        if ( (ref_DbConn = ref_DataBaseConnecter.GetDB_Connect) != null )       //get connect from connecter
        {
            using (var cmd = ref_DbConn.CreateCommand())                        //create cmd with connect
            {
                cmd.CommandText = query;                                        //create query text with cmd

                try
                {
                    using (var reader = cmd.ExecuteReader())                       //execute reading data
                    {
                        int row_counter = 0;
                        while (reader.Read())                                      //if reader.Read() get true / false
                        {
                            ref_DataBaseData.data_base_matrix_[row_counter, (int)LEVEL_IDX] = reader.GetInt32(0);
                            ref_DataBaseData.data_base_matrix_[row_counter, (int)LevelField.IS_PASSED] = reader.GetInt32(1);
                            ref_DataBaseData.data_base_matrix_[row_counter, (int)LEVEL_SCORE] = reader.GetInt32(2);

                            row_counter++;
                        }

                        //show data for debug
                        int row = ref_DataBaseData.data_base_matrix_.GetLength(0);
                        int col = ref_DataBaseData.data_base_matrix_.GetLength(1);
                        for (int i = 0; i < row; i++)
                        {
                            Debug.Log("level: " + i);

                            for (int j = 0; j < col; j++)
                            {
                                Debug.Log(ref_DataBaseData.data_base_matrix_[i, j]);
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}
