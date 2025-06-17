using UnityEngine;
using static GlobalSpace.GameUtilities;


public class ReplayButton : MonoBehaviour
{
    private GameManagerData ref_GameManagerData;
    private GameManagerLoadScene ref_GameManagerLoadScene;
    private GameManagerResetDataGame ref_GameManagerResetDataGame;


    private void Start()
    {
        ref_GameManagerData = GameManagerData.GetInstance;
        ref_GameManagerLoadScene = ref_GameManagerData.GetComponent<GameManagerLoadScene>();
        ref_GameManagerResetDataGame = ref_GameManagerData.GetComponent<GameManagerResetDataGame>();

        CheckIsNotNull(ref_GameManagerLoadScene, "ref_GameManagerLoadScene in ReplayButton");
        CheckIsNotNull(ref_GameManagerResetDataGame, "GameManagerResetDataGame in ReplayButton");
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in ReplayButton");
    }

    public void OnClickReplayButton()
    {
        ref_GameManagerResetDataGame.ResetDataGame();
        ref_GameManagerLoadScene.LoadScene(ref_GameManagerData.current_scene_name);
    }
}
