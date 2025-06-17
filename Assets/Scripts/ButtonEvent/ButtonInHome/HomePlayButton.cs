using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.NameScenes;


public class HomePlayButton : MonoBehaviour
{
    [SerializeField] GameManagerLoadScene ref_GameManagerLoadScene;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerLoadScene, "ref_GameManagerLoadScene in HomePlayButton");
    }

    public void OnClickHomePlayButton()
    {
        ref_GameManagerLoadScene.LoadScene( LEVEL_MENU_SCENE );
    }
}
