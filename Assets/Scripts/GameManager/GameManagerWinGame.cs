using System;
using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.NameScenes;
using static StaticDBConstants;


public class GameManagerWinGame : MonoBehaviour
{
    public bool is_called_ { set; get; } = false;

    [SerializeField] UIWinGame ref_UIWinGame;
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameManagerRunOutTimer ref_GameManagerRunOutTimer;
    [SerializeField] DataBaseUpdate ref_DataBaseUpdate;


    private void Start()
    {
        CheckIsNotNull(ref_UIWinGame, "ref_UIWinGame in  GameManagerWinGame");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerWinGame");
        CheckIsNotNull(ref_GameManagerRunOutTimer, "GameManagerRunOutTimer in GameManagerWinGame");
        CheckIsNotNull(ref_DataBaseUpdate, "ref_DataBaseUpdate in GameManagerWinGame");
    }

    public void HandleWinGame()
    {
        if(!ref_GameManagerData.is_win_game_)
        {
            Debug.Log("HandleWinGame being called when is_win == false");
            return;
        }

        if (!is_called_)
        {
            ref_UIWinGame.ShowWinGameUI();
            ref_DataBaseUpdate.UpdateDataBase(
                                       CONTROLL_LEVEL_TABLE_NAME,                                                                       //tb name
                                       Array.IndexOf( ALL_LEVEL_NAME_ARRAY, ref_GameManagerData.current_scene_name),        //level idx
                                       ref_GameManagerData.score_,                                                                      //score
                                       1);                                                                                              //is passed   
            //...

            is_called_ = true;
        }

        ref_GameManagerRunOutTimer.HandleRunOutTime();
        //...
    }
}
