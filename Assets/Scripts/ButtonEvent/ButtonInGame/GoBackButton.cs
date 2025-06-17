using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.NameScenes;


public class GoBackButton : MonoBehaviour
{
    private GameManagerData ref_GameManagerData;
    private GameManagerLoadScene ref_GameManagerLoadScene;
    private GameManagerResetDataGame ref_GameManagerResetDataGame;


    private void Start()
    {
        ref_GameManagerData = GameManagerData.GetInstance;
        ref_GameManagerLoadScene = ref_GameManagerData.GetComponent<GameManagerLoadScene>();
        ref_GameManagerResetDataGame = ref_GameManagerData.GetComponent<GameManagerResetDataGame>();

        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in  GoBackButton");
        CheckIsNotNull(ref_GameManagerLoadScene, "ref_GameManagerLoadScene in  GoBackButton");
        CheckIsNotNull(ref_GameManagerResetDataGame, "ref_GameManagerResetDataGame in GoBackButton");
    }

    public void OnClickGoBackButton()
    {
        ref_GameManagerResetDataGame.ResetDataGame();
        ref_GameManagerLoadScene.LoadScene( HOME_SCENE );
    }
}

