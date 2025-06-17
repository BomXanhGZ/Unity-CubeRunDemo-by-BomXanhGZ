using UnityEngine;
using static GlobalSpace.GameUtilities;
using static GameSettings.NameScenes;


public class PlayLevelButton : MonoBehaviour
{
    public int idx_ { set; get; }       //From 0;
    public string level_name_ {  get; set; }
    private GameManagerLoadScene ref_GameManagerLoadScene;


    private void Start()
    {
        GameManagerData local_ref_GameManagerData = GameManagerData.GetInstance;
        ref_GameManagerLoadScene = local_ref_GameManagerData.GetComponent<GameManagerLoadScene>();

        CheckIsNotNull(ref_GameManagerLoadScene, "ref_GameManagerLoadScene in PlayLevelButton");    
    }

    public void SetDataPlayLevelButton(int _idx)
    {
        idx_ = _idx;
        level_name_ = ALL_LEVEL_NAME_ARRAY[_idx];
    }

    public void OnClickPlayLevelButton()
    {
        ref_GameManagerLoadScene.LoadScene(level_name_);
    }
}
