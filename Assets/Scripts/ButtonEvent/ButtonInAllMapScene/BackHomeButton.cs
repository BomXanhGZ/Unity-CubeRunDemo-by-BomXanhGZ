using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.NameScenes;


public class BackHomeButton : MonoBehaviour
{
    private GameManagerLoadScene ref_GameManagerLoadScene;


    private void Start()
    {
        GameManagerData local_ref_GameManagerData = GameManagerData.GetInstance;
        ref_GameManagerLoadScene = local_ref_GameManagerData.GetComponent<GameManagerLoadScene>();

        CheckIsNotNull(ref_GameManagerLoadScene, "ref_GameManagerLoadScene in BackHomeButton");
    }


    public void OnClickBackHomeButton()
    {
        ref_GameManagerLoadScene.LoadScene( HOME_SCENE );
    }
}
