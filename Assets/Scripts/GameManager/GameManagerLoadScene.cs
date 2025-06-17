using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalSpace.GameUtilities;


public class GameManagerLoadScene : MonoBehaviour
{
    public delegate void OnSceneLoaded();
    public static event OnSceneLoaded scene_loaded_event_;

    [SerializeField] GameManagerData ref_GameManagerData;


    private void Start()
    {
        CheckIsNotNull(ref_GameManagerData, "ref_GameManagerData in Scene Loader");
    }

    public void LoadScene(string _scene_name)
    {
        SceneManager.LoadScene(_scene_name);
        ref_GameManagerData.current_scene_name = _scene_name;
        scene_loaded_event_?.Invoke();

        Debug.Log("current scene" + ref_GameManagerData.current_scene_name);
    }
}
