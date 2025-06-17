using System.Data;
using UnityEngine;
using static GlobalSpace.GameUtilities;
using static StaticDBConstants;


public class DataBaseUpdate : MonoBehaviour
{
    [SerializeField] DataBaseData ref_DataBaseData;
    [SerializeField] DataBaseConnecter ref_DataBaseConnecter;
    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        CheckIsNotNull(ref_DataBaseData, "ref_DataBaseData in DataBaseUpdate");
        CheckIsNotNull(ref_DataBaseConnecter, "ref_DataBaseConnecter in DataBaseUpdate");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in DataBaseUpdate");
    }

    public void UpdateDataBase(string _tb_name, int _in_game_level_idx, int _score, int _win_game_state)
    {

        if (ref_GameManagerData.is_win_game_ == false)                          //only up date when win game
        { return; }

        int current_score = ref_DataBaseData.data_base_matrix_[_in_game_level_idx, (int)LevelField.LEVEL_SCORE];
        int current_win_state = ref_DataBaseData.data_base_matrix_[_in_game_level_idx, (int)LevelField.IS_PASSED];

        if(current_score >= _score && current_win_state == _win_game_state)     //do not Update if Data is the same
        { return; }


        int in_db_level_idx = 1 + _in_game_level_idx;
        IDbConnection ref_DbConn = null;
        if ((ref_DbConn = ref_DataBaseConnecter.GetDB_Connect) != null)         //local connect reference
        {
            using (IDbCommand cmd = ref_DbConn.CreateCommand())
            {
                if (_score > current_score)                                     //only update if new current_score > old current_score in data base
                {
                    //Update In ref_DataBaseData
                    ref_DataBaseData.data_base_matrix_[_in_game_level_idx, (int)LevelField.LEVEL_SCORE] = _score;    //score

                    //Update In DataBase
                    string query_update_score =
                                 "UPDATE " + _tb_name +
                                 " SET " + SCORE + " = " + _score +
                                 " WHERE " + ID_LEVEL_NAME + " = " +  in_db_level_idx + ";";

                    Debug.Log(query_update_score);

                    cmd.CommandText = query_update_score;
                    int check = cmd.ExecuteNonQuery();

                    if (check > 0)      //check success
                    {
                        Debug.Log(query_update_score);
                        Debug.Log("score was updated");
                    }
                }

                if (_win_game_state > current_win_state)                         //Only Update if win state is false
                {
                    //Update In ref_DataBaseData
                    ref_DataBaseData.data_base_matrix_[_in_game_level_idx, (int)LevelField.IS_PASSED] = _win_game_state;    //is passed

                    //Update In DataBase
                    string query_update_is_passed =
                                "UPDATE " + _tb_name +
                                " SET " + IS_PASSED + " = " + _win_game_state +
                                " WHERE " + ID_LEVEL_NAME + " = " + in_db_level_idx + ";";

                    Debug.Log (query_update_is_passed);


                    cmd.CommandText = query_update_is_passed;
                    int check = cmd.ExecuteNonQuery();

                    if (check > 0)      //check success
                    {
                        Debug.Log(query_update_is_passed);
                        Debug.Log("is_passed state was updated");
                    }
                }
            }
        }
    }
}
