using UnityEngine;
using static GlobalSpace.GameUtilities;


public class ContinueButton : MonoBehaviour
{
    private GameManagerData ref_GameManagerData;
    private GameManagerPauseGame ref_GameManagerPauseGame;
    private UIGamePause ref_UIGamePause;


    private void Start()
    {
        ref_GameManagerData = GameManagerData.GetInstance;
        ref_GameManagerPauseGame = ref_GameManagerData.GetComponent<GameManagerPauseGame>();

        UIData local_ref_UIData = UIData.GetInstance;
        ref_UIGamePause = local_ref_UIData.GetComponent<UIGamePause>();

        CheckIsNotNull(ref_UIGamePause, "ref_UIGamePause in ContinueButton");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in ContinueButton");
        CheckIsNotNull(ref_GameManagerPauseGame, "ref_GameManagerPauseGame in ContinueButton");
    }

    public void OnClickContinueButton()
    {
        ref_GameManagerData.is_pause_ = !ref_GameManagerData.is_pause_;

        ref_GameManagerPauseGame.HandlePauseGame();
        ref_UIGamePause.ShowPauseGameUI();
    }
}
