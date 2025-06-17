using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static GlobalSpace.GameUtilities;
using static StaticDBConstants;


public class ShowScoreTextFromDataBase : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ref_ScoreText;
    [SerializeField] PlayLevelButton ref_PlayLevelButton;
    private DataBaseData ref_DataBaseData;
    private int button_index_ = -1;


    private void Start()
    {
        CheckIsNotNull(ref_ScoreText, "ref_ScoreText in ShowScoreTextFromDataBase");
        CheckIsNotNull(ref_PlayLevelButton, "ref_PlayLevelButton in ShowScoreTextFromDataBase");

        button_index_ = ref_PlayLevelButton.idx_;

        bool check_connect = ConnectDataBaseData();             //ref DataBase
        if(check_connect)
        {
            int score = GetScoreFromDBase();                    //get data
            SetScoreText(score);                                //set score
        }
    }

    bool ConnectDataBaseData()
    {
        ref_DataBaseData = DataBaseData.GetInstance;
        return CheckIsNotNull(ref_DataBaseData, "ref_DataBaseData in ShowScoreTextFromDataBase");
    }

    int GetScoreFromDBase()
    {
        int score = 0;
        score = ref_DataBaseData.data_base_matrix_[button_index_, (int)LevelField.LEVEL_SCORE];

        return score;
    }

    void SetScoreText(int _score)
    {
        ref_ScoreText.text = _score.ToString() + "/3";
    }
}
