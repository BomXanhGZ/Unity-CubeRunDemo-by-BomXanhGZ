using UnityEngine;
using static GlobalSpace.GameUtilities;


public class GameManagerResetDataGame : MonoBehaviour
{
    [SerializeField] GameManagerData ref_GameManagerData;
    [SerializeField] GameManagerRunOutTimer ref_GameManagerRunOutTimer;
    [SerializeField] GameManagerWinGame ref_GameManagerWinGame;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in GameManagerResetDataGame");
        CheckIsNotNull(ref_GameManagerRunOutTimer, "ref_GameManagerRunOutTimer in GameManagerResetDataGame");
        CheckIsNotNull(ref_GameManagerWinGame, "ref_GameManagerWinGame in ref_GameManagerWinGame");
    }

    public void ResetDataGame()
    {
        ref_GameManagerData.is_game_over_ = false;
        ref_GameManagerData.is_pause_ = false;
        ref_GameManagerData.is_win_game_ = false;
        ref_GameManagerData.score_ = 0;
        ref_GameManagerRunOutTimer.count_run_out_time_ = 0;
        ref_GameManagerWinGame.is_called_ = false;
        //...

        Time.timeScale = 1;

    }
}
